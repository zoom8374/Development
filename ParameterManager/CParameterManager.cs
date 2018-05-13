using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ParameterManager
{
    public class CParameterManager
    {
        public SystemParameter                      SystemParam;
        public InspectionParameter[]                InspParam;
        public InspectionSystemManagerParameter[]   InspSysManagerParam;

        private string ProjectName;
        private string InspectionDefaultPath;
        private string ISMParameterFullPath;
        private string RecipeParameterPath;
        private string SystemParameterFullPath;

        #region Initialize & DeInitialize
        public CParameterManager()
        {
            SystemParam = new SystemParameter();

            ProjectName             = "CIPOSLeadInspection";
            InspectionDefaultPath   = @"D:\VisionInspectionData\" + ProjectName + @"\";
            ISMParameterFullPath    = @"D:\VisionInspectionData\" + ProjectName + @"\RecipeParameter\Default\ISMParameter1.Sys";

            RecipeParameterPath     = InspectionDefaultPath + @"RecipeParameter\";
            SystemParameterFullPath = InspectionDefaultPath + @"SystemParameter.Sys";
        }

        public bool Initialize(string _ProjectName)
        {
            bool _Result = false;

            ProjectName = _ProjectName;

            do
            {
                if (false == ReadSystemParameter()) break;
                if (false == ReadISMParameters())   break;
                SystemParam.IsProgramUsable = true;

                _Result = true;
            } while (false);

            return _Result;
        }

        public void DeInitialize()
        {
            WriteSystemParameter();

            for (int iLoopCount = 0; iLoopCount < SystemParam.InspSystemManagerCount; ++iLoopCount)
                WriteISMParameter(iLoopCount);
        }
        #endregion Initialize & DeInitialize

        #region Read & Write SystemParameter
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
            }

            return _XmlNodeList;
        }

        public bool ReadSystemParameter()
        {
            bool _Result = true;

            try
            {
                DirectoryInfo _DirInfo = new DirectoryInfo(InspectionDefaultPath);
                if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }
                if (false == File.Exists(SystemParameterFullPath))
                {
                    File.Create(SystemParameterFullPath).Close();
                    WriteSystemParameter();
                    System.Threading.Thread.Sleep(100);
                }

                XmlNodeList _XmlNodeList = GetNodeList(SystemParameterFullPath);
                if (null == _XmlNodeList) return false;
                foreach (XmlNode _Node in _XmlNodeList)
                {
                    if (null == _Node) return false;
                    switch (_Node.Name)
                    {
                        case "MachineID":       SystemParam.MachineNumber = Convert.ToInt32(_Node.InnerText); break;
                        case "SimulationMode":  SystemParam.IsSimulationMode = Convert.ToBoolean(_Node.InnerText); break;
                        case "LastRecipeName":  SystemParam.LastRecipeName = _Node.InnerText; break;
                        case "ISMModuleCount":  SystemParam.InspSystemManagerCount = Convert.ToInt32(_Node.InnerText); break;
                        case "ProjectType":     SystemParam.ProjectType = Convert.ToInt32(_Node.InnerText); break;
                        case "ProjectItem":     SystemParam.ProjectItem = Convert.ToInt32(_Node.InnerText); break;
                        case "IPAddress":       SystemParam.IPAddress = _Node.InnerText; break;
                        case "PortNumber":      SystemParam.PortNumber = Convert.ToInt32(_Node.InnerText); break;
                    }
                }
            }

            catch
            {
                _Result = false;
            }

            return _Result;
        }

        public void WriteSystemParameter()
        {
            DirectoryInfo _DirInfo = new DirectoryInfo(InspectionDefaultPath);
            if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }

            #region XML Element Define
            XElement _SystemParameter        = new XElement("SystemParameter");
            XElement _MachineID              = new XElement("MachineID", SystemParam.MachineNumber.ToString());
            XElement _SimulationMode         = new XElement("SimulationMode", SystemParam.IsSimulationMode.ToString());
            XElement _LastRecipeName         = new XElement("LastRecipeName", SystemParam.LastRecipeName);
            XElement _InspSystemManagerCount = new XElement("ISMModuleCount", SystemParam.InspSystemManagerCount.ToString());
            XElement _ProjectType            = new XElement("ProjectType", SystemParam.ProjectType.ToString());
            XElement _ProjectItem            = new XElement("ProjectItem", SystemParam.ProjectItem.ToString());
            XElement _IPAddress              = new XElement("IPAddress", SystemParam.IPAddress);
            XElement _PortNumber             = new XElement("PortNumber", SystemParam.PortNumber.ToString());
            #endregion XML Element Define

            #region XML Tree ADD
            _SystemParameter.Add(_MachineID);
            _SystemParameter.Add(_SimulationMode);
            _SystemParameter.Add(_LastRecipeName);
            _SystemParameter.Add(_InspSystemManagerCount);
            _SystemParameter.Add(_ProjectType);
            _SystemParameter.Add(_ProjectItem);
            _SystemParameter.Add(_IPAddress);
            _SystemParameter.Add(_PortNumber);
            _SystemParameter.Save(SystemParameterFullPath);
            #endregion XML Tree ADD
        }
        #endregion Read & Write SystemParameter

        #region Read & Write Inspection System Manager
        public bool ReadISMParameters()
        {
            bool _Result = true;

            InspSysManagerParam = new InspectionSystemManagerParameter[SystemParam.InspSystemManagerCount];
            for (int iLoopCount = 0; iLoopCount < SystemParam.InspSystemManagerCount; ++iLoopCount)
            {
                InspSysManagerParam[iLoopCount] = new InspectionSystemManagerParameter();
                if (false == ReadISMParameter(iLoopCount)) { _Result = false; break; }
            }

            return _Result;
        }

        public bool ReadISMParameter(int _ID)
        {   
            bool _Result = true;

            try
            {
                ISMParameterFullPath = String.Format(@"{0}{1}\ISMParameter{2}.Sys", RecipeParameterPath, SystemParam.LastRecipeName, (_ID + 1));

                DirectoryInfo _DirInfo = new DirectoryInfo(RecipeParameterPath + SystemParam.LastRecipeName);
                if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }
                if (false == File.Exists(ISMParameterFullPath))
                {
                    File.Create(ISMParameterFullPath).Close();
                    WriteISMParameter(_ID);
                    System.Threading.Thread.Sleep(100);
                }

                XmlNodeList _XmlNodeList = GetNodeList(ISMParameterFullPath);
                if (null == _XmlNodeList) return false;
                foreach (XmlNode _Node in _XmlNodeList)
                {
                    if (null == _Node) return false;
                    switch (_Node.Name)
                    {
                        case "ProjectItem":      InspSysManagerParam[_ID].ProjectItem = Convert.ToInt32(_Node.InnerText); break;
                        case "CameraCount":      InspSysManagerParam[_ID].CameraCount = Convert.ToInt32(_Node.InnerText); break;
                        case "CameraType":       InspSysManagerParam[_ID].CameraType = _Node.InnerText; break;
                        case "CameraName":       InspSysManagerParam[_ID].CameraName = _Node.InnerText; break;
                        case "CameraConfigInfo": InspSysManagerParam[_ID].CameraConfigInfo = _Node.InnerText; break;
                        case "CameraRotate":     InspSysManagerParam[_ID].CameraRotate = Convert.ToInt32(_Node.InnerText); break;
                        case "CameraVerFlip":    InspSysManagerParam[_ID].IsCameraVerFlip = Convert.ToBoolean(_Node.InnerText); break;
                        case "CameraHorFlip":    InspSysManagerParam[_ID].IsCameraHorFlip = Convert.ToBoolean(_Node.InnerText); break;
                        case "ImageSizeWidth":   InspSysManagerParam[_ID].ImageSizeWidth = Convert.ToInt32(_Node.InnerText); break;
                        case "ImageSizeHeight":  InspSysManagerParam[_ID].ImageSizeHeight = Convert.ToInt32(_Node.InnerText); break;
                        case "ResolutionX":      InspSysManagerParam[_ID].ResolutionX = Convert.ToDouble(_Node.InnerText); break;
                        case "ResolutionY":      InspSysManagerParam[_ID].ResolutionY = Convert.ToDouble(_Node.InnerText); break;

                        case "DispWindowZoom":      InspSysManagerParam[_ID].InspWndParam.DisplayZoomValue = Convert.ToDouble(_Node.InnerText); break;
                        case "DispWindowPanX":      InspSysManagerParam[_ID].InspWndParam.DisplayPanXValue = Convert.ToDouble(_Node.InnerText); break;
                        case "DispWindowPanY":      InspSysManagerParam[_ID].InspWndParam.DisplayPanYValue = Convert.ToDouble(_Node.InnerText); break;
                        case "InspWindowLocationX": InspSysManagerParam[_ID].InspWndParam.LocationX = Convert.ToInt32(_Node.InnerText); break;
                        case "InspWindowLocationY": InspSysManagerParam[_ID].InspWndParam.LocationY = Convert.ToInt32(_Node.InnerText); break;
                        case "InspWindowWidth":     InspSysManagerParam[_ID].InspWndParam.Width = Convert.ToInt32(_Node.InnerText); break;
                        case "InspWindowHeight":    InspSysManagerParam[_ID].InspWndParam.Height = Convert.ToInt32(_Node.InnerText); break;
                    }
                }
            }

            catch
            {
                _Result = false;
            }

            return _Result;
        }

        public void WriteISMParameter(int _ID, string _RecipeName = null)
        {
            if (null == _RecipeName) _RecipeName = SystemParam.LastRecipeName;
            DirectoryInfo _DirInfo = new DirectoryInfo(RecipeParameterPath);
            if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }

            ISMParameterFullPath = String.Format(@"{0}{1}\ISMParameter{2}.Sys", RecipeParameterPath, SystemParam.LastRecipeName, (_ID + 1));

            #region XML Element Define
            XElement _ISMParameter      = new XElement("ISMParameter");
            XElement _ProjectItem       = new XElement("ProjectItem", InspSysManagerParam[_ID].ProjectItem);
            XElement _CameraCount       = new XElement("CameraCount", InspSysManagerParam[_ID].CameraCount);
            XElement _CameraType        = new XElement("CameraType", InspSysManagerParam[_ID].CameraType);
            XElement _CameraName        = new XElement("CameraName", InspSysManagerParam[_ID].CameraName);
            XElement _CameraConfigInfo  = new XElement("CameraConfigInfo", InspSysManagerParam[_ID].CameraConfigInfo);
            XElement _CameraRotate      = new XElement("CameraRotate", InspSysManagerParam[_ID].CameraRotate);
            XElement _CameraVerFlip     = new XElement("CameraVerFlip", InspSysManagerParam[_ID].IsCameraVerFlip);
            XElement _CameraHorFlip     = new XElement("CameraHorFlip", InspSysManagerParam[_ID].IsCameraVerFlip);
            XElement _ImageSizeWidth    = new XElement("ImageSizeWidth", InspSysManagerParam[_ID].ImageSizeWidth);
            XElement _ImageSizeHeight   = new XElement("ImageSizeHeight", InspSysManagerParam[_ID].ImageSizeHeight);
            XElement _ResolutionX       = new XElement("ResolutionX", InspSysManagerParam[_ID].ResolutionX);
            XElement _ResolutionY       = new XElement("ResolutionY", InspSysManagerParam[_ID].ResolutionY);
            XElement _InspWndZoom           = new XElement("InspWindowZoom", InspSysManagerParam[_ID].InspWndParam.DisplayZoomValue);
            XElement _InspWindowPanX        = new XElement("InspWindowPanX", InspSysManagerParam[_ID].InspWndParam.DisplayPanXValue);
            XElement _InspWindowPanY        = new XElement("InspWindowPanY", InspSysManagerParam[_ID].InspWndParam.DisplayPanYValue);
            XElement _InspWindowLocationX   = new XElement("InspWindowLocationX", InspSysManagerParam[_ID].InspWndParam.LocationX);
            XElement _InspWindowLocationY   = new XElement("InspWindowLocationY", InspSysManagerParam[_ID].InspWndParam.LocationY);
            XElement _InspWindowWidth       = new XElement("InspWindowWidth", InspSysManagerParam[_ID].InspWndParam.Width);
            XElement _InspWindowHeight      = new XElement("InspWindowHeight", InspSysManagerParam[_ID].InspWndParam.Height);
            #endregion XML Element Define

            #region XML Tree Add
            _ISMParameter.Add(_ProjectItem);
            _ISMParameter.Add(_CameraCount);
            _ISMParameter.Add(_CameraType);
            _ISMParameter.Add(_CameraName);
            _ISMParameter.Add(_CameraConfigInfo);
            _ISMParameter.Add(_CameraRotate);
            _ISMParameter.Add(_CameraVerFlip);
            _ISMParameter.Add(_CameraHorFlip);
            _ISMParameter.Add(_ImageSizeWidth);
            _ISMParameter.Add(_ImageSizeHeight);
            _ISMParameter.Add(_ResolutionX);
            _ISMParameter.Add(_ResolutionY);
            _ISMParameter.Add(_InspWndZoom);
            _ISMParameter.Add(_InspWindowPanX);
            _ISMParameter.Add(_InspWindowPanY);
            _ISMParameter.Add(_InspWindowLocationX);
            _ISMParameter.Add(_InspWindowLocationY);
            _ISMParameter.Add(_InspWindowWidth);
            _ISMParameter.Add(_InspWindowHeight);
            _ISMParameter.Save(ISMParameterFullPath);
            #endregion XML Tree Add
        }
        #endregion Read & Write Inspection System Manager
    }
}
