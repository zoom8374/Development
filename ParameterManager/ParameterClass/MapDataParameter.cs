using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro.PMAlign;

namespace ParameterManager
{
    public class MapDataParameter
    {
        public CogPMAlignPattern UnitPattern;

        public int UnitTotalCount;
        public int UnitRowCount;
        public int UnitColumnCount;
        public int SectionRowCount;
        public int SectionColumnCount;

        public double UnitSearchAreaCenterX;
        public double UnitSearchAreaCenterY;
        public double UnitSearchAreaWidth;
        public double UnitSearchAreaHeight;
        public double UnitPatternAreaX;
        public double UnitPatternAreaY;
        public double UnitPatternAreaWidth;
        public double UnitPatternAreaHeight;

        public double[] UnitListCenterX;
        public double[] UnitListCenterY;

        public int FindCount;
        public double FindScore;
        public double AngleLimit;

        public MapDataParameter()
        {
            UnitTotalCount = 1;
            UnitRowCount = 1;
            UnitColumnCount = 1;
            SectionRowCount = 1;
            SectionColumnCount = 1;

            UnitSearchAreaCenterX = 300;
            UnitSearchAreaCenterY = 300;

            UnitSearchAreaWidth = 200;
        }
    }
}
