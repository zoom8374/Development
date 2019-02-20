using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

using LogMessageManager;

enum eSerialProtocol { STX = '@', ETX = '\r' }
namespace SerialManager
{
    public partial class SerialWindow : Form
    {
        private SerialPort SerialComm;
        public bool IsShowWindow;

        delegate void SetTextCallback(string data);

        public delegate bool SerialReceiveHandler(string _SerialData);
        public event SerialReceiveHandler SerialReceiveEvent;

        public SerialWindow()
        {
            InitializeComponent();

            SerialComm = new SerialPort();
            SerialComm.BaudRate = 115200;
            SerialComm.DataBits = (int)7;
            SerialComm.Parity = Parity.Even;
            SerialComm.StopBits = StopBits.Two;
            SerialComm.ReadTimeout = (int)500;
            SerialComm.WriteTimeout = (int)500;
        }

        public bool Initialize(string _PortName)
        {
            bool _Result = true;

            SerialComm.PortName = "COM5";

            try
            {
                SerialComm.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);
                SerialComm.Open();
            }
            catch(Exception ex)
            {                
                _Result = false;
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "SerialWindow Initialize Exception!!", CLogManager.LOG_LEVEL.LOW);
            }

            return _Result;
        }

        public void DeInitialize()
        {
            SerialComm.DataReceived -= new SerialDataReceivedEventHandler(SerialDataReceived);
            SerialComm.Close();
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(SerialComm.IsOpen)
            {
                if(textBoxManualData.Text.Length == 0)
                {
                    MessageBox.Show("데이터를 입력 하십시오.");
                    return;
                }

                byte[] values = Encoding.ASCII.GetBytes(textBoxManualData.Text);

                try
                {
                    
                }
                catch
                {
                    CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "SerialWindow btnSend Exception!!", CLogManager.LOG_LEVEL.LOW);
                }

                SerialComm.Write(values, 0, values.Count());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsShowWindow = false;
            this.Hide();
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (SerialComm.IsOpen)
            {
                Thread.Sleep(50);

                string data = SerialComm.ReadExisting();

                if (data != string.Empty)
                {
                    string[] values = data.Split(',');

                    if (!values[0].Contains(Convert.ToChar(eSerialProtocol.STX))) return;
                    else if (!values[values.Count() - 1].Contains(Convert.ToChar(eSerialProtocol.ETX))) return;

                    SerialReceiveEvent(data);
                    SetText(data);
                }
            }
        }

        private void SetText(string _Data)
        {
            if(this.textBoxRecvString.InvokeRequired)
            {
                SetTextCallback DataSet = new SetTextCallback(SetText);
                this.Invoke(DataSet, new object[] { _Data });
            }
            else
            {
                this.textBoxRecvString.Clear();
                this.textBoxRecvString.Text += (_Data + " ");
            }
        }

        public void SendSequenceData(string _SendData)
        {
            byte[] SendData;

            try
            {
                SendData = Encoding.ASCII.GetBytes(_SendData);
                SerialComm.Write(SendData, 0, SendData.Count());
            }
            catch
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "SerialWindow SendWequenceData Exception!!", CLogManager.LOG_LEVEL.LOW);
            }
        }

        public void ShowSerialWindow()
        {
            IsShowWindow = true;
            this.Show();
        }
    }
}
