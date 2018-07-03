using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum DIOEnum
{
    IO_CHANNEL = 8,

    OFF = 0,
    ON = 1
}

namespace DIOControlManager
{
    public class CDIO
    {
        private CContecIOControl ContecIOControl = new CContecIOControl();

        private short[] InBitNumberDef = null;
        private short[] OutBitNumberDef = null;
        private byte[] InMultiBitDataDef = null;
        private byte[] OutMultiBitDataDef = null;
        private short ID = 0;

        public CDIO()
        {

        }

        public int Initialize()
        {
            int iResult = ContecIOControl.Init("DIO000", out ID);
            if (iResult != (int)CDioConst.DIO_ERR_SUCCESS) InitializeDefaultMultiBit();

            return iResult;
        }

        private void InitializeDefaultMultiBit()
        {
            InBitNumberDef = new short[(int)DIOEnum.IO_CHANNEL];
            OutBitNumberDef = new short[(int)DIOEnum.IO_CHANNEL];
            InMultiBitDataDef = new byte[(int)DIOEnum.IO_CHANNEL];
            OutMultiBitDataDef = new byte[(int)DIOEnum.IO_CHANNEL];
            for(int iLoopCount = 0; iLoopCount < (int)DIOEnum.IO_CHANNEL; iLoopCount++)
            {
                InBitNumberDef[iLoopCount] = (short)iLoopCount;
                OutBitNumberDef[iLoopCount] = (short)iLoopCount;
            }
        }

        public void DeInitialize()
        {
            ContecIOControl.Exit(ID);
        }

        public int InputBitData(short _BitNumber, out byte _BitData)
        {
            int iResult = ContecIOControl.InpBit(ID, _BitNumber, out _BitData);
            if(iResult != (int)CDioConst.DIO_ERR_SUCCESS) iResult = -1;
            return iResult;
        }

        public int InputMultiBitData(short[] _BitNumbers, short _BitCount, byte[] _BitData)
        {
            int iResult = ContecIOControl.InpMultiBit(ID, _BitNumbers, _BitCount, _BitData);
            if (iResult != (int)CDioConst.DIO_ERR_SUCCESS) return -1;
            return iResult;
        }

        public int OutputBitData(short _BitNumber, byte _BitData)
        {
            int iResult = ContecIOControl.OutBit(ID, _BitNumber, _BitData);
            if (iResult != (int)CDioConst.DIO_ERR_SUCCESS) iResult = -1;

            return iResult;
        }

        public int OutputMultiBitData(short[] _BitNumbers, short _BitCount, byte[] _BitData)
        {
            int iResult = ContecIOControl.OutMultiBit(ID, _BitNumbers, _BitCount, _BitData);
            if (iResult != (int)CDioConst.DIO_ERR_SUCCESS) return -1;
            return iResult;
        }

        public int OutputEchoBackMultiBitData(short[] _BitNumbers, short _BitCount, byte[] _BitData)
        {
            int iResult = ContecIOControl.EchoBackMultiBit(ID, _BitNumbers, _BitCount, _BitData);
            if (iResult != (int)CDioConst.DIO_ERR_SUCCESS) return -1;
            return iResult;
        }
    }
}
