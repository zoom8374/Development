using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Collections;
using Microsoft.VisualBasic.FileIO;

using LogMessageManager;

enum eLightControllerType { Normal, JV501, JV504 }
namespace LightManager
{
    public class CLightManager
    {
        private LightParameter LightParam;
        private LightWindow LightWnd;
        private bool IsSimulationMode;
        public bool IsShowWindow = false;

        // LDH, 각 COM 번호에 해당하는 TotalLight가 생성된 번호를 담는다
        private int[] ComportNum = new int[15];

        private List<object> LightControlList = new List<object>();

        private string LightParameterFolderPath;
        private string LightParameterFullPath;

        public CLightManager()
        {
            LightParam = new LightParameter();
            LightWnd = new LightWindow();          
        }

        public void Initialize(string RecipeName, bool _IsSimulationMode)
        {
            IsSimulationMode = _IsSimulationMode;

            LightParameterFolderPath = ".\\Common\\" + "LightParameter";
            LightParameterFullPath = LightParameterFolderPath + "\\" + RecipeName + ".sys";
            ReadLightParameters();

            if (false == IsSimulationMode)
            {
                CheckComportNum();
                SetLightParam();
                LightWnd.SetLightCommandEvent += new LightWindow.SetLightCommandHandler(SetLightCommand);
            }

            SetLightWindow();
        }

        public void DeInitialize()
        {
            LightWnd.SetLightCommandEvent -= new LightWindow.SetLightCommandHandler(SetLightCommand);

            for (int iLoopCount = 0; iLoopCount < LightControlList.Count; iLoopCount++)
            {
                switch ((eLightControllerType)LightParam.ControllerType[iLoopCount])
                {
                    case eLightControllerType.Normal:
                        {
                            var ControlTemp = LightControlList[iLoopCount] as LightController;

                            ControlTemp.SetCommand(LightCommand.LightAllOff);
                            ControlTemp.DeInitialize();
                        }
                        break;

                    case eLightControllerType.JV501:
                        {
                            var ControlTemp = LightControlList[iLoopCount] as JV501Controller;

                            ControlTemp.SetCommand(LightCommand.LightAllOff);
                            ControlTemp.DeInitialize();
                        }
                        break;
                }
            }

            LightWnd.DeInitialize();
        }

        private void SetLightParam()
        {
            for (int iLoopCount = 0; iLoopCount < LightParam.LightCount; iLoopCount++)
            {
                int SelectLight = ComportNum[LightParam.ComportNum[iLoopCount]];

                switch ((eLightControllerType)LightParam.ControllerType[iLoopCount])
                {
                    case eLightControllerType.Normal:
                        {
                            var ControlTemp = LightControlList[SelectLight] as LightController;

                            ControlTemp.SetLightChannel(LightParam.LightChannel[iLoopCount]);
                            ControlTemp.SetLightValue(LightParam.LightValues[iLoopCount]);
                        }
                        break;

                    case eLightControllerType.JV501:
                        {
                            var ControlTemp = LightControlList[SelectLight] as JV501Controller;

                            ControlTemp.SetLightChannel(LightParam.LightChannel[iLoopCount]);
                            ControlTemp.SetLightValue(LightParam.LightValues[iLoopCount]);
                            System.Threading.Thread.Sleep(50);
                            ControlTemp.SetCommand(LightCommand.LightAllOff);
                        }
                        break;
                }
            }
        }

        private void SetLightWindow()
        {
            if((eLightControllerType)LightParam.ControllerType[0] == eLightControllerType.Normal) LightWnd.Initialize(LightParam.LightValues, 2500);
            else LightWnd.Initialize(LightParam.LightValues);
        }

        public void ShowLightWindow()
        {
            LightWnd.TopMost = true;
            IsShowWindow = true;
            LightWnd.Show();
        }

        public void RecipeChange(string _RecipeName, string _SrcRecipeName)
        {
            LightParameterFullPath = LightParameterFolderPath + "\\" + _RecipeName + ".sys";

            if (_SrcRecipeName != "") CopyLightParameter(_RecipeName, _SrcRecipeName);
            ReadLightParameters();

            if (false == IsSimulationMode) SetLightParam();
            SetLightWindow();
        }

        private void CheckComportNum()
        {
            List<int> ComportNumList = new List<int>();

            for (int iLoopCount = 0; iLoopCount < LightParam.LightCount; iLoopCount++)
            {
                if (ComportNumList.Count == 0 || !ComportNumList.Contains(LightParam.ComportNum[iLoopCount]))
                {
                    ComportNumList.Add(LightParam.ComportNum[iLoopCount]);

                    switch ((eLightControllerType)LightParam.ControllerType[iLoopCount])
                    {
                        case eLightControllerType.Normal:
                            {
                                LightController NormalControl = new LightController();
                                NormalControl.Initialize("COM" + LightParam.ComportNum[iLoopCount].ToString());

                                LightControlList.Add(NormalControl);
                                ComportNum[LightParam.ComportNum[iLoopCount]] = LightControlList.Count - 1;
                            }
                            break;

                        case eLightControllerType.JV501:
                            {
                                JV501Controller JVControl = new JV501Controller();
                                JVControl.Initialize("COM" + LightParam.ComportNum[iLoopCount].ToString());

                                LightControlList.Add(JVControl);
                                ComportNum[LightParam.ComportNum[iLoopCount]] = LightControlList.Count - 1;
                            }
                            break;
                    }
                }
            }
        }

        private void SetLightCommand(int _LightNum, LightCommand _Command, int _LightValue = 0)
        {
            int SelectLightNum = ComportNum[LightParam.ComportNum[_LightNum]];

            if(_Command == LightCommand.SaveValue)
            {
                LightParam.LightValues[_LightNum] = _LightValue;
                WriteLightParameter();
            }

            switch ((eLightControllerType)LightParam.ControllerType[_LightNum])
            {
                case eLightControllerType.Normal:
                    {
                        var ControlTemp = LightControlList[SelectLightNum] as LightController;

                        ControlTemp.SetLightChannel(LightParam.LightChannel[_LightNum]);
                        if (_LightValue != 0) ControlTemp.SetLightValue(_LightValue);
                        if (_LightValue != 0) ControlTemp.SetLightValue(LightParam.LightValues);
                        ControlTemp.SetCommand(_Command);
                    }
                    break;
                case eLightControllerType.JV501:
                    {
                        var ControlTemp = LightControlList[SelectLightNum] as JV501Controller;

                        ControlTemp.SetLightChannel(LightParam.LightChannel[_LightNum]);
                        if (_LightValue != 0) ControlTemp.SetLightValue(_LightValue);
                        ControlTemp.SetCommand(_Command);
                    }
                    break;
            }
        }

        #region Read & Write Light Parameter
        public bool ReadLightParameters()
        {
            bool _Result = true;

            LightParam = new LightParameter();

            try
            {                
                DirectoryInfo _DirInfo = new DirectoryInfo(LightParameterFolderPath);
                if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }
                if (false == File.Exists(LightParameterFullPath))
                {
                    File.Create(LightParameterFullPath).Close();
                    WriteLightParameter();
                    System.Threading.Thread.Sleep(100);
                }

                XmlNodeList _XmlNodeList = GetNodeList(LightParameterFullPath);
                if (null == _XmlNodeList) return false;
                foreach (XmlNode _Node in _XmlNodeList)
                {
                    if (null == _Node) return false;

                    if ("LightCount" == _Node.Name.ToString()) LightParam.LightCount = Convert.ToInt32(_Node.InnerText);
                    GetLightValuesParameter(_Node, ref LightParam);
                }
            }

            catch
            {
                _Result = false;
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "ReadLightParameters Exception!!", CLogManager.LOG_LEVEL.LOW);
            }

            return _Result;
        }

        private XmlNodeList GetNodeList(string _XmlFilePath)
        {
            XmlNodeList _XmlNodeList = null;

            try
            {
                XmlDocument _XmlDocument = new XmlDocument();
                _XmlDocument.Load(_XmlFilePath);
                XmlElement _XmlRoot = _XmlDocument.DocumentElement;
                _XmlNodeList = _XmlRoot.ChildNodes;
            }

            catch
            {
                _XmlNodeList = null;
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "CLightManager - GetNodeList Exception!!", CLogManager.LOG_LEVEL.LOW);
            }

            return _XmlNodeList;
        }

        private void GetLightValuesParameter(XmlNode _Nodes, ref LightParameter _LightParam)
        {
            if (null == _Nodes) return;

            _LightParam.ComportNum = new int[_LightParam.LightCount];
            _LightParam.ControllerType = new int[_LightParam.LightCount];
            _LightParam.LightChannel = new int[_LightParam.LightCount];
            _LightParam.LightValues = new int[_LightParam.LightCount];

            for (int iLoopCount = 0; iLoopCount < _LightParam.LightCount; iLoopCount++)
            {
                string _NodeName = String.Format("Light{0}", iLoopCount + 1);
                XmlNode _Node = _Nodes[_NodeName];
                if (null == _Node) break;

                foreach (XmlNode _NodeChild in _Node.ChildNodes)
                {
                    switch (_NodeChild.Name)
                    {
                        case "ComportNum": _LightParam.ComportNum[iLoopCount] = Convert.ToInt32(_NodeChild.InnerText); break;
                        case "Controller": _LightParam.ControllerType[iLoopCount] = Convert.ToInt32(_NodeChild.InnerText); break;
                        case "LightChannel": _LightParam.LightChannel[iLoopCount] = Convert.ToInt32(_NodeChild.InnerText); break;
                        case "LightValues": _LightParam.LightValues[iLoopCount] = Convert.ToInt32(_NodeChild.InnerText); break;
                    }
                }
            }
        }

        public void WriteLightParameter()
        {
            DirectoryInfo _DirInfo = new DirectoryInfo(LightParameterFolderPath);
            if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }

            XmlTextWriter _XmlWriter = new XmlTextWriter(LightParameterFullPath, Encoding.Unicode);
            _XmlWriter.Formatting = Formatting.Indented;
            _XmlWriter.WriteStartDocument();
            _XmlWriter.WriteStartElement("LightParameter");
            {
                _XmlWriter.WriteElementString("LightCount", LightParam.LightCount.ToString());
                _XmlWriter.WriteStartElement("LightOption");
                {
                    for (int iLoopCount = 0; iLoopCount < LightParam.LightCount; ++iLoopCount)
                    {
                        _XmlWriter.WriteStartElement(String.Format("Light{0}", iLoopCount + 1));
                        _XmlWriter.WriteElementString("ComportNum", LightParam.ComportNum[iLoopCount].ToString());
                        _XmlWriter.WriteElementString("Controller", LightParam.ControllerType[iLoopCount].ToString());
                        _XmlWriter.WriteElementString("LightChannel", LightParam.LightChannel[iLoopCount].ToString());
                        _XmlWriter.WriteElementString("LightValues", LightParam.LightValues[iLoopCount].ToString());
                        _XmlWriter.WriteEndElement();
                    }
                }
                _XmlWriter.WriteEndElement();
            }
            _XmlWriter.WriteEndElement();
            _XmlWriter.WriteEndDocument();
            _XmlWriter.Close();
        }

        public void CopyLightParameter(string _NewRecipeName, string _SrcRecipeName)
        {
            string _NewRecipePath = LightParameterFolderPath + "\\" + _NewRecipeName + ".sys";
            string _SrcRecipePath = LightParameterFolderPath + "\\" + _SrcRecipeName + ".sys";

            FileInfo CopyFile = new FileInfo(_SrcRecipePath);

            if (!CopyFile.Exists) return;

            try
            {
                CopyFile.CopyTo(_NewRecipePath);
            }
            catch
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "CopyLightParameter Exception!!", CLogManager.LOG_LEVEL.LOW);
            }


        }
        #endregion Read & Write Light Parameter

        public void LightControl(int _LightNum, bool _IsLightOn)
        {
            if (_IsLightOn == true) SetLightCommand(_LightNum, LightCommand.LightOn);
            else                    SetLightCommand(_LightNum, LightCommand.LightOff);

            //switch ((eLightControllerType)LightParam.ControllerType[_LightNum])
            //{
            //    case eLightControllerType.Normal:
            //        break;

                //    case eLightControllerType.JV501:
                //        var ControlTemp = LightControlList[_LightNum] as JV501Controller;
                //        ControlTemp.SetCommand(LightCommand.LightOn);
                //        break;
                //}


                //switch ((eLightControllerType)LightParam.ControllerType[_LightNum])
                //{
                //    case eLightControllerType.Normal:
                //        {
                //            var ControlTemp = LightControlList[SelectLightNum] as LightController;

                //            ControlTemp.SetLightChannel(LightParam.LightChannel[_LightNum]);
                //            ControlTemp.SetLightValue(_LightValue);
                //            ControlTemp.SetLightValue(LightParam.LightValues);
                //            ControlTemp.SetCommand(_Command);
                //        }
                //        break;
                //    case eLightControllerType.JV501:
                //        {
                //            //var ControlTemp = LightControlList[_LightNum] as JV501Controller;
                //            var ControlTemp = LightControlList[SelectLightNum] as JV501Controller;

                //            ControlTemp.SetLightChannel(LightParam.LightChannel[_LightNum]);
                //            ControlTemp.SetLightValue(_LightValue);
                //            ControlTemp.SetCommand(_Command);
                //        }
                //        break;
                //}
        }

        public void AllLightOff()
        {

        }
    }
}
