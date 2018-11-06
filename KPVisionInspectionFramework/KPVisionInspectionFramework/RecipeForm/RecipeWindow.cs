using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic.FileIO;

using LogMessageManager;

namespace KPVisionInspectionFramework
{
    public partial class RecipeWindow : Form
    {
        private string RecipeFolderPath = @"D:\VisionInspectionData\CIPOSLeadInspection\RecipeParameter\";
        private string ProjectName = "CIPOSLeadInspection";
        private string CurrentRecipeName;
        private bool IsRecipeNew = false;

        public delegate bool RecipeChangeHandler(string _RecipeName, string _srcRecipeName = "");
        public event RecipeChangeHandler RecipeChangeEvent;

        #region Initialize & DeInitialize
        public RecipeWindow()
        {
            InitializeComponent();
        }

        public RecipeWindow(string _ProjectName, string _CurrentRecipe = "Default")
        {
            InitializeComponent();

            ProjectName = _ProjectName;
            RecipeFolderPath = String.Format(@"D:\VisionInspectionData\{0}\RecipeParameter\", ProjectName);

            CurrentRecipeName = _CurrentRecipe;
            LoadRecipeList();
        }
        #endregion Initialize & DeInitialize

        #region Control Default Event
        private void RecipeWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) e.Handled = true;
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

            s.Parent.Left = this.Left + (e.X - ((Point)s.Tag).X);
            s.Parent.Top = this.Top + (e.Y - ((Point)s.Tag).Y);

            this.Cursor = Cursors.Default;
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            s.Tag = new Point(e.X, e.Y);
        }

        private void labelTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.labelTitle.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        #endregion Control Default Event

        #region Control Event
        private void btnRecipeChange_Click(object sender, EventArgs e)
        {
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "RecipeWindow - RecipeChange_Click", CLogManager.LOG_LEVEL.LOW);
            if (listBoxRecipe.SelectedItem == null) { MessageBox.Show(new Form { TopMost = true }, "Select the recipe you want to change."); return; }

            this.Hide();
            RecipeChange(listBoxRecipe.SelectedItem.ToString());

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "RecipeWindow - RecipeChange Complete : " + listBoxRecipe.SelectedItem.ToString(), CLogManager.LOG_LEVEL.LOW);
            this.Show();
        }

        private void btnRecipeAdd_Click(object sender, EventArgs e)
        {
            IsRecipeNew = true;

            RecipeNewNameWindow _RcpNewNameWnd = new RecipeNewNameWindow();
            _RcpNewNameWnd.RecipeCopyEvent += new RecipeNewNameWindow.RecipeCopyHandler(RecipeCopyEventFunction);

            string[] _RecipeList = new string[listBoxRecipe.Items.Count];
            for (int iLoopCount = 0; iLoopCount < _RecipeList.Count(); ++iLoopCount)
                _RecipeList[iLoopCount] = listBoxRecipe.Items[iLoopCount].ToString();

            _RcpNewNameWnd.SetCurrentRecipe("[Default]", _RecipeList);

            if (_RcpNewNameWnd.ShowDialog() == DialogResult.OK)
            {
                LoadRecipeList();
                this.Hide();
                RecipeChange(_RcpNewNameWnd.NewRecipeName, "[Default]");
                this.Show();
            }

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "RecipeWindow - RecipeAdd Complete", CLogManager.LOG_LEVEL.LOW);

            _RcpNewNameWnd.RecipeCopyEvent -= new RecipeNewNameWindow.RecipeCopyHandler(RecipeCopyEventFunction);
            IsRecipeNew = false;
        }

        private void btnRecipeCopy_Click(object sender, EventArgs e)
        {
            RecipeNewNameWindow _RcpNewNameWnd = new RecipeNewNameWindow();
            _RcpNewNameWnd.RecipeCopyEvent += new RecipeNewNameWindow.RecipeCopyHandler(RecipeCopyEventFunction);

            string[] _RecipeList = new string[listBoxRecipe.Items.Count];
            for (int iLoopCount = 0; iLoopCount < _RecipeList.Count(); ++iLoopCount)
                _RecipeList[iLoopCount] = listBoxRecipe.Items[iLoopCount].ToString();

            if (listBoxRecipe.SelectedIndex == -1) { MessageBox.Show("No recipes selected."); return; }

            _RcpNewNameWnd.SetCurrentRecipe(listBoxRecipe.SelectedItem.ToString(), _RecipeList);
            _RcpNewNameWnd.ShowDialog();

            _RcpNewNameWnd.RecipeCopyEvent -= new RecipeNewNameWindow.RecipeCopyHandler(RecipeCopyEventFunction);
        }

        private void btnRecipeDelete_Click(object sender, EventArgs e)
        {
            if (listBoxRecipe.SelectedItem == null) { MessageBox.Show(new Form { TopMost = true }, "Select recipe to delete."); return; }
            if (CurrentRecipeName == listBoxRecipe.SelectedItem.ToString()) { MessageBox.Show("Unable to delete the recipe being used."); return; }

            string _RecipeFilePath = RecipeFolderPath + listBoxRecipe.SelectedItem.ToString();
            DirectoryInfo _RecipeFolderInfo = new DirectoryInfo(_RecipeFilePath);

            if (_RecipeFolderInfo.Exists)
            {
                DialogResult DeleteResult = MessageBox.Show(new Form { TopMost = true }, "Do you want to delete?", "Message", MessageBoxButtons.YesNo);
                if (DeleteResult == DialogResult.Yes)
                {
                    _RecipeFolderInfo.Delete(true);
                    listBoxRecipe.Items.Remove(listBoxRecipe.SelectedItem);
                }
                else return;
            }

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "RecipeWindow - RecipeDelete Complete : " + listBoxRecipe.SelectedItem, CLogManager.LOG_LEVEL.LOW);

            LoadRecipeList();
        }

        private void textBoxSearchRecipe_TextChanged(object sender, EventArgs e)
        {
            LoadRecipeList(textBoxSearchRecipe.Text);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            textBoxSearchRecipe.Text = "";
            textBoxSearchRecipe.Focus();
            this.Close();
        }
        #endregion Control Event

        private void LoadRecipeList(string _SearchString = "")
        {
            DirectoryInfo _DirInfo = new DirectoryInfo(RecipeFolderPath);
            if (true == _DirInfo.Exists)
            {
                listBoxRecipe.Items.Clear();
                DirectoryInfo[] _DirInfos = _DirInfo.GetDirectories();
                foreach (DirectoryInfo _DInfo in _DirInfos)
                {
                    if (_DInfo.Name == "[Default]") continue;

                    if (_SearchString != "")
                    {
                        if (_DInfo.Name.Contains(_SearchString))
                            listBoxRecipe.Items.Add(_DInfo.Name);
                    }

                    else
                        listBoxRecipe.Items.Add(_DInfo.Name);

                }
            }
            textBoxCurrentRecipe.Text = CurrentRecipeName;
        }

        private void RecipeChange(string _RecipeName, string _SrcRecipeName = "")
        {
            var _RecipeChangeEvent = RecipeChangeEvent;
            if (false == _RecipeChangeEvent?.Invoke(_RecipeName, _SrcRecipeName)) { MessageBox.Show(new Form { TopMost = true }, "Failed to load recipe."); return; }
            CurrentRecipeName = _RecipeName;
            textBoxCurrentRecipe.Text = _RecipeName;
        }

        private void RecipeCopyEventFunction(string _NewRecipeName)
        {
            string _SrcRecipeName;
            if (listBoxRecipe.SelectedItem == null) _SrcRecipeName = "[Default]";
            else                                    _SrcRecipeName = listBoxRecipe.SelectedItem.ToString();

            if (IsRecipeNew) _SrcRecipeName = "[Default]";
            string _NewRecipePath = RecipeFolderPath + _NewRecipeName;
            string _SrcRecipePath = RecipeFolderPath + _SrcRecipeName;

            FileSystem.CopyDirectory(_SrcRecipePath, _NewRecipePath, UIOption.OnlyErrorDialogs);
            DirectoryInfo _CurrentDirInfo = new DirectoryInfo(_NewRecipePath);
            if (false == _CurrentDirInfo.Exists) return;

            DirectoryInfo[] _ModuleFolder = _CurrentDirInfo.GetDirectories();
            foreach (DirectoryInfo _DirInfo in _ModuleFolder)
            {
                FileInfo[] _FileInfo = _DirInfo.GetFiles();
                foreach (FileInfo _FInfo in _FileInfo)
                {
                    if (_FInfo.Extension != ".Rcp") continue;

                    try
                    {
                        XmlDocument _XmlDoc = new XmlDocument();
                        _XmlDoc.Load(_FInfo.FullName);

                        XmlNode _FirstNode = _XmlDoc.DocumentElement;
                        //XmlElement _ModuleNode = (XmlElement)_FirstNode.ChildNodes[0];

                        XmlElement _AreaNode = _XmlDoc.DocumentElement;
                        foreach (XmlElement _Node0 in _AreaNode)
                        {
                            if (false == _Node0.Name.Contains("InspAlgoArea")) continue;
                            XmlElement _ModuleNode = _Node0;

                            foreach (XmlElement _Node in _ModuleNode)
                            {
                                if (false == _Node.Name.Contains("Algo")) continue;
                                XmlElement _Algo = _Node;

                                foreach (XmlElement _Node2 in _Algo)
                                {
                                    if (false == _Node2.Name.Contains("Reference")) continue;
                                    XmlElement _ReferenceData = _Node2;
                                    XmlNode _DeleteNode = _ReferenceData.SelectSingleNode("ReferencePath");

                                    if (_DeleteNode.InnerText != null && _DeleteNode.InnerText != "")
                                    {
                                        string _ReferencePath = _DeleteNode.InnerText;
                                        string[] _ReferencePaths = _ReferencePath.Split('\\');
                                        _ReferencePaths[4] = _NewRecipeName;
                                        _ReferencePath = String.Join("\\", _ReferencePaths);
                                        _ReferenceData.RemoveChild(_DeleteNode);
                                        _ReferenceData.AppendChild(CreateNode(_XmlDoc, "ReferencePath", _ReferencePath));
                                    }
                                }
                            }
                        }
                        _XmlDoc.Save(_FInfo.FullName);
                    }

                    catch(System.Exception ex)
                    {
                        CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "RecipeCopyEventFunction Exception : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
                    }
                }
            }

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "RecipeWindow - RecipeCopy Complete", CLogManager.LOG_LEVEL.LOW);

            RecipeChange(_NewRecipeName, _SrcRecipeName);
            LoadRecipeList();
        }

        private XmlNode CreateNode(XmlDocument xmlDoc, string name, string innerXml)
        {
            XmlNode node = xmlDoc.CreateElement(string.Empty, name, string.Empty);
            node.InnerXml = innerXml;
            return node;
        }
    }
}
