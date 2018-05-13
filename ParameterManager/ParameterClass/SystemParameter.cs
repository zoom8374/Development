using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManager
{
    public class SystemParameter
    {
        public int      MachineNumber;
        public bool     IsProgramUsable;
        public bool     IsSimulationMode;
        public string   LastRecipeName;
        public int      InspSystemManagerCount;
        public int      ProjectType;
        public int      ProjectItem;
        //public int      LightType;
        //public int      LightCount;
        //public int[]    LightValues;
        //public int      LightSleep;
        public string   IPAddress;
        public int      PortNumber;

        public SystemParameter()
        {
            MachineNumber = 1;
            IsProgramUsable = false;
            IsSimulationMode = true;
            LastRecipeName = "Default";
            InspSystemManagerCount = 1;
            ProjectType = 0;
            ProjectItem = 0;
            //LightType = 0;
            //LightCount = 1;
            //LightSleep = 10;

            IPAddress = "192.168.0.100";
            PortNumber = 5050;
        }
    }
}
