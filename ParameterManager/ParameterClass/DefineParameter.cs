﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManager
{
    public enum eSysMode { AUTO_MODE = 1, MANUAL_MODE = 2, ONESHOT_MODE = 3, TEACH_MODE = 4, LIVE_MODE }

    /// <summary>
    /// Project Type
    /// </summary>
    public enum eProjectType { NONE = 0, DISPENSER, BLOWER };

    /// <summary>
    /// Project Item
    /// </summary>
    public enum eProjectItem { NEEDLE_ALIGN = 0, LEAD_INSP, ID_INSP};

    /// <summary>
    /// Algorithm Type
    /// </summary>
    public enum eAlgoType   { C_NONE = -1, C_PATTERN, C_BLOB_REFER, C_BLOB, C_LEAD, C_NEEDLE_FIND, C_ID, C_LINE_FIND }

    /// <summary>
    /// Camera Model Type
    /// </summary>
    public enum eCameraType { Dalsa, Euresys, BaslerGE }

    /// <summary>
    /// 
    /// </summary>
    public enum eMainProcCmd { TRG = 1, REQUEST, RCP_CHANGE, LOT_CHANGE, ACK_COMPLETE, ACK_FAIL }

    /// <summary>
    /// Inspection Window Command
    /// </summary>
    public enum eIWCMD      { TEACHING = 1, TEACH_OK, TEACH_SAVE, ONESHOT_INSP, SET_RESULT, SEND_DATA, INSP_COMPLETE, LIGHT_CONTROL  }

    /// <summary>
    /// Inspection System Manager To Main Command
    /// </summary>
    public enum eISMCMD     { TEACHING_STATUS = 1, TEACHING_SAVE, SET_RESULT, SEND_DATA, INSP_COMPLETE, LIGHT_CONTROL }

    /// <summary>
    /// Teaching Step
    /// </summary>
    public enum eTeachStep  { AREA_SELECT = 0, AREA_SET, AREA_CLEAR, ALGO_SELECT, ALGO_SET, ALGO_CLEAR };

    /// <summary>
    /// NG Type
    /// </summary>
    public enum eNgType     { GOOD = 0, NONE, DUMMY, REF_NG, DEFECT, CRACK, RESIN, ID, EMPTY, LEAD_BENT, NDL_CENTER, NDL_FIND }

    public enum eMorphologyMode { ERODE = 0, DILATE, OPEN, CLOSE, }

    public enum eBenchMarkPosition { TL = 0, TC, TR, ML, MC, MR, BL, BC, BR, GC };

    public enum eForeColor          { BLACK = 0, WHITE = 1 };

    public enum eSearchDirection    { IN_WARD = 0, OUT_WARD = 1 };

    public enum eInspMode           { TRI_INSP = 0, ONE_INSP, SINGLE_INSP, SIMUL_INSP };

    public enum eReferAction        { ADD = 0, DEL, MODIFY };

    public enum eSaveMode           { ALL = 0, ONLY_NG };

    public static class DIO_DEF
    {
        public const int NONE = -1;

        public const int OUT_LIVE = 0;
        public const int OUT_AUTO = 1;
        public const int OUT_ALARM = 2;

        public const int OUT_READY      = 3;
        public const int OUT_COMPLETE   = 4;
        public const int OUT_READY_2    = 5;
        public const int OUT_COMPLETE_2 = 6;
        public const int OUT_READY_3    = 7;
        public const int OUT_COMPLETE_3 = 8;

        public const int OUT_RESULT_1   = 9;
        public const int OUT_RESULT_2   = 10;
        public const int OUT_RESULT_3   = 11;

        public const int IN_LIVE        = 0;
        public const int IN_ALARM_OFF   = 1;
        public const int IN_MODE        = 2;

        public const int IN_RESET       = 3;
        public const int IN_TRG         = 4;
        public const int IN_REQUEST     = 5;
        public const int IN_RESET_2     = 6;
        public const int IN_TRG_2       = 7;
        public const int IN_REQUEST_2   = 8;
        public const int IN_RESET_3     = 9;
        public const int IN_TRG_3       = 10;
        public const int IN_REQUEST_3   = 11;
    }

    public static class SIGNAL
    {
        public const int OFF = 0;
        public const int ON = 1;
    }

    public static class LIGHT
    {
        public const int OFF = 0;
        public const int ON = 1;
    }
}
