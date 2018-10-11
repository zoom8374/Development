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
        public string   IPAddress;
        public int      PortNumber;

        public int ResultWindowLocationX;
        public int ResultWindowLocationY;
        public int ResultWindowWidth;
        public int ResultWindowHeight;

        //LDH, 2018.10.05, ID용 FolderPath 추가
        public string InDataFolderPath;
        public string OutDataFolderPath;

        public SystemParameter()
        {
            MachineNumber = 1;
            IsProgramUsable = false;
            IsSimulationMode = true;
            LastRecipeName = "Default";
            InspSystemManagerCount = 1;
            ProjectType = 0;

            ResultWindowLocationX = 1482;
            ResultWindowLocationY = 148;
            ResultWindowWidth = 421;
            ResultWindowHeight = 571;

            IPAddress = "192.168.0.100";
            PortNumber = 5050;
        }
    }
}
