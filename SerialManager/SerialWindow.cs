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

enum eSerialProtocol { STX = 0x02, ETX = 0x03 }
namespace SerialManager
{
    public partial class SerialWindow : Form
    {
        private SerialPort SerialComm;

        delegate void SetTextCallback(string data);

        public delegate bool SerialReceiveHandler(string _SerialData, string _SubData = "");
        public event SerialReceiveHandler SerialReceiveEvent;

        public SerialWindow()
        {
            InitializeComponent();

            SerialComm = new SerialPort();
            SerialComm.BaudRate = 19200;
            SerialComm.DataBits = (int)8;
            SerialComm.Parity = Parity.None;
            SerialComm.StopBits = StopBits.One;
            SerialComm.ReadTimeout = (int)500;
            SerialComm.WriteTimeout = (int)500;
        }

        public bool Initialize(string _PortName)
        {
            bool _Result = true;

            SerialComm.PortName = "COM2";

            try
            {
                SerialComm.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);
                SerialComm.Open();
            }
            catch
            {
                _Result = false;
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

                byte[] values = new byte[1];

                try
                {
                    values[0] = byte.Parse(textBoxManualData.Text);
                }
                catch
                {

                }

                SerialComm.Write(values, 0, 1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(SerialComm.IsOpen)
            {
                string data = SerialComm.ReadExisting();
                string ReceiveData = "";

                if(data != string.Empty)
                {
                    char[] values = data.ToCharArray();

                    if (values[0] != Convert.ToChar(eSerialProtocol.STX)) return;
                    else if (values[values.Count() - 1] != Convert.ToChar(eSerialProtocol.ETX)) return;
                    else 

                    foreach (char ValueData in values)
                    {
                        ReceiveData += ValueData;
                    }

                    SerialReceiveEvent(ReceiveData);
                    SetText(ReceiveData);
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
    }
}
