using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

using LogMessageManager;
using ParameterManager;

namespace DIOControlManager
{
    public partial class DIOControlWindow : Form
    {
        public CDIO DigitalIO = new CDIO();

        private readonly int ALIVE_SIGNAL_TIME = 0;
        private readonly int ALIVE_CHECK_TIME = 0;

        private short IOCnt = 8;
        private byte[] InputMultiSignal;
        private byte[] InputMultiSignalPre;
        private bool[] OutputSignalFlag = null;

        public bool IsShowWindow = false;
        public bool IsInitialize = false;

        Button[] btnInputSignal;
        Button[] btnOutputSignal;

        public delegate void InputChangedHandler(short _BitNum, bool _Signal);
        public event InputChangedHandler InputChangedEvent;

        private Thread ThreadInputIOCheck;
        private bool IsThreadInputIOCheckExit;
        private Thread ThreadOutputIOCheck;
        private bool IsThreadOutputIOCheckExit;

        private Thread ThreadVisionAliveSignal;
        private bool IsThreadVisionAliveSignalExit;
        private int VisionAliveSignalCount = 0;
        private bool VisionAliveSignalFlag = false;

        private Thread ThreadInputAliveCheck;
        private bool IsThreadInputAliveCheckExit;
        private int InputAliveCheckCount = 0;
        private bool InputAliveCheckFlag = false;

        public DIOControlWindow()
        {
            InitializeComponent();
            
            btnInputSignal = new Button[16] { btnInput0, btnInput1, btnInput2,  btnInput3,  btnInput4,  btnInput5,  btnInput6,  btnInput7,
                                              btnInput8, btnInput9, btnInput10, btnInput11, btnInput12, btnInput13, btnInput14, btnInput15 };

            btnOutputSignal = new Button[16] { btnOutput0, btnOutput1, btnOutput2,  btnOutput3,  btnOutput4,  btnOutput5,  btnOutput6,  btnOutput7,
                                               btnOutput8, btnOutput9, btnOutput10, btnOutput11, btnOutput12, btnOutput13, btnOutput14, btnOutput15 };
            OutputSignalFlag = new bool[16] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
            InputMultiSignal = new byte[IOCnt];
            InputMultiSignalPre = new byte[IOCnt];
        }

        #region Initialize & DeInitialize
        public bool Initialize()
        {
            bool _Result = true;

            InitializeIOBoard();

            ThreadInputIOCheck = new Thread(ThreadInputIOCheckFunc);
            IsThreadInputIOCheckExit = false;
            ThreadInputIOCheck.Start();

            ThreadOutputIOCheck = new Thread(ThreadOutputIOCheckFunc);
            IsThreadOutputIOCheckExit = false;
            ThreadOutputIOCheck.IsBackground = true;
            ThreadOutputIOCheck.Start();

            ThreadVisionAliveSignal = new Thread(ThreadVisionAliveSignalFunc);
            IsThreadVisionAliveSignalExit = false;
            ThreadVisionAliveSignal.Start();

            ThreadInputAliveCheck = new Thread(ThreadInputAliveCheckFunc);
            IsThreadInputAliveCheckExit = false;
            ThreadInputAliveCheck.Start();

            IsInitialize = true;

            return _Result;
        }

        public void DeInitialize()
        {
            DigitalIO.DeInitialize();
            IsInitialize = false;

            if (ThreadInputIOCheck != null)      { IsThreadInputIOCheckExit = true; Thread.Sleep(100); ThreadInputIOCheck.Abort(); ThreadInputIOCheck = null; }
            if (ThreadOutputIOCheck != null)     { IsThreadOutputIOCheckExit = true; Thread.Sleep(100); ThreadOutputIOCheck.Abort(); ThreadOutputIOCheck = null; }
            if (ThreadVisionAliveSignal != null) { IsThreadVisionAliveSignalExit = true; Thread.Sleep(100); ThreadVisionAliveSignal.Abort(); ThreadVisionAliveSignal = null; }
            if (ThreadInputAliveCheck != null)   { IsThreadInputAliveCheckExit = true; Thread.Sleep(100); ThreadInputAliveCheck.Abort(); ThreadInputAliveCheck = null; }
        }

        private void InitializeIOBoard()
        {
            if((int)CDioConst.DIO_ERR_SUCCESS != DigitalIO.Initialize())
            {
                MessageBox.Show("IO Board Initialize Error");
                return;
            }
        }
        #endregion Initialize & DeInitialize

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            //InputChangedEvent?.Invoke(DIOMAP.IN_TRG1, true); // 6.0부터

            //이렇게 쓰는것 보다는 아래와 같이 쓰는게 안정적
            //InputChangedEvent(DIOMAP.IN_TRG1, true);
            var _InputChangedEvent = InputChangedEvent;
            if (_InputChangedEvent != null) _InputChangedEvent(DIOMAP.IN_TRG1, true);
        }

        public void ShowDIOWindow()
        {
            IsShowWindow = true;
            this.Show();
        }

        #region Control Default Event
        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

            s.Parent.Left = this.Left + (e.X - ((Point)s.Tag).X);
            s.Parent.Top = this.Top + (e.Y - ((Point)s.Tag).Y);

            this.Cursor = Cursors.Default;
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            s.Tag = new Point(e.X, e.Y);
        }

        private void labelTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.labelTitle.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        #endregion Control Default Event

        private void btnOutput_Click(object sender, EventArgs e)
        {
            short _Tag = Convert.ToInt16(((Button)sender).Tag);
            SetOutputSignal(_Tag, !OutputSignalFlag[_Tag]);
        }

        private void SetOutputSignal(short _BitNumber, bool _Signal)
        {
            if (false == IsInitialize) return;

            OutputSignalFlag[_BitNumber] = _Signal;
            byte _Data = Convert.ToByte(OutputSignalFlag[_BitNumber]);
            DigitalIO.OutputBitData(_BitNumber, _Data);
        }

        private void InputSignalCheck()
        {
            if (false == IsInitialize) return;

            short[] _BitNum = new short[IOCnt];
            for (int iLoopCount = 0; iLoopCount < IOCnt; ++iLoopCount) _BitNum[iLoopCount] = (short)iLoopCount;

            if(DigitalIO.InputMultiBitData(_BitNum, IOCnt, InputMultiSignal)!= (int)CDioConst.DIO_ERR_SUCCESS)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "Input Check Error");
                return;
            }

            for(int iLoopCount = 0; iLoopCount < IOCnt; iLoopCount++)
            {
                if (InputMultiSignal[iLoopCount] == (short)DIOEnum.ON) btnInputSignal[iLoopCount].BackColor = Color.DarkGreen;
                else if (InputMultiSignal[iLoopCount] == (short)DIOEnum.OFF) btnInputSignal[iLoopCount].BackColor = Color.Maroon;
            }
        }

        private void InputSignalChangeCheck()
        {
            for(short iLoopCount = 0; iLoopCount < IOCnt; iLoopCount++)
            {
                if(InputMultiSignal[iLoopCount] != InputMultiSignalPre[iLoopCount])
                {
                    InputMultiSignalPre[iLoopCount] = InputMultiSignal[iLoopCount];

                    if (iLoopCount != DIOMAP.IN_LIVE)
                        InputChangedEvent(iLoopCount, Convert.ToBoolean(InputMultiSignal[iLoopCount]));
                }
            }
        }

        private void OutputSignalCheck()
        {
            if (false == IsInitialize) return;

            short[] _BitNum = new short[IOCnt];
            byte[] _Data = new byte[IOCnt];
            for (int iLoopCount = 0; iLoopCount < IOCnt; ++iLoopCount) _BitNum[iLoopCount] = (short)iLoopCount;

            if (DigitalIO.OutputEchoBackMultiBitData(_BitNum, IOCnt, _Data) != (int)CDioConst.DIO_ERR_SUCCESS)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "Output Check Error");
                return;
            }

            for (int iLoopCount = 0; iLoopCount < IOCnt; iLoopCount++)
            {
                if (_Data[iLoopCount] == (short)DIOEnum.ON) { btnOutputSignal[iLoopCount].BackColor = Color.DarkGreen; OutputSignalFlag[iLoopCount] = true; }
                else if (_Data[iLoopCount] == (short)DIOEnum.OFF) { btnOutputSignal[iLoopCount].BackColor = Color.Maroon; OutputSignalFlag[iLoopCount] = false; }
            }
        }

        private void VisionAliveSignal()
        {
            VisionAliveSignalCount++;
            if (VisionAliveSignalCount >= ALIVE_SIGNAL_TIME)
            {
                VisionAliveSignalFlag = !VisionAliveSignalFlag;
                SetOutputSignal(DIOMAP.OUT_LIVE, VisionAliveSignalFlag);
                VisionAliveSignalCount = 0;
            }
        }

        private bool InputAliveCheck()
        {
            bool _Result = true;

            if(InputMultiSignal[DIOMAP.IN_LIVE] == (short)DIOEnum.OFF)
            {
                InputAliveCheckCount++;
                if(InputAliveCheckCount > ALIVE_CHECK_TIME)
                {
                    InputChangedEvent(DIOMAP.IN_LIVE, false);

                    CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "DIO Alive Check Count : " + InputAliveCheckCount);

                    InputAliveCheckFlag = false;
                    InputAliveCheckCount = 0;
                    _Result = false;

                    CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "DIO Alive Check OFF");
                }
            }
            else
            {
                if(InputAliveCheckFlag == false)
                {
                    InputChangedEvent(DIOMAP.IN_LIVE, true);

                    InputAliveCheckFlag = true;
                    _Result = true;
                    CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "DIO Alive Check ON");
                }
                InputAliveCheckCount = 0;
            }

            return _Result;
        }

        private void ThreadInputIOCheckFunc()
        {
            try
            {
                while (false == IsThreadInputIOCheckExit)
                {
                    InputSignalCheck();
                    Thread.Sleep(25);
                }
            }
            catch(Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "ThreadInputIOCheckFunc Err");
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "ThreadInputIOCheckFunc Err : " + ex.Message);
            }
        }

        private void ThreadOutputIOCheckFunc()
        {
            try
            {
                while (false == IsThreadOutputIOCheckExit)
                {
                    OutputSignalCheck();
                    Thread.Sleep(25);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ThreadVisionAliveSignalFunc()
        {
            Stopwatch _Stopwatch = new Stopwatch();
            try
            {
                while (false == IsThreadVisionAliveSignalExit)
                {
                    VisionAliveSignal();
                    Thread.Sleep(10);
                }
            }
            catch
            {

            }
        }

        private void ThreadInputAliveCheckFunc()
        {
            try
            {
                while(false == IsThreadInputAliveCheckExit)
                {
                    InputAliveCheck();
                    Thread.Sleep(10);
                }
            }

            catch
            {

            }
        }
    }
}
