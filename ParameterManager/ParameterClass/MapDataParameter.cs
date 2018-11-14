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
        public string UnitPatternPath;
        public uint UnitRowCount;
        public uint UnitColumnCount;
        public uint SectionRowCount;
        public uint SectionColumnCount;
        public uint UnitTotalCount
        {
            get { return UnitRowCount * UnitColumnCount; }
            set { value = UnitRowCount * UnitColumnCount; }
        }

        /// <summary>
        /// 0 : ManualMode / 1 : Auto MOde
        /// </summary>
        public int MapDataTeachingMode;

        // Auto Search Mode == Pattern으로 찾기
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

        //Manual Search Mode == 영역지정으로 설정하기
        public double WholeSearchAreaCenterX;
        public double WholeSearchAreaCenterY;
        public double WholeSearchAreaWidth;
        public double WholeSearchAreaHeight;

        public List<double> UnitListCenterX;
        public List<double> UnitListCenterY;
        public List<double> UnitListWidth;
        public List<double> UnitListHeight;

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

            MapDataTeachingMode = 0;

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

            WholeSearchAreaCenterX = 800;
            WholeSearchAreaCenterY = 800;
            WholeSearchAreaWidth = 500;
            WholeSearchAreaHeight = 700;

            UnitListCenterX = new List<double>();
            UnitListCenterY = new List<double>();
            UnitListWidth = new List<double>();
            UnitListHeight = new List<double>();

            FindCount = UnitTotalCount;
            FindScore = 75;
            AngleLimit = 5;
        }
    }
}
