﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParameterManager;

namespace DIOControlManager
{
    public class SignalToggleData
    {
        public short Signal;
        public int ToggleTime;
        public bool  CurrentSignal;
    }

    public class DIOBaseCommand
    {
        protected int IOCount = 16;
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
            int _ReternIndex = 0;
            
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
        public static readonly int IN_LIVE = 0;
        public static readonly int IN_TRIGGER = 5;
        public static readonly int IN_REQUEST = 7;
        
        public static readonly int OUT_LIVE = 0;
        public static readonly int OUT_AUTO = 1;
        public static readonly int OUT_READY = 2;
        public static readonly int OUT_COMPLETE = 3;

        public AirBlowCmd(int _IOCount)
        {
            IOCount = _IOCount;

            InCmdArray = new int[IOCount];
            OutCmdArray = new int[IOCount];
            for (int iLoopCount = 0; iLoopCount < IOCount; ++iLoopCount) InCmdArray[iLoopCount] = DIO_DEF.NONE;

            InCmdArray[IN_LIVE]       = DIO_DEF.IN_LIVE;
            InCmdArray[IN_TRIGGER]    = DIO_DEF.IN_TRG;
            InCmdArray[IN_REQUEST]    = DIO_DEF.IN_REQUEST;

            OutCmdArray[OUT_LIVE]     = DIO_DEF.OUT_LIVE;
            OutCmdArray[OUT_AUTO]     = DIO_DEF.OUT_AUTO;
            OutCmdArray[OUT_READY]    = DIO_DEF.OUT_READY;
            OutCmdArray[OUT_COMPLETE] = DIO_DEF.OUT_COMPLETE;
        }
    }

    public class DispenserCmd : DIOBaseCommand
    {
        //public static readonly int NONE = -1;
        public static readonly int IN_LIVE = 0;
        
        public static readonly int IN_RESET        = 5;
        public static readonly int IN_TRIGGER      = 6;
        public static readonly int IN_REQUEST      = 7;
        
        public static readonly int IN_RESET_2      = 8;
        public static readonly int IN_TRIGGER_2    = 9;
        public static readonly int IN_REQUEST_2    = 10;
        public static readonly int IN_RESET_3      = 11;
        public static readonly int IN_TRIGGER_3    = 12;
        public static readonly int IN_REQUEST_3    = 13;
        
        public static readonly int OUT_LIVE = 0;
        public static readonly int OUT_AUTO = 1;

        public static readonly int OUT_READY        = 8;
        public static readonly int OUT_COMPLETE     = 9;

        public static readonly int OUT_READY_2      = 10;
        public static readonly int OUT_COMPLETE_2   = 11;
        public static readonly int OUT_READY_3      = 12;
        public static readonly int OUT_COMPLETE_3   = 13;

        public DispenserCmd(int _IOCount)
        {
            IOCount = _IOCount;

            InCmdArray = new int[IOCount];
            for (int iLoopCount = 0; iLoopCount < _IOCount; ++iLoopCount) InCmdArray[iLoopCount] = DIO_DEF.NONE;

            InCmdArray[IN_LIVE]    = DIO_DEF.IN_LIVE;
            InCmdArray[IN_RESET]   = DIO_DEF.IN_RESET;
            InCmdArray[IN_TRIGGER] = DIO_DEF.IN_TRG;
            InCmdArray[IN_REQUEST] = DIO_DEF.IN_REQUEST;
            InCmdArray[IN_RESET_2]   = DIO_DEF.IN_RESET_2;
            InCmdArray[IN_TRIGGER_2] = DIO_DEF.IN_TRG_2;
            InCmdArray[IN_REQUEST_2] = DIO_DEF.IN_REQUEST_2;
            InCmdArray[IN_RESET_3]   = DIO_DEF.IN_RESET_3;
            InCmdArray[IN_TRIGGER_3] = DIO_DEF.IN_TRG_3;
            InCmdArray[IN_REQUEST_3] = DIO_DEF.IN_REQUEST_3;


            OutCmdArray = new int[IOCount];
            for (int iLoopCount = 0; iLoopCount < IOCount; ++iLoopCount) OutCmdArray[iLoopCount] = DIO_DEF.NONE;

            OutCmdArray[OUT_LIVE]     = DIO_DEF.OUT_LIVE;
            OutCmdArray[OUT_AUTO]     = DIO_DEF.OUT_AUTO;
            OutCmdArray[OUT_READY]    = DIO_DEF.OUT_READY;
            OutCmdArray[OUT_COMPLETE]   = DIO_DEF.OUT_COMPLETE;
            OutCmdArray[OUT_READY_2]    = DIO_DEF.OUT_READY_2;
            OutCmdArray[OUT_COMPLETE_2] = DIO_DEF.OUT_COMPLETE_2;
            OutCmdArray[OUT_READY_3]    = DIO_DEF.OUT_READY_3;
            OutCmdArray[OUT_COMPLETE_3] = DIO_DEF.OUT_COMPLETE_3;
        }
    }
}
