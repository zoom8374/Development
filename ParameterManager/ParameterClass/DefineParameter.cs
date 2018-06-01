using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManager
{
    /// <summary>
    /// Project Type
    /// </summary>
    public enum eProjectType { DISPENSER = 0 };

    /// <summary>
    /// Project Item
    /// </summary>
    public enum eProjectItem { NEEDLE_ALIGN = 0, LEAD_INSP };

    /// <summary>
    /// Algorithm Type
    /// </summary>
    public enum eAlgoType   { C_NONE = -1, C_PATTERN, C_BLOB_REFER, C_BLOB, C_LEAD_BENT }

    /// <summary>
    /// Inspection Window Command
    /// </summary>
    public enum eIWCMD      { TEACHING = 1, TEACH_OK, TEACH_SAVE  }

    /// <summary>
    /// Inspection System Manager To Main Command
    /// </summary>
    public enum eISMCMD     { TEACHING_STATUS = 1, TEACHING_SAVE }

    /// <summary>
    /// Teaching Setp
    /// </summary>
    public enum eTeachStep  { AREA_SELECT = 0, AREA_SET, AREA_CLEAR, ALGO_SELECT, ALGO_SET, ALGO_CLEAR };

    public enum eNgType     { GOOD = 0, REF_NG, DEFECT, CRACK, RESIN }

    public enum eMorphologyMode { ERODE = 0, DILATE, OPEN, CLOSE, }

    public enum eBenchMarkPosition { TL = 0, TC, TR, ML, MC, MR, BL, BC, BR, GC };

    public enum eForeColor          { BLACK = 0, WHITE = 1 };
}
