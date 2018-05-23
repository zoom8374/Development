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
    public enum eAlgoType   { C_NONE = -1, C_PATTERN, C_BLOB, C_LEAD_BENT }

    /// <summary>
    /// Inspection Window Command
    /// </summary>
    public enum eIWCMD      { TEACHING = 1 }

    public enum eISMCMD     { TEACHING_STATUS = 1 }
}
