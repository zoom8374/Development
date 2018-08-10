using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParameterManager;

namespace DIOControlManager
{

    public class DIOBaseCommand
    {
        protected int IOCount = 8;
        protected int[] InCmdArray;
        protected int[] OutCmdArray;

        public DIOBaseCommand(int _IOCount = 8)
        {
            IOCount = _IOCount;
            InCmdArray = new int[IOCount];
            OutCmdArray = new int[IOCount];
        }

        public int InputBitCheck(int _BitNumber)
        {
            int _ReturnBit = 0;
            _ReturnBit = InCmdArray[_BitNumber];
            return _ReturnBit;
        }

        public int OutputBitCheck(int _BitNumber)
        {
            int _ReturnBit = 0;
            _ReturnBit = OutCmdArray[_BitNumber];
            return _ReturnBit;
        }

        public int OutputBitIndexCheck(int _CheckBit)
        {
            int _ReternIndex = 7;
            
            for (int iLoopCount = 0; iLoopCount < OutCmdArray.Length; ++iLoopCount)
            {
                if (OutCmdArray[iLoopCount] == _CheckBit)
                {
                    _ReternIndex = iLoopCount;
                    break;
                }
            }
            return _ReternIndex;
        }
    }

    public class AirBlowCmd : DIOBaseCommand
    {
        //private static readonly int NONE = -1;
        public static readonly int LIVE = 0;
        public static readonly int TRIGGER = 5;
        public static readonly int REQUEST = 7;
        
        public static readonly int OUT_LIVE = 0;
        public static readonly int OUT_AUTO = 1;
        public static readonly int OUT_READY = 2;
        public static readonly int OUT_COMPLETE = 3;

        public AirBlowCmd()
        {
            InCmdArray = new int[IOCount];
            OutCmdArray = new int[IOCount];
            for (int iLoopCount = 0; iLoopCount < IOCount; ++iLoopCount) InCmdArray[iLoopCount] = DIO_DEF.NONE;

            InCmdArray[LIVE]    = DIO_DEF.IN_LIVE;
            InCmdArray[TRIGGER] = DIO_DEF.IN_TRG1;
            InCmdArray[REQUEST] = DIO_DEF.IN_REQUEST;

            OutCmdArray[OUT_LIVE]     = DIO_DEF.OUT_LIVE;
            OutCmdArray[OUT_AUTO]     = DIO_DEF.OUT_AUTO;
            OutCmdArray[OUT_READY]    = DIO_DEF.OUT_READY;
            OutCmdArray[OUT_COMPLETE] = DIO_DEF.OUT_COMPLETE;
        }
    }

    public class LeadCmd : DIOBaseCommand
    {
        //public static readonly int NONE = -1;
        private static readonly int IN_LIVE = 0;
        private static readonly int IN_RESET = 1;
        private static readonly int IN_TRIGGER = 2;
        private static readonly int IN_REQUEST = 3;

        private static readonly int OUT_LIVE = 0;
        private static readonly int OUT_AUTO = 1;
        private static readonly int OUT_READY = 2;
        private static readonly int OUT_COMPLETE = 3;

        public LeadCmd()
        {
            InCmdArray = new int[IOCount];
            for (int iLoopCount = 0; iLoopCount < 8; ++iLoopCount) InCmdArray[iLoopCount] = DIO_DEF.NONE;

            InCmdArray[IN_LIVE]    = DIO_DEF.IN_LIVE;
            InCmdArray[IN_RESET]   = DIO_DEF.IN_RESET;
            InCmdArray[IN_TRIGGER] = DIO_DEF.IN_TRG1;
            InCmdArray[IN_REQUEST] = DIO_DEF.IN_REQUEST;


            OutCmdArray = new int[IOCount];
            for (int iLoopCount = 0; iLoopCount < IOCount; ++iLoopCount) OutCmdArray[iLoopCount] = DIO_DEF.NONE;

            OutCmdArray[OUT_LIVE]     = DIO_DEF.OUT_LIVE;
            OutCmdArray[OUT_AUTO]     = DIO_DEF.OUT_AUTO;
            OutCmdArray[OUT_READY]    = DIO_DEF.OUT_READY;
            OutCmdArray[OUT_COMPLETE] = DIO_DEF.OUT_COMPLETE;
        }
    }
}
