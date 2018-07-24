using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;

namespace ParameterManager
{
    #region AreaResultParameterList
    public class AreaResultParameter
    {
        public double OffsetX;
        public double OffsetY;

        public AreaResultParameter()
        {
            OffsetX = 0;
            OffsetY = 0;
        }
    }

    public class AreaResultParameterList : List<AreaResultParameter>
    {

    }
    #endregion AreaResultParameterList

    #region AlgoResultParameterList
    public class AlgoResultParameter
    {
        public Object ResultParam;
        public eAlgoType ResultAlgoType;
        public double OffsetX;
        public double OffsetY;
        public int NgAreaNumber;

        public double TeachOriginX;
        public double TeachOriginY;

        public AlgoResultParameter()
        {
            OffsetX = 0;
            OffsetY = 0;
            ResultAlgoType = eAlgoType.C_NONE;
            ResultParam = null;

            TeachOriginX = 0;
            TeachOriginY = 0;
        }

        public AlgoResultParameter(eAlgoType _AlgoType, Object _ResultParam)
        {
            ResultParam = _ResultParam;
            ResultAlgoType = _AlgoType;

            OffsetX = 0;
            OffsetY = 0;
            TeachOriginX = 0;
            TeachOriginY = 0;
        }
    }

    public class AlgoResultParameterList : List<AlgoResultParameter>
    {

    }
    #endregion AlgoResultParameterList

    #region Inspection Result Parameter
    public class Result
    {
        public bool     IsGood;
        public eNgType  NgType;
    }

    public class CogPatternResult : Result
    {
        public int FindCount;

        public double[] Score;
        public double[] Scale;
        public double[] Angle;
        public double[] CenterX;
        public double[] CenterY;
        public double[] OriginPointX;
        public double[] OriginPointY;
        public double[] Width;
        public double[] Height;

        public CogPatternResult()
        {
            IsGood = true;
            NgType = eNgType.GOOD;

            FindCount = 0;
        }
    }

    public class CogBlobReferenceResult : Result
    {
        public int      BlobCount;
        public double[] BlobMessCenterX;
        public double[] BlobMessCenterY;
        
        public double[] BlobCenterX;
        public double[] BlobCenterY;
        public double[] BlobMinX;
        public double[] BlobMinY;
        public double[] BlobMaxX;
        public double[] BlobMaxY;
        public double[] Width;
        public double[] Height;
        public double[] BlobRatio;
        public double[] Angle;
        public double[] BlobXMinYMax;
        public double[] BlobXMaxYMin;
        public double[] BlobArea;
        public double[] OriginX;
        public double[] OriginY;
        public bool[] IsGoods;
        public CogCompositeShape[] ResultGraphic;
    }

    public class CogNeedleFindResult : Result
    {
        public double CenterX;
        public double CenterY;
        public double OriginX;
        public double OriginY;

        public double Radius;
    }

    public class CogLeadResult : Result
    {
        public int BlobCount;
        public double[] BlobArea;
        public double[] BlobCenterX;
        public double[] BlobCenterY;
        public double[] BlobMinX;
        public double[] BlobMinY;
        public double[] BlobMaxX;
        public double[] BlobMaxY;
        public double[] Width;
        public double[] Height;

        public double[] BlobMessCenterX;
        public double[] BlobMessCenterY;
        public double[] PrincipalWidth;
        public double[] PrincipalHeight;
        public double[] Angle;
        public double[] Degree;

        public CogCompositeShape[] ResultGraphic;

        public double OriginX;
        public double OriginY;

        //Lead 검사에 필요한 Parameter
        public int LeadCount;
        public double LeadPitchAvg;
        public double LeadAngleAvg;
        public bool[] IsLeadBentGood;
        public double[] LeadPitchTopX;
        public double[] LeadPitchTopY;
        public double[] LeadPitchBottomX;
        public double[] LeadPitchBottomY;

        public double[] LeadLength;
        public double[] LeadLengthStartX;
        public double[] LeadLengthStartY;

        public CogLeadResult()
        {
            IsGood = true;
            NgType = eNgType.GOOD;
        }
    }

    public class CogBarCodeIDResult : Result
    {
        public int IDCount;
        public string[] IDResult;
        public double[] IDCenterX;
        public double[] IDCenterY;
        public double[] IDAngle;
        public CogPolygon[] IDPolygon;
    }

    public class CogLineFindResult : Result
    {
        public double StartX;
        public double StartY;
        public double EndX;
        public double EndY;
        public double Length;
        public double Rotation;
        public int PointCount;
        public bool[] PointStatus;
    }
    #endregion Inspection Result Parameter

    #region Last Send Result Parameter
    public class SendResultParameter
    {
        public eProjectItem ProjectItem;
        public eInspMode InspMode;
        public int ID;
        public bool IsGood;
        public eNgType NgType;

        public object SendResult;
    }

    public class SendIDResult
    {
        public string ReadCode;
    }

    public class SendNeedleAlignResult
    {
        public double AlignX;
        public double AlignY;
    }

    public class SendLeadResult
    {
        public int LeadCount;
        public double BodyReferenceX;
        public double BodyReferenceY;
        public bool[] IsLeadBendGood;
        public double[] LeadAngle;
        public double[] LeadLength;
        public double[] LeadWidth;
        public double[] LeadPitch;
        public double[] LeadPitchTopX;
        public double[] LeadPitchTopY;
    }
    #endregion Last Send Result Parameter
}
