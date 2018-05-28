using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    class ResultParameter
    {
    }
}
