using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManager
{
    #region Reference class
    public class ReferenceInformation
    {
        //public MIL_ID Reference;
        public Object Reference;
        public string ReferencePath;
        public double InterActiveStartX;
        public double InterActiveStartY;
        public double StaticStartX;
        public double StaticStartY;
        public double CenterX;
        public double CenterY;
        public double OriginPointOffsetX;
        public double OriginPointOffsetY;
        public double Width;
        public double Height;
    }

    public class References : List<ReferenceInformation>
    {

    }
    #endregion Reference class

    #region Cog Algorithm Class
    /// <summary>
    /// Pattern 매칭 알고리즘
    /// </summary>
    public class CogPatternAlgo
    {
        public References ReferenceInfoList;
        public int PatternCount;
        public double MatchingScore;
        public double MatchingAngle;
        public int MatchingCount;
        public bool IsShift;
        public double AllowedShiftX;
        public double AllowedShiftY;

        public CogPatternAlgo()
        {
            ReferenceInfoList = new References();
            ReferenceInfoList.Clear();

            MatchingScore = 75;
            MatchingAngle = 1.0;
            MatchingCount = 1;
            IsShift = false;
            AllowedShiftX = 1;
            AllowedShiftY = 1;
        }
    }

    /// <summary>
    /// Blob Reference Algorithm
    /// </summary>
    public class CogBlobReferenceAlgo
    {
        //Condition Parameter
        public int ForeGround;
        public int ThresholdMin;
        public int ThresholdMax;
        public double BlobAreaMin;
        public double BlobAreaMax;
        public double WidthMin;
        public double WidthMax;
        public double HeightMin;
        public double HeightMax;
        public double OriginX;
        public double OriginY;

        public double BodyArea;
        public double BodyWidth;
        public double BodyHeight;
        public double BodyAreaPermitPercent;
        public double BodyWidthPermitPercent;
        public double BodyHeightPermitPercent;
        public bool UseBodyArea;
        public bool UseBodyWidth;
        public bool UseBodyHeight;

        public int BenchMarkPosition;

        public CogBlobReferenceAlgo()
        {
            ForeGround = 1;
            ThresholdMin = 80;
            ThresholdMax = 200;
            BlobAreaMin = 1000;
            BlobAreaMax = 9000000;
            WidthMin = 5;
            WidthMax = 200;
            HeightMin = 5;
            HeightMax = 200;

            BenchMarkPosition = 4;
        }
    }

    /// <summary>
    /// Blob 검사 알고리즘
    /// </summary>
    public class CogBlobAlgo
    {
        public int ForeGround;
        public int ThresholdMin;
        public int ThresholdMax;
        public double BlobAreaMin;
        public double BlobAreaMax;
        public double WidthMin;
        public double WidthMax;
        public double HeightMin;
        public double HeightMax;
        public double OriginX;
        public double OriginY;

        public int BenchMarkPosition;

        public CogBlobAlgo()
        {
            ForeGround = 0;
            ThresholdMin = 50;
            ThresholdMax = 200;
            BlobAreaMin = 5000;
            BlobAreaMax = 9000000;
            WidthMin = 5;
            WidthMax = 200;
            HeightMin = 5;
            HeightMax = 200;

            BenchMarkPosition = 0;
        }
    }

    /// <summary>
    /// Lead - Bent 검사 알고리즘
    /// </summary>
    public class CogLeadAlgo
    {
        public int LeadCount;
        public double LeadPitch;
        public string LeadUsable;

        //Condition Parameter
        public int ForeGround;
        public int ThresholdMin;
        public int ThresholdMax;
        public double BlobAreaMin;
        public double BlobAreaMax;
        public double WidthMin;
        public double WidthMax;
        public double HeightMin;
        public double HeightMax;
        public double OriginX;
        public double OriginY;
        public bool IsShowwBoundary;

        public CogLeadAlgo()
        {
            LeadCount = 26;
            LeadUsable = "11111111111111111111111111";

            ForeGround = 1;
            ThresholdMin = 80;
            ThresholdMax = 200;
            BlobAreaMin = 1000;
            BlobAreaMax = 9000000;
            WidthMin = 5;
            WidthMax = 200;
            HeightMin = 5;
            HeightMax = 200;
        }
    }

    public class CogNeedleFindAlgo
    {
        public int CaliperNumber;
        public double CaliperSearchLength;
        public double CaliperProjectionLength;
        public int CaliperSearchDirection;

        public double ArcCenterX;
        public double ArcCenterY;
        public double ArcRadius;
        public double ArcAngleStart;
        public double ArcAngleSpan;

        public double OriginX;
        public double OriginY;
        public double OriginRadius;

        public CogNeedleFindAlgo()
        {
            CaliperNumber = 6;
            CaliperSearchLength = 30;
            CaliperProjectionLength = 10;
            CaliperSearchDirection = 1;

            ArcCenterX = 150;
            ArcCenterY = 50;
            ArcRadius = 100;
            ArcAngleStart = 0;
            ArcAngleSpan = 360;

            OriginX = 0;
            OriginY = 0;
            OriginRadius = 0;
        }
    }
    #endregion Cog Algorithm Class

    public class InspectionAlgorithmParameter
    {
        public int AlgoType;
        public int AlgoBenchMark;
        public double AlgoRegionCenterX = 100;
        public double AlgoRegionCenterY = 100;
        public double AlgoRegionWidth = 100;
        public double AlgoRegionHeight = 100;
        public bool AlgoEnable;
        public Object Algorithm;

        public InspectionAlgorithmParameter()
        {

        }

        public InspectionAlgorithmParameter(eAlgoType _AlgoType)
        {
            AlgoType = (int)_AlgoType;
            AlgoBenchMark = 0;
            AlgoEnable = true;

            if (_AlgoType == eAlgoType.C_PATTERN)           Algorithm = new CogPatternAlgo();
            else if (_AlgoType == eAlgoType.C_BLOB)         Algorithm = new CogBlobAlgo();
            else if (_AlgoType == eAlgoType.C_BLOB_REFER)   Algorithm = new CogBlobReferenceAlgo();
            else if (_AlgoType == eAlgoType.C_LEAD)         Algorithm = new CogLeadAlgo();
            else if (_AlgoType == eAlgoType.C_NEEDLE_FIND)  Algorithm = new CogNeedleFindAlgo();
        }
    }

    public class InspectionAreaParameter
    {
        public List<InspectionAlgorithmParameter> InspAlgoParam;

        public int AreaBenchMark = 0;
        public double AreaRegionCenterX = 300;
        public double AreaRegionCenterY = 300;
        public double AreaRegionWidth = 200;
        public double AreaRegionHeight = 200;
        public bool Enable = true;
        public int NgAreaNumber = 1;

        public InspectionAreaParameter()
        {
            InspAlgoParam = new List<InspectionAlgorithmParameter>();
        }
    }

    public class InspectionParameter
    {
        public List<InspectionAreaParameter> InspAreaParam;
        public double ResolutionX = 0.005;
        public double ResolutionY = 0.005;

        public InspectionParameter()
        {
            InspAreaParam = new List<InspectionAreaParameter>();
        }
    }
}
