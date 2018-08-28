using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;

using LogMessageManager;

namespace ParameterManager
{
    public class CParameterManager
    {
        public SystemParameter                      SystemParam;
        public InspectionParameter[]                InspParam;
        public InspectionSystemManagerParameter[]   InspSysManagerParam;

        public static eSysMode SystemMode;

        private string ProjectName;
        private string InspectionDefaultPath;
        private string ISMParameterFullPath;
        private string ProjectItemParameterFullPath;
        private string RecipeParameterPath;
        private string SystemParameterFullPath;

        private int AlgoNumber = 1;
        private int AreaNumber = 1;

        #region Initialize & DeInitialize
        public CParameterManager()
        {
            SystemMode = eSysMode.MANUAL_MODE;
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
                if (false == ReadProjectItemParameters()) break;
                if (false == ReadInspectionParameters()) break;
                SystemParam.IsProgramUsable = true;

                _Result = true;
            } while (false);

            return _Result;
        }

        public void RecipeReload(string _RecipeName)
        {
            SystemParam.LastRecipeName = _RecipeName;
            ReadInspectionParameters();
        }

        public void DeInitialize()
        {
            WriteSystemParameter();

            for (int iLoopCount = 0; iLoopCount < SystemParam.InspSystemManagerCount; ++iLoopCount)
                WriteISMParameter(iLoopCount);

            for (int iLoopCount = 0; iLoopCount < SystemParam.InspSystemManagerCount; ++iLoopCount)
                WriteProjectItemParameter(iLoopCount);
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

            catch(System.Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "GetNodeList Exception : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
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
                        case "MachineID":        SystemParam.MachineNumber = Convert.ToInt32(_Node.InnerText); break;
                        case "SimulationMode":   SystemParam.IsSimulationMode = Convert.ToBoolean(_Node.InnerText); break;
                        case "LastRecipeName":   SystemParam.LastRecipeName = _Node.InnerText; break;
                        case "ISMModuleCount":   SystemParam.InspSystemManagerCount = Convert.ToInt32(_Node.InnerText); break;
                        case "ResultWndLocateX": SystemParam.ResultWindowLocationX = Convert.ToInt32(_Node.InnerText); break;
                        case "ResultWndLocateY": SystemParam.ResultWindowLocationY = Convert.ToInt32(_Node.InnerText); break;
                        case "ResultWndWidth":   SystemParam.ResultWindowWidth = Convert.ToInt32(_Node.InnerText); break;
                        case "ResultWndHeight":  SystemParam.ResultWindowHeight = Convert.ToInt32(_Node.InnerText); break;
                        case "ProjectType":      SystemParam.ProjectType = Convert.ToInt32(_Node.InnerText); break;
                        case "IPAddress":        SystemParam.IPAddress = _Node.InnerText; break;
                        case "PortNumber":       SystemParam.PortNumber = Convert.ToInt32(_Node.InnerText); break;
                    }
                }
            }

            catch(System.Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "ReadSystemParameter Exception : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
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
            XElement _ResultWndLocateX       = new XElement("ResultWndLocateX", SystemParam.ResultWindowLocationX.ToString());
            XElement _ResultWndLocateY       = new XElement("ResultWndLocateY", SystemParam.ResultWindowLocationY.ToString());
            XElement _ResultWndWidth         = new XElement("ResultWndWidth", SystemParam.ResultWindowWidth.ToString());
            XElement _ResultWndHeight        = new XElement("ResultWndHeight", SystemParam.ResultWindowHeight.ToString());
            XElement _ProjectType            = new XElement("ProjectType", SystemParam.ProjectType.ToString());
            XElement _IPAddress              = new XElement("IPAddress", SystemParam.IPAddress);
            XElement _PortNumber             = new XElement("PortNumber", SystemParam.PortNumber.ToString());
            #endregion XML Element Define

            #region XML Tree ADD
            _SystemParameter.Add(_MachineID);
            _SystemParameter.Add(_SimulationMode);
            _SystemParameter.Add(_LastRecipeName);
            _SystemParameter.Add(_InspSystemManagerCount);
            _SystemParameter.Add(_ResultWndLocateX);
            _SystemParameter.Add(_ResultWndLocateY);
            _SystemParameter.Add(_ResultWndWidth);
            _SystemParameter.Add(_ResultWndHeight);
            _SystemParameter.Add(_ProjectType);
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
                        case "InspWindowZoom":      InspSysManagerParam[_ID].InspWndParam.DisplayZoomValue = Convert.ToDouble(_Node.InnerText); break;
                        case "InspWindowPanX":      InspSysManagerParam[_ID].InspWndParam.DisplayPanXValue = Convert.ToDouble(_Node.InnerText); break;
                        case "InspWindowPanY":      InspSysManagerParam[_ID].InspWndParam.DisplayPanYValue = Convert.ToDouble(_Node.InnerText); break;
                        case "InspWindowLocationX": InspSysManagerParam[_ID].InspWndParam.LocationX = Convert.ToInt32(_Node.InnerText); break;
                        case "InspWindowLocationY": InspSysManagerParam[_ID].InspWndParam.LocationY = Convert.ToInt32(_Node.InnerText); break;
                        case "InspWindowWidth":     InspSysManagerParam[_ID].InspWndParam.Width = Convert.ToInt32(_Node.InnerText); break;
                        case "InspWindowHeight":    InspSysManagerParam[_ID].InspWndParam.Height = Convert.ToInt32(_Node.InnerText); break;
                    }
                }
            }

            catch(System.Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "ReadISMParameter Exception : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
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
            XmlTextWriter _XmlWriter = new XmlTextWriter(ISMParameterFullPath, Encoding.Unicode);
            _XmlWriter.Formatting = Formatting.Indented;
            _XmlWriter.WriteStartDocument();
            _XmlWriter.WriteStartElement("ISMParameter");
            {
                _XmlWriter.WriteElementString("ProjectItem", InspSysManagerParam[_ID].ProjectItem.ToString());
                _XmlWriter.WriteElementString("CameraCount", InspSysManagerParam[_ID].CameraCount.ToString());
                _XmlWriter.WriteElementString("CameraType", InspSysManagerParam[_ID].CameraType.ToString());
                _XmlWriter.WriteElementString("CameraName", InspSysManagerParam[_ID].CameraName);
                _XmlWriter.WriteElementString("CameraConfigInfo", InspSysManagerParam[_ID].CameraConfigInfo);
                _XmlWriter.WriteElementString("CameraRotate", InspSysManagerParam[_ID].CameraRotate.ToString());
                _XmlWriter.WriteElementString("CameraVerFlip", InspSysManagerParam[_ID].IsCameraVerFlip.ToString());
                _XmlWriter.WriteElementString("CameraHorFlip", InspSysManagerParam[_ID].IsCameraHorFlip.ToString());
                _XmlWriter.WriteElementString("ImageSizeWidth", InspSysManagerParam[_ID].ImageSizeWidth.ToString());
                _XmlWriter.WriteElementString("ImageSizeHeight", InspSysManagerParam[_ID].ImageSizeHeight.ToString());
                _XmlWriter.WriteElementString("ResolutionX", InspSysManagerParam[_ID].ResolutionX.ToString());
                _XmlWriter.WriteElementString("ResolutionY", InspSysManagerParam[_ID].ResolutionY.ToString());
                _XmlWriter.WriteElementString("InspWindowZoom", InspSysManagerParam[_ID].InspWndParam.DisplayZoomValue.ToString());
                _XmlWriter.WriteElementString("InspWindowPanX", InspSysManagerParam[_ID].InspWndParam.DisplayPanXValue.ToString());
                _XmlWriter.WriteElementString("InspWindowPanY", InspSysManagerParam[_ID].InspWndParam.DisplayPanYValue.ToString());
                _XmlWriter.WriteElementString("InspWindowLocationX", InspSysManagerParam[_ID].InspWndParam.LocationX.ToString());
                _XmlWriter.WriteElementString("InspWindowLocationY", InspSysManagerParam[_ID].InspWndParam.LocationY.ToString());
                _XmlWriter.WriteElementString("InspWindowWidth", InspSysManagerParam[_ID].InspWndParam.Width.ToString());
                _XmlWriter.WriteElementString("InspWindowHeight", InspSysManagerParam[_ID].InspWndParam.Height.ToString());
            }
            _XmlWriter.WriteEndElement();
            _XmlWriter.WriteEndDocument();
            _XmlWriter.Close();
        }
        #endregion Read & Write Inspection System Manager

        #region Read & Write Project Item Parameter
        public bool ReadProjectItemParameters()
        {
            bool _Result = true;

            for (int iLoopCount = 0; iLoopCount < InspSysManagerParam.Length; ++iLoopCount)
            {
                if (false == ReadProjectItemParameter(iLoopCount)) { _Result = false; break; }
            }

            return _Result;
        }

        public bool ReadProjectItemParameter(int _ID)
        {
            bool _Result = true;

            try
            {
                ProjectItemParameterFullPath = String.Format(@"{0}{1}\ProjectItemParameter{2}.Sys", RecipeParameterPath, SystemParam.LastRecipeName, (_ID + 1));

                DirectoryInfo _DirInfo = new DirectoryInfo(RecipeParameterPath + SystemParam.LastRecipeName);
                if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }
                if (false == File.Exists(ProjectItemParameterFullPath))
                {
                    File.Create(ProjectItemParameterFullPath).Close();
                    WriteProjectItemParameter(_ID);
                    System.Threading.Thread.Sleep(100);
                }

                XmlNodeList _XmlNodeList = GetNodeList(ISMParameterFullPath);
                if (null == _XmlNodeList) return false;
                foreach (XmlNode _Node in _XmlNodeList)
                {
                    if (null == _Node) return false;
                    if (InspSysManagerParam[_ID].ProjectItem == (int)eProjectItem.NEEDLE_ALIGN)
                    {
                        AlignProjectParameter _AlignParam = InspSysManagerParam[_ID].ProjectItemParam as AlignProjectParameter;
                        switch (_Node.Name)
                        {
                            case "OriginX":      _AlignParam.OriginX = Convert.ToDouble(_Node.InnerText);       break;
                            case "OriginY":      _AlignParam.OriginY = Convert.ToDouble(_Node.InnerText);       break;
                            case "OriginRadius": _AlignParam.OriginRadius = Convert.ToDouble(_Node.InnerText);  break;
                        }
                    }

                    else if (InspSysManagerParam[_ID].ProjectItem == (int)eProjectItem.NEEDLE_ALIGN)
                    {
                        LeadProjectParameter _LeadParam = InspSysManagerParam[_ID].ProjectItemParam as LeadProjectParameter;
                        switch (_Node.Name)
                        {
                            case "LeadCount": _LeadParam.LeadCount = Convert.ToInt32(_Node.InnerText); break;
                        }
                    }
                }
            }

            catch(System.Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "ReadProjectItemParameter Exception : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
                _Result = false;
            }

            return _Result;
        }

        public void WriteProjectItemParameter(int _ID, string _RecipeName = null)
        {
            if (null == _RecipeName) _RecipeName = SystemParam.LastRecipeName;
            DirectoryInfo _DirInfo = new DirectoryInfo(RecipeParameterPath);
            if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }

            ProjectItemParameterFullPath = String.Format(@"{0}{1}\ProjectItemParameter{2}.Sys", RecipeParameterPath, SystemParam.LastRecipeName, (_ID + 1));
            XmlTextWriter _XmlWriter = new XmlTextWriter(ProjectItemParameterFullPath, Encoding.Unicode);
            _XmlWriter.Formatting = Formatting.Indented;
            _XmlWriter.WriteStartDocument();
            _XmlWriter.WriteStartElement("ProjectItemParameter");
            {
                if (InspSysManagerParam[_ID].ProjectItem == (int)eProjectItem.NEEDLE_ALIGN)
                {
                    if (null == InspSysManagerParam[_ID].ProjectItemParam) InspSysManagerParam[_ID].ProjectItemParam = new AlignProjectParameter();
                    AlignProjectParameter _AlignParam = InspSysManagerParam[_ID].ProjectItemParam as AlignProjectParameter;
                    _XmlWriter.WriteElementString("OriginX", _AlignParam.OriginX.ToString());
                    _XmlWriter.WriteElementString("OriginY", _AlignParam.OriginY.ToString());
                    _XmlWriter.WriteElementString("OriginRadius", _AlignParam.OriginRadius.ToString());
                }

                else if (InspSysManagerParam[_ID].ProjectItem == (int)eProjectItem.LEAD_INSP)
                {
                    if (null == InspSysManagerParam[_ID].ProjectItemParam) InspSysManagerParam[_ID].ProjectItemParam = new LeadProjectParameter();
                    LeadProjectParameter _LeadParam = InspSysManagerParam[_ID].ProjectItemParam as LeadProjectParameter;
                    _XmlWriter.WriteElementString("LeadCount", _LeadParam.LeadCount.ToString());
                }
            }
            _XmlWriter.WriteEndElement();
            _XmlWriter.WriteEndDocument();
            _XmlWriter.Close();
        }
        #endregion Read & Write Project Item Parameter

        #region Read & Write InspectionParameter
        public bool ReadInspectionParameters()
        {
            bool _Result = true;

            InspParam = new InspectionParameter[SystemParam.InspSystemManagerCount];
            for (int iLoopCount = 0; iLoopCount < SystemParam.InspSystemManagerCount; ++iLoopCount)
            {
                InspParam[iLoopCount] = new InspectionParameter();
                if (false == ReadInspectionParameter(iLoopCount, SystemParam.LastRecipeName)) { _Result = false; break; }
            }

            return _Result;
        }

        public bool ReadInspectionParameter(int _ID, string _RecipeName = null)
        {
            bool _Result = true;

            if (null == _RecipeName) _RecipeName = SystemParam.LastRecipeName;
            string _RecipeParameterPath = InspectionDefaultPath + @"RecipeParameter\" + _RecipeName + @"\Module" + (_ID + 1);
            DirectoryInfo _DirInfo = new DirectoryInfo(_RecipeParameterPath);
            if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }

            string _InspParamFullPath = _RecipeParameterPath + @"\InspectionCondition.Rcp";
            if (false == File.Exists(_InspParamFullPath))
            {
                File.Create(_InspParamFullPath).Close();
                WriteInspectionParameter(_ID, _InspParamFullPath);
                System.Threading.Thread.Sleep(100);
            }

            AreaNumber = AlgoNumber = 1;
            XmlNodeList _XmlNodeList = GetNodeList(_InspParamFullPath);
            if (null == _XmlNodeList) return false;

            foreach (XmlNode _Node in _XmlNodeList)
            {
                InspectionAreaParameter _InspAreaParamTemp = new InspectionAreaParameter();

                if (null == _Node) return false;
                if (true == GetInspectionParameterResolution(_Node, ref InspParam[_ID]))    {   continue;   }
                GetInspectionParameterRegion(_Node, ref _InspAreaParamTemp);
                GetInspectionParameterAlgorithm(_Node, ref _InspAreaParamTemp);
                InspParam[_ID].InspAreaParam.Add(_InspAreaParamTemp);
            }

            return _Result;
        }

        private bool GetInspectionParameterResolution(XmlNode _Nodes, ref InspectionParameter _InspParam)
        {
            bool _Result = true;
            if (null == _Nodes) return false;
            switch (_Nodes.Name)
            {
                case "ResolutionX": _InspParam.ResolutionX = Convert.ToDouble(_Nodes.InnerText); break;
                case "ResolutionY": _InspParam.ResolutionY = Convert.ToDouble(_Nodes.InnerText); break;
                default:            _Result = false; break;
            }
            return _Result;
        }

        private bool GetInspectionParameterRegion(XmlNode _Nodes, ref InspectionAreaParameter _InspAreaParam)
        {
            bool _Result = true;
            if (null == _Nodes) return false;
            foreach (XmlNode _NodeChild in _Nodes.ChildNodes)
            {
                switch (_NodeChild.Name)
                {
                    case "Enable":            _InspAreaParam.Enable = Convert.ToBoolean(_NodeChild.InnerText); break;
                    case "BenchMark":         _InspAreaParam.AreaBenchMark = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "NgNumber":          _InspAreaParam.NgAreaNumber = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "AreaRegionCenterX": _InspAreaParam.AreaRegionCenterX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "AreaRegionCenterY": _InspAreaParam.AreaRegionCenterY = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "AreaRegionWidth":   _InspAreaParam.AreaRegionWidth = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "AreaRegionHeight":  _InspAreaParam.AreaRegionHeight = Convert.ToDouble(_NodeChild.InnerText); break;
                    default:                  _Result = false; break;
                }
            }
            return _Result;
        }

        private bool GetInspectionParameterAlgorithm(XmlNode _Nodes, ref InspectionAreaParameter _InspAreaParam)
        {
            bool _Result = true;
            if (null == _Nodes) return false;
            for (int iLoopCount = 0; ; ++iLoopCount)
            {
                InspectionAlgorithmParameter _InspAlgoParamTemp = new InspectionAlgorithmParameter();

                int _AlgoNumber = iLoopCount + 1;
                string _AlgoNumberName = String.Format("Algo{0}", _AlgoNumber);

                XmlNode _Node = _Nodes[_AlgoNumberName];
                if (null == _Node) break;

                foreach (XmlNode _NodeChild in _Node.ChildNodes)
                {
                    switch (_NodeChild.Name)
                    {
                        case "AlgoEnable":          _InspAlgoParamTemp.AlgoEnable = Convert.ToBoolean(_NodeChild.InnerText); break;
                        case "AlgoType":            _InspAlgoParamTemp.AlgoType = Convert.ToInt32(_NodeChild.InnerText); break;
                        case "AlgoBenchMark":       _InspAlgoParamTemp.AlgoBenchMark = Convert.ToInt32(_NodeChild.InnerText); break;
                        case "AlgoRegionCenterX":   _InspAlgoParamTemp.AlgoRegionCenterX = Convert.ToDouble(_NodeChild.InnerText); break;
                        case "AlgoRegionCenterY":   _InspAlgoParamTemp.AlgoRegionCenterY = Convert.ToDouble(_NodeChild.InnerText); break;
                        case "AlgoRegionWidth":     _InspAlgoParamTemp.AlgoRegionWidth = Convert.ToDouble(_NodeChild.InnerText); break;
                        case "AlgoRegionHeight":    _InspAlgoParamTemp.AlgoRegionHeight = Convert.ToDouble(_NodeChild.InnerText); break;
                        default:                    _Result = false; break;
                    }
                }

                if ((int)eAlgoType.C_PATTERN == _InspAlgoParamTemp.AlgoType)         GetPatternInspectionparameter(_Node, ref _InspAlgoParamTemp);
                else if ((int)eAlgoType.C_BLOB == _InspAlgoParamTemp.AlgoType)       GetBlobInspectionParameter(_Node, ref _InspAlgoParamTemp);
                else if ((int)eAlgoType.C_BLOB_REFER == _InspAlgoParamTemp.AlgoType) GetBlobReferInspectionParameter(_Node, ref _InspAlgoParamTemp);
                else if ((int)eAlgoType.C_LEAD == _InspAlgoParamTemp.AlgoType)       GetLeadInspectionParameter(_Node, ref _InspAlgoParamTemp);
                else if ((int)eAlgoType.C_NEEDLE_FIND == _InspAlgoParamTemp.AlgoType)GetNeedleFindInspectionParameter(_Node, ref _InspAlgoParamTemp);
                else if ((int)eAlgoType.C_ID == _InspAlgoParamTemp.AlgoType)         GetBarCodeIDInspectionParameter(_Node, ref _InspAlgoParamTemp);
                else if ((int)eAlgoType.C_LINE_FIND == _InspAlgoParamTemp.AlgoType)  GetLineFindInspectionParameter(_Node, ref _InspAlgoParamTemp);

                _InspAreaParam.InspAlgoParam.Add(_InspAlgoParamTemp);
            }
            return _Result;
        }

        private void GetPatternInspectionparameter(XmlNode _Nodes, ref InspectionAlgorithmParameter _InspParam)
        {
            if (null == _Nodes) return;

            int _Cnt = 1;
            CogPatternAlgo _CogPattern = new CogPatternAlgo();
            _CogPattern.ReferenceInfoList = new References();
            _CogPattern.ReferenceInfoList.Clear();
            
            foreach (XmlNode _NodeChild in _Nodes)
            {
                if (null == _NodeChild) return;

                string ReferenceName = "Reference" + _Cnt;

                if (_NodeChild.Name == "PatternCount")       _CogPattern.PatternCount = Convert.ToInt32(_NodeChild.InnerText);
                else if (_NodeChild.Name == "MatchingScore") _CogPattern.MatchingScore = Convert.ToDouble(_NodeChild.InnerText);
                else if (_NodeChild.Name == "MatchingAngle") _CogPattern.MatchingAngle = Convert.ToDouble(_NodeChild.InnerText);
                else if (_NodeChild.Name == "MatchingCount") _CogPattern.MatchingCount = Convert.ToInt32(_NodeChild.InnerText);
                else if (_NodeChild.Name == "EnableShift")   _CogPattern.IsShift = Convert.ToBoolean(_NodeChild.InnerText);
                else if (_NodeChild.Name == "ShiftX")        _CogPattern.AllowedShiftX = Convert.ToInt32(_NodeChild.InnerText);
                else if (_NodeChild.Name == "ShiftY")        _CogPattern.AllowedShiftY = Convert.ToInt32(_NodeChild.InnerText);

                //Reference
                ReferenceInformation _ReferInfo = new ReferenceInformation();
                if (_NodeChild.Name == ReferenceName)
                {
                    foreach (XmlNode _Node in _NodeChild)
                    {
                        if (null == _Node) return;
                        switch (_Node.Name)
                        {
                            case "ReferencePath":       _ReferInfo.ReferencePath = _Node.InnerText; break;
                            case "InterActiveStartX":   _ReferInfo.InterActiveStartX = Convert.ToDouble(_Node.InnerText); break;
                            case "InterActiveStartY":   _ReferInfo.InterActiveStartY = Convert.ToDouble(_Node.InnerText); break;
                            case "StaticStartX":        _ReferInfo.StaticStartX = Convert.ToDouble(_Node.InnerText); break;
                            case "StaticStartY":        _ReferInfo.StaticStartY = Convert.ToDouble(_Node.InnerText); break;
                            case "OriginX":             _ReferInfo.CenterX = Convert.ToDouble(_Node.InnerText); break;
                            case "OriginY":             _ReferInfo.CenterY = Convert.ToDouble(_Node.InnerText); break;
                            case "OriginPointOffsetX":  _ReferInfo.OriginPointOffsetX = Convert.ToDouble(_Node.InnerText); break;
                            case "OriginPointOffsetY":  _ReferInfo.OriginPointOffsetY = Convert.ToDouble(_Node.InnerText); break;
                            case "Width":               _ReferInfo.Width = Convert.ToDouble(_Node.InnerText); break;
                            case "Height":              _ReferInfo.Height = Convert.ToDouble(_Node.InnerText); break;
                        }
                    }
                    _ReferInfo.Reference = (CogPMAlignPattern)CogSerializer.LoadObjectFromFile(_ReferInfo.ReferencePath, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
                    _CogPattern.ReferenceInfoList.Add(_ReferInfo);
                    _Cnt++;
                }
            }
            _InspParam.Algorithm = _CogPattern;
        }

        private void GetBlobReferInspectionParameter(XmlNode _Nodes, ref InspectionAlgorithmParameter _InspParam)
        {
            if (null == _Nodes) return;
            CogBlobReferenceAlgo _CogBlobRefer = new CogBlobReferenceAlgo();
            foreach (XmlNode _NodeChild in _Nodes)
            {
                if (null == _NodeChild) return;
                switch (_NodeChild.Name)
                {
                    case "Foreground":          _CogBlobRefer.ForeGround = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "ThresholdMin":        _CogBlobRefer.ThresholdMin = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "ThresholdMax":        _CogBlobRefer.ThresholdMax = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "BlobAreaMin":         _CogBlobRefer.BlobAreaMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BlobAreaMax":         _CogBlobRefer.BlobAreaMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "WidthMin":            _CogBlobRefer.WidthMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "WidthMax":            _CogBlobRefer.WidthMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "HeightMin":           _CogBlobRefer.HeightMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "HeightMax":           _CogBlobRefer.HeightMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginX":             _CogBlobRefer.OriginX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginY":             _CogBlobRefer.OriginY = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BenchMarkPosition":   _CogBlobRefer.BenchMarkPosition = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "BodyArea":            _CogBlobRefer.BodyArea = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BodyWidth":           _CogBlobRefer.BodyWidth = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BodyHeight":          _CogBlobRefer.BodyHeight = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BodyAreaPermitPercent":   _CogBlobRefer.BodyAreaPermitPercent = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BodyWidthPermitPercent":  _CogBlobRefer.BodyWidthPermitPercent = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BodyHeightPermitPercent": _CogBlobRefer.BodyHeightPermitPercent = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "UseBodyArea":         _CogBlobRefer.UseBodyArea = Convert.ToBoolean(_NodeChild.InnerText); break;
                    case "UseBodyWidth":        _CogBlobRefer.UseBodyWidth = Convert.ToBoolean(_NodeChild.InnerText); break;
                    case "UseBodyHeight":       _CogBlobRefer.UseBodyHeight = Convert.ToBoolean(_NodeChild.InnerText); break;
                }
            }
            _InspParam.Algorithm = _CogBlobRefer;
        }

        private void GetBlobInspectionParameter(XmlNode _Nodes, ref InspectionAlgorithmParameter _InspParam)
        {
            if (null == _Nodes) return;
            CogBlobAlgo _CogBlob = new CogBlobAlgo();
            foreach (XmlNode _NodeChild in _Nodes)
            {
                if (null == _NodeChild) return;
                switch (_NodeChild.Name)
                {
                    case "Foreground":      _CogBlob.ForeGround = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "ThresholdMin":    _CogBlob.ThresholdMin = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "ThresholdMax":    _CogBlob.ThresholdMax = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "BlobAreaMin":     _CogBlob.BlobAreaMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BlobAreaMax":     _CogBlob.BlobAreaMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "WidthMin":        _CogBlob.WidthMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "WidthMax":        _CogBlob.WidthMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "HeightMin":       _CogBlob.HeightMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "HeightMax":       _CogBlob.HeightMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginX":         _CogBlob.OriginX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginY":         _CogBlob.OriginY = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BenchMarkPosition": _CogBlob.BenchMarkPosition = Convert.ToInt32(_NodeChild.InnerText); break;
                }
            }
            _InspParam.Algorithm = _CogBlob;
        }

        private void GetLeadInspectionParameter(XmlNode _Nodes, ref InspectionAlgorithmParameter _InspParam)
        {
            if (null == _Nodes) return;
            CogLeadAlgo _CogLeadAlgo = new CogLeadAlgo();
            foreach (XmlNode _NodeChild in _Nodes)
            {
                if (null == _NodeChild) return;
                switch (_NodeChild.Name)
                {
                    case"LeadCount":        _CogLeadAlgo.LeadCount = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "LeadUsable":      _CogLeadAlgo.LeadUsable = _NodeChild.InnerText; break;
                    case "Foreground":      _CogLeadAlgo.ForeGround = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "ThresholdMin":    _CogLeadAlgo.ThresholdMin = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "ThresholdMax":    _CogLeadAlgo.ThresholdMax = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "BlobAreaMin":     _CogLeadAlgo.BlobAreaMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "BlobAreaMax":     _CogLeadAlgo.BlobAreaMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "WidthMin":        _CogLeadAlgo.WidthMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "WidthMax":        _CogLeadAlgo.WidthMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "HeightMin":       _CogLeadAlgo.HeightMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "HeightMax":       _CogLeadAlgo.HeightMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginX":         _CogLeadAlgo.OriginX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginY":         _CogLeadAlgo.OriginY = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "LeadBent":        _CogLeadAlgo.LeadBent = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "LeadBentMin":     _CogLeadAlgo.LeadBentMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "LeadBentMax":     _CogLeadAlgo.LeadBentMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "LeadPitch":       _CogLeadAlgo.LeadPitch = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "LeadPitchMin":    _CogLeadAlgo.LeadPitchMin = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "LeadPitchMax":    _CogLeadAlgo.LeadPitchMax = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "IsLeadBentInsp":  _CogLeadAlgo.IsLeadBentInspection = Convert.ToBoolean(_NodeChild.InnerText); break;
                    case "IsLeadPitchInsp": _CogLeadAlgo.IsLeadPitchInspection = Convert.ToBoolean(_NodeChild.InnerText); break;
                }
            }
            _InspParam.Algorithm = _CogLeadAlgo;
        }

        private void GetNeedleFindInspectionParameter(XmlNode _Nodes, ref InspectionAlgorithmParameter _InspParam)
        {
            if (null == _Nodes) return;
            CogNeedleFindAlgo _CogNeedleFind = new CogNeedleFindAlgo();
            foreach (XmlNode _NodeChild in _Nodes)
            {
                if (null == _NodeChild) return;
                switch (_NodeChild.Name)
                {
                    case "CaliperNumber": _CogNeedleFind.CaliperNumber = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "CaliperSearchLength": _CogNeedleFind.CaliperSearchLength = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "CaliperProjectionLength": _CogNeedleFind.CaliperProjectionLength = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "CaliperSearchDirection": _CogNeedleFind.CaliperSearchDirection = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "ArcCenterX": _CogNeedleFind.ArcCenterX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "ArcCenterY": _CogNeedleFind.ArcCenterY = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "ArcRadius": _CogNeedleFind.ArcRadius = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "ArcAngleStart": _CogNeedleFind.ArcAngleStart = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "ArcAngleSpan": _CogNeedleFind.ArcAngleSpan = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginX": _CogNeedleFind.OriginX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginY": _CogNeedleFind.OriginY = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginRadius": _CogNeedleFind.OriginRadius = Convert.ToDouble(_NodeChild.InnerText); break;
                }
            }
            _InspParam.Algorithm = _CogNeedleFind;
        }

        private void GetBarCodeIDInspectionParameter(XmlNode _Nodes, ref InspectionAlgorithmParameter _InspParam)
        {
            if (null == _Nodes) return;
            CogBarCodeIDAlgo _CogBarCodeID = new CogBarCodeIDAlgo();
            foreach (XmlNode _NodeChild in _Nodes)
            {
                if (null == _NodeChild) return;
                switch (_NodeChild.Name)
                {
                    case "Symbology": _CogBarCodeID.Symbology = _NodeChild.InnerText; break;
                    case "TimeLimit": _CogBarCodeID.TimeLimit = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "FindCount": _CogBarCodeID.FindCount = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "OriginX": _CogBarCodeID.OriginX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "OriginY": _CogBarCodeID.OriginY = Convert.ToDouble(_NodeChild.InnerText); break;
                }
            }
            _InspParam.Algorithm = _CogBarCodeID;
        }

        private void GetLineFindInspectionParameter(XmlNode _Nodes, ref InspectionAlgorithmParameter _InspParam)
        {
            if (null == _Nodes) return;
            CogLineFindAlgo _CogLineFind = new CogLineFindAlgo();
            foreach (XmlNode _NodeChild in _Nodes)
            {
                if (null == _NodeChild) return;
                switch (_NodeChild.Name)
                {
                    case "CaliperNumber":           _CogLineFind.CaliperNumber = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "CaliperSearchLength":     _CogLineFind.CaliperSearchLength = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "CaliperProjectionLength": _CogLineFind.CaliperProjectionLength = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "CaliperSearchDirection":  _CogLineFind.CaliperSearchDirection = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "IgnoreNumber":            _CogLineFind.IgnoreNumber = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "CaliperLineStartX":       _CogLineFind.CaliperLineStartX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "CaliperLineStartY":       _CogLineFind.CaliperLineStartY = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "CaliperLineEndX":         _CogLineFind.CaliperLineEndX = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "CaliperLineEndY":         _CogLineFind.CaliperLineEndY = Convert.ToDouble(_NodeChild.InnerText); break;
                    case "ContrastThreshold":       _CogLineFind.ContrastThreshold = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "FilterHalfSizePixels":    _CogLineFind.FilterHalfSizePixels = Convert.ToInt32(_NodeChild.InnerText); break;
                    case "UseAlignment":            _CogLineFind.UseAlignment = Convert.ToBoolean(_NodeChild.InnerText); break;
                }
            }
            _InspParam.Algorithm = _CogLineFind;
        }

        public void WriteInspectionParameter(int _ID, string _InspParamFullPath = null)
        {
            if (null == _InspParamFullPath) _InspParamFullPath = InspectionDefaultPath + @"RecipeParameter\" + SystemParam.LastRecipeName + @"\Module" + (_ID + 1) + @"\InspectionCondition.Rcp";

            string _InspParamPath = String.Format(@"{0}{1}\Module{2}", RecipeParameterPath, SystemParam.LastRecipeName, (_ID + 1));
            DirectoryInfo _DirInfo = new DirectoryInfo(_InspParamPath);
            if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }

            //Reference folder를 지우고 다시 저장
            string _ReferencePath = String.Format(@"{0}{1}\Module{2}\Reference", RecipeParameterPath, SystemParam.LastRecipeName, (_ID + 1));
            _DirInfo = new DirectoryInfo(_ReferencePath);
            if (false == _DirInfo.Exists) { _DirInfo.Create(); System.Threading.Thread.Sleep(100); }
            Directory.Delete(_ReferencePath, true);

            XmlTextWriter _XmlWriter = new XmlTextWriter(_InspParamFullPath, Encoding.Unicode);
            _XmlWriter.Formatting = Formatting.Indented;
            _XmlWriter.WriteStartDocument();
            _XmlWriter.WriteStartElement("AlgoParameter");
            {
                _XmlWriter.WriteElementString("ResolutionX", InspParam[_ID].ResolutionX.ToString());
                _XmlWriter.WriteElementString("ResolutionY", InspParam[_ID].ResolutionY.ToString());
                for (int iLoopCount = 0; iLoopCount < InspParam[_ID].InspAreaParam.Count; ++iLoopCount)
                {
                    _XmlWriter.WriteStartElement("InspAlgoArea" + (iLoopCount + 1));
                    {
                        //검사 영역 저장
                        _XmlWriter.WriteElementString("Enable", InspParam[_ID].InspAreaParam[iLoopCount].Enable.ToString());
                        _XmlWriter.WriteElementString("NgNumber", InspParam[_ID].InspAreaParam[iLoopCount].NgAreaNumber.ToString());
                        _XmlWriter.WriteElementString("BenchMark", InspParam[_ID].InspAreaParam[iLoopCount].AreaBenchMark.ToString());
                        _XmlWriter.WriteElementString("AreaRegionCenterX", InspParam[_ID].InspAreaParam[iLoopCount].AreaRegionCenterX.ToString());
                        _XmlWriter.WriteElementString("AreaRegionCenterY", InspParam[_ID].InspAreaParam[iLoopCount].AreaRegionCenterY.ToString());
                        _XmlWriter.WriteElementString("AreaRegionWidth", InspParam[_ID].InspAreaParam[iLoopCount].AreaRegionWidth.ToString());
                        _XmlWriter.WriteElementString("AreaRegionHeight", InspParam[_ID].InspAreaParam[iLoopCount].AreaRegionHeight.ToString());

                        for (int jLoopCount = 0; jLoopCount < InspParam[_ID].InspAreaParam[iLoopCount].InspAlgoParam.Count; ++jLoopCount)
                        {
                            InspectionAlgorithmParameter _InspAlgoParamTemp = InspParam[_ID].InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount];
                            _XmlWriter.WriteStartElement("Algo" + (jLoopCount + 1));
                            {
                                _XmlWriter.WriteElementString("AlgoEnable", _InspAlgoParamTemp.AlgoEnable.ToString());
                                _XmlWriter.WriteElementString("AlgoType", _InspAlgoParamTemp.AlgoType.ToString());
                                _XmlWriter.WriteElementString("AlgoBenchMark", _InspAlgoParamTemp.AlgoBenchMark.ToString());
                                _XmlWriter.WriteElementString("AlgoRegionCenterX", _InspAlgoParamTemp.AlgoRegionCenterX.ToString());
                                _XmlWriter.WriteElementString("AlgoRegionCenterY", _InspAlgoParamTemp.AlgoRegionCenterY.ToString());
                                _XmlWriter.WriteElementString("AlgoRegionWidth", _InspAlgoParamTemp.AlgoRegionWidth.ToString());
                                _XmlWriter.WriteElementString("AlgoRegionHeight", _InspAlgoParamTemp.AlgoRegionHeight.ToString());

                                AreaNumber = iLoopCount + 1;
                                AlgoNumber = jLoopCount + 1;
                                eAlgoType _AlgoType = (eAlgoType)_InspAlgoParamTemp.AlgoType;
                                if (eAlgoType.C_PATTERN == _AlgoType)           WritePatternInspectionParameter(_ID, _XmlWriter, _InspAlgoParamTemp.Algorithm);
                                else if (eAlgoType.C_BLOB == _AlgoType)         WriteBlobInspectionParameter(_ID, _XmlWriter, _InspAlgoParamTemp.Algorithm);
                                else if (eAlgoType.C_BLOB_REFER == _AlgoType)   WriteBlobReferInspectionParameter(_ID, _XmlWriter, _InspAlgoParamTemp.Algorithm);
                                else if (eAlgoType.C_LEAD == _AlgoType)         WriteLeadInspectionParameter(_ID, _XmlWriter, _InspAlgoParamTemp.Algorithm);
                                else if (eAlgoType.C_NEEDLE_FIND == _AlgoType)  WriteNeedleFindInspectionParameter(_ID, _XmlWriter, _InspAlgoParamTemp.Algorithm);
                                else if (eAlgoType.C_ID == _AlgoType)           WriteBarCodeIDInspectionParameter(_ID, _XmlWriter, _InspAlgoParamTemp.Algorithm);
                                else if (eAlgoType.C_LINE_FIND == _AlgoType)    WriteLineFindInspectionParameter(_ID, _XmlWriter, _InspAlgoParamTemp.Algorithm);
                            }
                            _XmlWriter.WriteEndElement();
                        }
                    }
                    _XmlWriter.WriteEndElement();
                }
            }
            _XmlWriter.WriteEndElement();
            _XmlWriter.WriteEndDocument();
            _XmlWriter.Close();
        }

        private void WritePatternInspectionParameter(int _ID, XmlTextWriter _XmlWriter, Object _InspAlgoParam)
        {
            CogPatternAlgo _CogPatternAlgo = (CogPatternAlgo)_InspAlgoParam;
            _XmlWriter.WriteElementString("PatternCount", _CogPatternAlgo.PatternCount.ToString());
            _XmlWriter.WriteElementString("CatchingScore", _CogPatternAlgo.MatchingScore.ToString());
            _XmlWriter.WriteElementString("MatchingAngle", _CogPatternAlgo.MatchingAngle.ToString());
            _XmlWriter.WriteElementString("MatchingCount", _CogPatternAlgo.MatchingCount.ToString());
            _XmlWriter.WriteElementString("EnableShift", _CogPatternAlgo.IsShift.ToString());
            _XmlWriter.WriteElementString("ShiftX", _CogPatternAlgo.AllowedShiftX.ToString());
            _XmlWriter.WriteElementString("ShiftY", _CogPatternAlgo.AllowedShiftY.ToString());

            //Reference Model Save
            for (int iLoopCount = 0; iLoopCount < _CogPatternAlgo.ReferenceInfoList.Count; ++iLoopCount)
            {
                string _Extention = ".pat";
                string _FileName = String.Format("AR{0:D2}_AL{1:D2}_RF{2:D2}{3}", AreaNumber, AlgoNumber, iLoopCount + 1, _Extention);
                string _RecipeName = SystemParam.LastRecipeName;
                string _RecipeParameterPath = String.Format(@"{0}RecipeParameter\{1}\Module{2}\Reference\", InspectionDefaultPath, _RecipeName, _ID + 1);

                if (false == Directory.Exists(_RecipeParameterPath)) Directory.CreateDirectory(_RecipeParameterPath);
                _CogPatternAlgo.ReferenceInfoList[iLoopCount].ReferencePath = _RecipeParameterPath + _FileName;
                CogSerializer.SaveObjectToFile(_CogPatternAlgo.ReferenceInfoList[iLoopCount].Reference, _CogPatternAlgo.ReferenceInfoList[iLoopCount].ReferencePath, typeof(BinaryFormatter), CogSerializationOptionsConstants.InputImages);

                _XmlWriter.WriteStartElement("Reference" + (iLoopCount + 1));
                {
                    _XmlWriter.WriteElementString("ReferencePath", _CogPatternAlgo.ReferenceInfoList[iLoopCount].ReferencePath);
                    _XmlWriter.WriteElementString("InterActiveStartX", _CogPatternAlgo.ReferenceInfoList[iLoopCount].InterActiveStartX.ToString());
                    _XmlWriter.WriteElementString("InterActiveStartY", _CogPatternAlgo.ReferenceInfoList[iLoopCount].InterActiveStartY.ToString());
                    _XmlWriter.WriteElementString("StaticStartX", _CogPatternAlgo.ReferenceInfoList[iLoopCount].StaticStartX.ToString());
                    _XmlWriter.WriteElementString("StaticStartY", _CogPatternAlgo.ReferenceInfoList[iLoopCount].StaticStartY.ToString());
                    _XmlWriter.WriteElementString("OriginX", _CogPatternAlgo.ReferenceInfoList[iLoopCount].CenterX.ToString());
                    _XmlWriter.WriteElementString("OriginY", _CogPatternAlgo.ReferenceInfoList[iLoopCount].CenterY.ToString());
                    _XmlWriter.WriteElementString("OriginPointOffsetX", _CogPatternAlgo.ReferenceInfoList[iLoopCount].OriginPointOffsetX.ToString());
                    _XmlWriter.WriteElementString("OriginPointOffsetY", _CogPatternAlgo.ReferenceInfoList[iLoopCount].OriginPointOffsetY.ToString());
                    _XmlWriter.WriteElementString("Width", _CogPatternAlgo.ReferenceInfoList[iLoopCount].Width.ToString());
                    _XmlWriter.WriteElementString("Height", _CogPatternAlgo.ReferenceInfoList[iLoopCount].Height.ToString());
                }
                _XmlWriter.WriteEndElement();
            }
        }

        private void WriteBlobReferInspectionParameter(int _ID, XmlTextWriter _XmlWriter, Object _InspAlgoParam)
        {
            CogBlobReferenceAlgo _CogBlobReferAlgo = (CogBlobReferenceAlgo)_InspAlgoParam;
            _XmlWriter.WriteElementString("Foreground", _CogBlobReferAlgo.ForeGround.ToString());
            _XmlWriter.WriteElementString("ThresholdMin", _CogBlobReferAlgo.ThresholdMin.ToString());
            _XmlWriter.WriteElementString("ThresholdMax", _CogBlobReferAlgo.ThresholdMax.ToString());
            _XmlWriter.WriteElementString("BlobAreaMin", _CogBlobReferAlgo.BlobAreaMin.ToString());
            _XmlWriter.WriteElementString("BlobAreaMax", _CogBlobReferAlgo.BlobAreaMax.ToString());
            _XmlWriter.WriteElementString("WidthMin", _CogBlobReferAlgo.WidthMin.ToString());
            _XmlWriter.WriteElementString("WidthMax", _CogBlobReferAlgo.WidthMax.ToString());
            _XmlWriter.WriteElementString("HeightMin", _CogBlobReferAlgo.HeightMin.ToString());
            _XmlWriter.WriteElementString("HeightMax", _CogBlobReferAlgo.HeightMax.ToString());
            _XmlWriter.WriteElementString("OriginX", _CogBlobReferAlgo.OriginX.ToString());
            _XmlWriter.WriteElementString("OriginY", _CogBlobReferAlgo.OriginY.ToString());
            _XmlWriter.WriteElementString("BenchMarkPosition", _CogBlobReferAlgo.BenchMarkPosition.ToString());
            _XmlWriter.WriteElementString("BodyArea", _CogBlobReferAlgo.BodyArea.ToString());
            _XmlWriter.WriteElementString("BodyWidth", _CogBlobReferAlgo.BodyWidth.ToString());
            _XmlWriter.WriteElementString("BodyHeight", _CogBlobReferAlgo.BodyHeight.ToString());
            _XmlWriter.WriteElementString("BodyAreaPermitPercent", _CogBlobReferAlgo.BodyAreaPermitPercent.ToString());
            _XmlWriter.WriteElementString("BodyWidthPermitPercent", _CogBlobReferAlgo.BodyWidthPermitPercent.ToString());
            _XmlWriter.WriteElementString("BodyHeightPermitPercent", _CogBlobReferAlgo.BodyHeightPermitPercent.ToString());
            _XmlWriter.WriteElementString("UseBodyArea", _CogBlobReferAlgo.UseBodyArea.ToString());
            _XmlWriter.WriteElementString("UseBodyWidth", _CogBlobReferAlgo.UseBodyWidth.ToString());
            _XmlWriter.WriteElementString("UseBodyHeight", _CogBlobReferAlgo.UseBodyHeight.ToString());
        }

        private void WriteBlobInspectionParameter(int _ID, XmlTextWriter _XmlWriter, Object _InspAlgoParam)
        {
            CogBlobAlgo _CogBlobAlgo = (CogBlobAlgo)_InspAlgoParam;
            _XmlWriter.WriteElementString("Foreground", _CogBlobAlgo.ForeGround.ToString());
            _XmlWriter.WriteElementString("ThresholdMin", _CogBlobAlgo.ThresholdMin.ToString());
            _XmlWriter.WriteElementString("ThresholdMax", _CogBlobAlgo.ThresholdMax.ToString());
            _XmlWriter.WriteElementString("BlobAreaMin", _CogBlobAlgo.BlobAreaMin.ToString());
            _XmlWriter.WriteElementString("BlobAreaMax", _CogBlobAlgo.BlobAreaMax.ToString());
            _XmlWriter.WriteElementString("WidthMin", _CogBlobAlgo.WidthMin.ToString());
            _XmlWriter.WriteElementString("WidthMax", _CogBlobAlgo.WidthMax.ToString());
            _XmlWriter.WriteElementString("HeightMin", _CogBlobAlgo.HeightMin.ToString());
            _XmlWriter.WriteElementString("HeightMax", _CogBlobAlgo.HeightMax.ToString());
            _XmlWriter.WriteElementString("OriginX", _CogBlobAlgo.OriginX.ToString());
            _XmlWriter.WriteElementString("OriginY", _CogBlobAlgo.OriginY.ToString());
            _XmlWriter.WriteElementString("BenchMarkPosition", _CogBlobAlgo.BenchMarkPosition.ToString());
        }

        private void WriteLeadInspectionParameter(int _ID, XmlTextWriter _XmlWriter, Object _InspAlgoParam)
        {
            //CogLeadAlgo _CogLeadAlgo = (CogLeadAlgo)_InspAlgoParam
            var _CogLeadAlgo = _InspAlgoParam as CogLeadAlgo;
            _XmlWriter.WriteElementString("LeadCount", _CogLeadAlgo.LeadCount.ToString());
            _XmlWriter.WriteElementString("LeadUsable", _CogLeadAlgo.LeadUsable);
            _XmlWriter.WriteElementString("Foreground", _CogLeadAlgo.ForeGround.ToString());
            _XmlWriter.WriteElementString("ThresholdMin", _CogLeadAlgo.ThresholdMin.ToString());
            _XmlWriter.WriteElementString("ThresholdMax", _CogLeadAlgo.ThresholdMax.ToString());
            _XmlWriter.WriteElementString("BlobAreaMin", _CogLeadAlgo.BlobAreaMin.ToString());
            _XmlWriter.WriteElementString("BlobAreaMax", _CogLeadAlgo.BlobAreaMax.ToString());
            _XmlWriter.WriteElementString("WidthMin", _CogLeadAlgo.WidthMin.ToString());
            _XmlWriter.WriteElementString("WidthMax", _CogLeadAlgo.WidthMax.ToString());
            _XmlWriter.WriteElementString("HeightMin", _CogLeadAlgo.HeightMin.ToString());
            _XmlWriter.WriteElementString("HeightMax", _CogLeadAlgo.HeightMax.ToString());
            _XmlWriter.WriteElementString("OriginX", _CogLeadAlgo.OriginX.ToString());
            _XmlWriter.WriteElementString("OriginY", _CogLeadAlgo.OriginY.ToString());
            _XmlWriter.WriteElementString("LeadBent", _CogLeadAlgo.LeadBent.ToString());
            _XmlWriter.WriteElementString("LeadBentMin", _CogLeadAlgo.LeadBentMin.ToString());
            _XmlWriter.WriteElementString("LeadBentMax", _CogLeadAlgo.LeadBentMax.ToString());
            _XmlWriter.WriteElementString("LeadPitch", _CogLeadAlgo.LeadPitch.ToString());
            _XmlWriter.WriteElementString("LeadPitchMin", _CogLeadAlgo.LeadPitchMin.ToString());
            _XmlWriter.WriteElementString("LeadPitchMax", _CogLeadAlgo.LeadPitchMax.ToString());
            _XmlWriter.WriteElementString("IsLeadPitchInsp", _CogLeadAlgo.IsLeadPitchInspection.ToString());
            _XmlWriter.WriteElementString("IsLeadBentInsp", _CogLeadAlgo.IsLeadBentInspection.ToString());
        }

        private void WriteNeedleFindInspectionParameter(int _ID, XmlTextWriter _XmlWriter, Object _InspAlgoParam)
        {
            var _CogNeedleFindAlgo = _InspAlgoParam as CogNeedleFindAlgo;
            _XmlWriter.WriteElementString("CaliperNumber", _CogNeedleFindAlgo.CaliperNumber.ToString());
            _XmlWriter.WriteElementString("CaliperSearchLength", _CogNeedleFindAlgo.CaliperSearchLength.ToString());
            _XmlWriter.WriteElementString("CaliperProjectionLength", _CogNeedleFindAlgo.CaliperProjectionLength.ToString());
            _XmlWriter.WriteElementString("CaliperSearchDirection", _CogNeedleFindAlgo.CaliperSearchDirection.ToString());
            _XmlWriter.WriteElementString("ArcCenterX", _CogNeedleFindAlgo.ArcCenterX.ToString());
            _XmlWriter.WriteElementString("ArcCenterY", _CogNeedleFindAlgo.ArcCenterY.ToString());
            _XmlWriter.WriteElementString("ArcRadius", _CogNeedleFindAlgo.ArcRadius.ToString());
            _XmlWriter.WriteElementString("ArcAngleStart", _CogNeedleFindAlgo.ArcAngleStart.ToString());
            _XmlWriter.WriteElementString("ArcAngleSpan", _CogNeedleFindAlgo.ArcAngleSpan.ToString());
            _XmlWriter.WriteElementString("OriginX", _CogNeedleFindAlgo.OriginX.ToString());
            _XmlWriter.WriteElementString("OriginY", _CogNeedleFindAlgo.OriginY.ToString());
            _XmlWriter.WriteElementString("OriginRadius", _CogNeedleFindAlgo.OriginRadius.ToString());
        }

        private void WriteBarCodeIDInspectionParameter(int _ID, XmlTextWriter _XmlWriter, Object _InspAlgoParam)
        {
            var _CogBarCodeIDAlgo = _InspAlgoParam as CogBarCodeIDAlgo;
            _XmlWriter.WriteElementString("Symbology", _CogBarCodeIDAlgo.Symbology);
            _XmlWriter.WriteElementString("OriginX", _CogBarCodeIDAlgo.OriginX.ToString());
            _XmlWriter.WriteElementString("OriginY", _CogBarCodeIDAlgo.OriginY.ToString());
            _XmlWriter.WriteElementString("TimeLimit", _CogBarCodeIDAlgo.TimeLimit.ToString());
            _XmlWriter.WriteElementString("FindCount", _CogBarCodeIDAlgo.FindCount.ToString());
        }

        private void WriteLineFindInspectionParameter(int _ID, XmlTextWriter _XmlWriter, Object _InspAlgoParam)
        {
            var _CogLineFindAlgo = _InspAlgoParam as CogLineFindAlgo;
            _XmlWriter.WriteElementString("CaliperNumber", _CogLineFindAlgo.CaliperNumber.ToString());
            _XmlWriter.WriteElementString("CaliperSearchLength", _CogLineFindAlgo.CaliperSearchLength.ToString());
            _XmlWriter.WriteElementString("CaliperProjectionLength", _CogLineFindAlgo.CaliperProjectionLength.ToString());
            _XmlWriter.WriteElementString("CaliperSearchDirection", _CogLineFindAlgo.CaliperSearchDirection.ToString());
            _XmlWriter.WriteElementString("IgnoreNumber", _CogLineFindAlgo.IgnoreNumber.ToString());
            _XmlWriter.WriteElementString("CaliperLineStartX", _CogLineFindAlgo.CaliperLineStartX.ToString());
            _XmlWriter.WriteElementString("CaliperLineStartY", _CogLineFindAlgo.CaliperLineStartY.ToString());
            _XmlWriter.WriteElementString("CaliperLineEndX", _CogLineFindAlgo.CaliperLineEndX.ToString());
            _XmlWriter.WriteElementString("CaliperLineEndY", _CogLineFindAlgo.CaliperLineEndY.ToString());
            _XmlWriter.WriteElementString("ContrastThreshold", _CogLineFindAlgo.ContrastThreshold.ToString());
            _XmlWriter.WriteElementString("FilterHalfSizePixels", _CogLineFindAlgo.FilterHalfSizePixels.ToString());
            _XmlWriter.WriteElementString("UseAlignment", _CogLineFindAlgo.UseAlignment.ToString());
        }
        #endregion Read & Write InspectionParameter

        #region RecipeCopy
        /// <summary>
        /// Inspection Parameter (Recipe) 복사
        /// </summary>
        /// <param name="_SrcParam">원본 Recipe</param>
        /// <param name="_DestParam">저장 할 Recipe</param>
        public static void RecipeCopy(InspectionParameter _SrcParam, ref InspectionParameter _DestParam)
        {
            _DestParam.InspAreaParam.Clear();

            _DestParam.ResolutionX = _SrcParam.ResolutionX;
            _DestParam.ResolutionY = _SrcParam.ResolutionY;

            for (int iLoopCount = 0; iLoopCount < _SrcParam.InspAreaParam.Count; ++iLoopCount)
            {
                InspectionAreaParameter _InspAreaParam = new InspectionAreaParameter();
                _InspAreaParam.Enable               = _SrcParam.InspAreaParam[iLoopCount].Enable;
                _InspAreaParam.NgAreaNumber         = _SrcParam.InspAreaParam[iLoopCount].NgAreaNumber;
                _InspAreaParam.AreaBenchMark        = _SrcParam.InspAreaParam[iLoopCount] .AreaBenchMark;
                _InspAreaParam.AreaRegionCenterX    = _SrcParam.InspAreaParam[iLoopCount].AreaRegionCenterX;
                _InspAreaParam.AreaRegionCenterY    = _SrcParam.InspAreaParam[iLoopCount].AreaRegionCenterY;
                _InspAreaParam.AreaRegionWidth      = _SrcParam.InspAreaParam[iLoopCount].AreaRegionWidth;
                _InspAreaParam.AreaRegionHeight     = _SrcParam.InspAreaParam[iLoopCount].AreaRegionHeight;

                for (int jLoopCount = 0; jLoopCount < _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam.Count; ++jLoopCount)
                {
                    InspectionAlgorithmParameter _InspAlgoParam = new InspectionAlgorithmParameter();
                    _InspAlgoParam.AlgoEnable           = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoEnable;
                    _InspAlgoParam.AlgoBenchMark        = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoBenchMark;
                    _InspAlgoParam.AlgoType             = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoType;
                    _InspAlgoParam.AlgoRegionCenterX    = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoRegionCenterX;
                    _InspAlgoParam.AlgoRegionCenterY    = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoRegionCenterY;
                    _InspAlgoParam.AlgoRegionWidth      = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoRegionWidth;
                    _InspAlgoParam.AlgoRegionHeight     = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoRegionHeight;

                    eAlgoType _AlgoType = (eAlgoType)_InspAlgoParam.AlgoType;
                    if (eAlgoType.C_PATTERN == _AlgoType)
                    {
                        #region Pattern Algorithm Copy
                        _InspAlgoParam.Algorithm = new CogPatternAlgo();
                        ((CogPatternAlgo)_InspAlgoParam.Algorithm).PatternCount     = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).PatternCount;
                        ((CogPatternAlgo)_InspAlgoParam.Algorithm).PatternCount     = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).PatternCount;
                        ((CogPatternAlgo)_InspAlgoParam.Algorithm).MatchingScore    = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).MatchingScore;
                        ((CogPatternAlgo)_InspAlgoParam.Algorithm).MatchingAngle    = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).MatchingAngle;
                        ((CogPatternAlgo)_InspAlgoParam.Algorithm).MatchingCount    = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).MatchingCount;
                        ((CogPatternAlgo)_InspAlgoParam.Algorithm).IsShift          = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).IsShift;
                        ((CogPatternAlgo)_InspAlgoParam.Algorithm).AllowedShiftX    = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).AllowedShiftX;
                        ((CogPatternAlgo)_InspAlgoParam.Algorithm).AllowedShiftY    = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).AllowedShiftY;

                        int _ReferCount = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList.Count;
                        for (int zLoopCount = 0; zLoopCount < _ReferCount; ++zLoopCount)
                        {
                            ReferenceInformation _ReferInfo = new ReferenceInformation();
                            _ReferInfo.ReferencePath = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].ReferencePath;
                            _ReferInfo.Reference         = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].Reference;
                            _ReferInfo.ReferencePath     = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].ReferencePath;
                            _ReferInfo.InterActiveStartX = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].InterActiveStartX;
                            _ReferInfo.InterActiveStartY = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].InterActiveStartY;
                            _ReferInfo.StaticStartX      = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].StaticStartX;
                            _ReferInfo.StaticStartY      = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].StaticStartY;
                            _ReferInfo.CenterX           = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].CenterX;
                            _ReferInfo.CenterY           = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].CenterY;
                            _ReferInfo.OriginPointOffsetX= ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].OriginPointOffsetX;
                            _ReferInfo.OriginPointOffsetY= ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].OriginPointOffsetY;
                            _ReferInfo.Width             = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].Width;
                            _ReferInfo.Height            = ((CogPatternAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ReferenceInfoList[zLoopCount].Height;

                            ((CogPatternAlgo)_InspAlgoParam.Algorithm).ReferenceInfoList.Add(_ReferInfo);
                        }
                        #endregion Pattern Algorithm Copy
                    }

                    else if (eAlgoType.C_BLOB == _AlgoType)
                    {
                        #region Blob Algorithm Copy
                        _InspAlgoParam.Algorithm = new CogBlobAlgo();
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).ForeGround    = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ForeGround;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).ThresholdMin  = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ThresholdMin;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).ThresholdMax  = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ThresholdMax;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).BlobAreaMin   = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BlobAreaMin;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).BlobAreaMax   = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BlobAreaMax;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).WidthMin      = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).WidthMin;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).WidthMax      = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).WidthMax;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).HeightMin     = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).HeightMin;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).HeightMax     = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).HeightMax;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).OriginX       = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).OriginX;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).OriginY       = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).OriginY;
                        ((CogBlobAlgo)_InspAlgoParam.Algorithm).BenchMarkPosition = ((CogBlobAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BenchMarkPosition;
                        #endregion Blob Algorithm Copy
                    }

                    else if (eAlgoType.C_BLOB_REFER == _AlgoType)
                    {
                        #region Blob Reference Algorithm Copy
                        _InspAlgoParam.Algorithm = new CogBlobReferenceAlgo();
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).ForeGround    = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ForeGround;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).ThresholdMin  = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ThresholdMin;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).ThresholdMax  = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).ThresholdMax;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BlobAreaMin   = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BlobAreaMin;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BlobAreaMax   = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BlobAreaMax;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).WidthMin      = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).WidthMin;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).WidthMax      = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).WidthMax;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).HeightMin     = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).HeightMin;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).HeightMax     = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).HeightMax;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).OriginX       = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).OriginX;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).OriginY       = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).OriginY;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BenchMarkPosition = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BenchMarkPosition;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BodyArea       = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BodyArea;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BodyWidth      = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BodyWidth;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BodyHeight     = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BodyHeight;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BodyAreaPermitPercent   = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BodyAreaPermitPercent;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BodyWidthPermitPercent  = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BodyWidthPermitPercent;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).BodyHeightPermitPercent = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).BodyHeightPermitPercent;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).UseBodyArea             = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).UseBodyArea;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).UseBodyWidth            = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).UseBodyWidth;
                        ((CogBlobReferenceAlgo)_InspAlgoParam.Algorithm).UseBodyHeight           = ((CogBlobReferenceAlgo)_SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm).UseBodyHeight;
                        #endregion Blob Reference Algorithm Copy
                    }

                    else if (eAlgoType.C_NEEDLE_FIND == _AlgoType)
                    {
                        var _Algorithm = _InspAlgoParam.Algorithm as CogNeedleFindAlgo;
                        var _SrcAlgorithm = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm as CogNeedleFindAlgo;

                        _Algorithm = new CogNeedleFindAlgo();
                        _Algorithm.CaliperNumber            = _SrcAlgorithm.CaliperNumber;
                        _Algorithm.CaliperSearchLength      = _SrcAlgorithm.CaliperSearchLength;
                        _Algorithm.CaliperProjectionLength  = _SrcAlgorithm.CaliperProjectionLength;
                        _Algorithm.CaliperSearchDirection   = _SrcAlgorithm.CaliperSearchDirection;
                        _Algorithm.ArcCenterX       = _SrcAlgorithm.ArcCenterX;
                        _Algorithm.ArcCenterY       = _SrcAlgorithm.ArcCenterY;
                        _Algorithm.ArcRadius        = _SrcAlgorithm.ArcRadius;
                        _Algorithm.ArcAngleStart    = _SrcAlgorithm.ArcAngleStart;
                        _Algorithm.ArcAngleSpan     = _SrcAlgorithm.ArcAngleSpan;
                        _Algorithm.OriginX          = _SrcAlgorithm.OriginX;
                        _Algorithm.OriginY          = _SrcAlgorithm.OriginY;
                        _Algorithm.OriginRadius     = _SrcAlgorithm.OriginRadius;

                        _InspAlgoParam.Algorithm = _Algorithm;
                    }

                    else if (eAlgoType.C_LEAD == _AlgoType)
                    {
                        var _Algorithm = _InspAlgoParam.Algorithm as CogLeadAlgo;
                        var _SrcAlgorithm = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm as CogLeadAlgo;

                        _Algorithm = new CogLeadAlgo();
                        _Algorithm.LeadCount    = _SrcAlgorithm.LeadCount;
                        _Algorithm.LeadUsable   = _SrcAlgorithm.LeadUsable;
                        _Algorithm.ForeGround   = _SrcAlgorithm.ForeGround;
                        _Algorithm.ThresholdMin = _SrcAlgorithm.ThresholdMin;
                        _Algorithm.ThresholdMax = _SrcAlgorithm.ThresholdMax;
                        _Algorithm.BlobAreaMin  = _SrcAlgorithm.BlobAreaMin;
                        _Algorithm.BlobAreaMax  = _SrcAlgorithm.BlobAreaMax;
                        _Algorithm.WidthMin     = _SrcAlgorithm.WidthMin;
                        _Algorithm.WidthMax     = _SrcAlgorithm.WidthMax;
                        _Algorithm.HeightMin    = _SrcAlgorithm.HeightMin;
                        _Algorithm.HeightMax    = _SrcAlgorithm.HeightMax;
                        _Algorithm.OriginX      = _SrcAlgorithm.OriginX;
                        _Algorithm.OriginY      = _SrcAlgorithm.OriginY;
                        _Algorithm.IsShowBoundary = _SrcAlgorithm.IsShowBoundary;

                        _Algorithm.LeadBent = _SrcAlgorithm.LeadBent;
                        _Algorithm.LeadBentMin = _SrcAlgorithm.LeadBentMin;
                        _Algorithm.LeadBentMax = _SrcAlgorithm.LeadBentMax;
                        _Algorithm.LeadPitch = _SrcAlgorithm.LeadPitch;
                        _Algorithm.LeadPitchMin = _SrcAlgorithm.LeadPitchMin;
                        _Algorithm.LeadPitchMax = _SrcAlgorithm.LeadPitchMax;

                        _Algorithm.IsLeadBentInspection = _SrcAlgorithm.IsLeadBentInspection;
                        _Algorithm.IsLeadPitchInspection = _SrcAlgorithm.IsLeadPitchInspection;

                        _InspAlgoParam.Algorithm = _Algorithm;
                    }

                    else if (eAlgoType.C_ID == _AlgoType)
                    {
                        var _Algorithm = _InspAlgoParam.Algorithm as CogBarCodeIDAlgo;
                        var _SrcAlgorithm = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm as CogBarCodeIDAlgo;

                        _Algorithm = new CogBarCodeIDAlgo();
                        _Algorithm.Symbology = _SrcAlgorithm.Symbology;
                        _Algorithm.OriginX = _SrcAlgorithm.OriginX;
                        _Algorithm.OriginY = _SrcAlgorithm.OriginY;
                        _Algorithm.TimeLimit = _SrcAlgorithm.TimeLimit;
                        _Algorithm.FindCount = _SrcAlgorithm.FindCount;

                        _InspAlgoParam.Algorithm = _Algorithm;
                    }

                    else if (eAlgoType.C_LINE_FIND == _AlgoType)
                    {
                        var _Algorithm = _InspAlgoParam.Algorithm as CogLineFindAlgo;
                        var _SrcAlgorithm = _SrcParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].Algorithm as CogLineFindAlgo;

                        _Algorithm = new CogLineFindAlgo();
                        _Algorithm.CaliperNumber = _SrcAlgorithm.CaliperNumber;
                        _Algorithm.CaliperSearchLength = _SrcAlgorithm.CaliperSearchLength;
                        _Algorithm.CaliperProjectionLength = _SrcAlgorithm.CaliperProjectionLength;
                        _Algorithm.CaliperSearchDirection = _SrcAlgorithm.CaliperSearchDirection;
                        _Algorithm.IgnoreNumber = _SrcAlgorithm.IgnoreNumber;
                        _Algorithm.CaliperLineStartX = _SrcAlgorithm.CaliperLineStartX;
                        _Algorithm.CaliperLineStartY = _SrcAlgorithm.CaliperLineStartY;
                        _Algorithm.CaliperLineEndX = _SrcAlgorithm.CaliperLineEndX;
                        _Algorithm.CaliperLineEndY = _SrcAlgorithm.CaliperLineEndY;
                        _Algorithm.ContrastThreshold = _SrcAlgorithm.ContrastThreshold;
                        _Algorithm.FilterHalfSizePixels = _SrcAlgorithm.FilterHalfSizePixels;
                        _Algorithm.UseAlignment = _SrcAlgorithm.UseAlignment;

                        _InspAlgoParam.Algorithm = _Algorithm;
                    }

                    _InspAreaParam.InspAlgoParam.Add(_InspAlgoParam);
                }
                _DestParam.InspAreaParam.Add(_InspAreaParam);
            }
        }
        #endregion RecipeCopy
    }
}
