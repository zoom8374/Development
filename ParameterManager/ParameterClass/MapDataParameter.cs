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

        public uint UnitTotalCount;
        public uint UnitRowCount;
        public uint UnitColumnCount;
        public uint SectionRowCount;
        public uint SectionColumnCount;

        public double UnitSearchAreaCenterX;
        public double UnitSearchAreaCenterY;
        public double UnitSearchAreaWidth;
        public double UnitSearchAreaHeight;
        public double UnitPatternAreaOriginX;
        public double UnitPatternAreaOriginY;
        public double UnitPatternAreaCenterX;
        public double UnitPatternAreaCenterY;
        public double UnitPatternAreaWidth;
        public double UnitPatternAreaHeight;

        //public double[] UnitListCenterX;
        //public double[] UnitListCenterY;
        public List<double> UnitListCenterX;
        public List<double> UnitListCenterY;

        public uint FindCount;
        public double FindScore;
        public double AngleLimit;

        public MapDataParameter()
        {
            UnitTotalCount = 1;
            UnitRowCount = 1;
            UnitColumnCount = 1;
            SectionRowCount = 1;
            SectionColumnCount = 1;

            UnitSearchAreaCenterX = 500;
            UnitSearchAreaCenterY = 500;
            UnitSearchAreaWidth = 300;
            UnitSearchAreaHeight = 300;

            UnitPatternAreaOriginX = 500;
            UnitPatternAreaOriginY = 500;
            UnitPatternAreaCenterX = 500;
            UnitPatternAreaCenterY = 500;
            UnitPatternAreaWidth = 200;
            UnitPatternAreaHeight = 200;

            //UnitListCenterX = new double[UnitTotalCount];
            //UnitListCenterY = new double[UnitTotalCount];
            UnitListCenterX = new List<double>();
            UnitListCenterY = new List<double>();

            FindCount = UnitTotalCount;
            FindScore = 75;
            AngleLimit = 5;
        }
    }
}
