using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManager
{
    public class TeachParam
    {
        public class BlobReferTeachParam
        {
            public int RangeType;
            public int Foreground;
            public int ThresholdMin;
            public int ThresholdMax;
            public int BlobAreaMin;
            public int BlobAreaMax;
            public double BlobWidthMin;
            public double BlobWidthMax;
            public double BlobHeightMin;
            public double BlobHeightMax;
            public int BenchMarkPosition;
        }

        public class BlobReferTeachReturnParam
        {
            public double OriginX;
            public double OriginY;
            public double Width;
            public double Height;

            public BlobReferTeachReturnParam()
            {
                OriginX = 0;
                OriginY = 0;
                Width = 0;
                Height = 0;
            }
        }
    }
}
