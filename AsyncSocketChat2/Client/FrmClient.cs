using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    internal enum ClientStates
    {
        Disconnected = 0,

        Connecting,

        Connected,

        Disconnecting,
    }

    /// <summary>
    /// Client Class
    /// </summary>
    public partial class FrmClient : Form
    {
        //////////////////////////////////////////////////////////////////////////////////////////
        // Private Attributes
        #region Private Attributes

        /// <summary>
        /// Client Socket
        /// </summary>
        private Socket _ClientSocket;

        /// <summary>
        /// 통신 Buffer
        /// </summary>
        private byte[] _DataBuffer = new byte[1024];

        /// <summary>
        /// Buffer Size
        /// </summary>
        private int _BufSize = 1024;

        /// <summary>
        /// 연결 상태
        /// </summary>
        private ClientStates _ClientState = ClientStates.Disconnected;

        /// <summary>
        /// SetDataCallBack delegate
        /// </summary>
        private delegate void SetDataCallback(String sRcvData);

        #endregion // Private Attributes

        //////////////////////////////////////////////////////////////////////////////////////////
        // Constructor
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmClient()
        {
            InitializeComponent();
        }

        #endregion // Constructor

        //////////////////////////////////////////////////////////////////////////////////////////
        // Form Events
        #region Form Events

        /// <summary>
        /// Form Load
        /// </summary>
        private void FrmClient_Load(object sender, EventArgs e)
        {
            _ClientState = ClientStates.Disconnected;

            // UI 초기 설정
            SetButtons(_ClientState);
            
        }

        /// <summary>
        /// Form Closing
        /// </summary>
        private void FrmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ClientSocket != null)
            {
            // 연결 닫고 리소스 해제
                _ClientSocket.Close();
            }
        }

        #endregion // Form Events

        //////////////////////////////////////////////////////////////////////////////////////////
        // UI Events
        #region UI Events

        /// <summary>
        /// txtMessage TextChanged
        /// </summary>
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            txtMessage.SelectionStart = txtMessage.Text.Length;
            txtMessage.ScrollToCaret();
        }

        /// <summary>
        /// Connect Click
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // 상태표시
            stsLvlConnectState.Text = "서버 접속중......";

            // 소켓 생성
            Socket oSocket = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream,
                                        ProtocolType.Tcp);

            // Endpoint 생성
            IPEndPoint oIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9090);

            // 원격 호스트에 비동기 연결
            oSocket.BeginConnect(oIPEndPoint, new AsyncCallback(Connected), oSocket);
        }

        /// <summary>
        /// Disconnect Click
        /// </summary>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _ClientSocket.Disconnect(false);
            // 연결 닫고 리소스 해제
            _ClientSocket.Close();

            // 상태표시
            stsLvlConnectState.Text = "접속 종료";
            
            // 버튼설정변경
            _ClientState = ClientStates.Disconnected;
            SetButtons(_ClientState);
            
        }

        /// <summary>
        /// Send Click
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] message = Encoding.UTF8.GetBytes(txtSndMsg.Text);
            txtSndMsg.Clear();
            _ClientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, 
                                    new AsyncCallback(SendData), _ClientSocket);
        }

        #endregion // UI Events

        //////////////////////////////////////////////////////////////////////////////////////////
        // Private Methods
        #region Private Methods

        /// <summary>
        /// Connected
        /// </summary>
        private void Connected(IAsyncResult iar)
        {
            _ClientSocket = (Socket)iar.AsyncState;
            try
            {
                _ClientSocket.EndConnect(iar);

                // 접속상태표시
                stsLvlConnectState.Text = _ClientSocket.RemoteEndPoint.ToString() + " 에 연결 완료";
                
                _ClientSocket.BeginReceive(_DataBuffer, 0, _BufSize, SocketFlags.None, new AsyncCallback(ReceiveData), _ClientSocket);

                // 버튼설정변경
                _ClientState = ClientStates.Connected;
                SetButtons(_ClientState);
                
            }
            catch (SocketException)
            {
                stsLvlConnectState.Text = "연결 실패";
            }
        }

        /// <summary>
        /// Receive Data
        /// </summary>
        private void ReceiveData(IAsyncResult iar)
        {
            string sData = string.Empty;
            Socket remote = (Socket)iar.AsyncState;
            int recv = remote.EndReceive(iar);

            sData = Encoding.UTF8.GetString(_DataBuffer, 0, recv);

            // Dispaly ReceiveData
            this.BeginInvoke(new SetDataCallback(DisplayData_BeginInvoke),
                                                    new object[] { sData });
        }

        /// <summary>
        /// SendData
        /// </summary>
        private void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
            remote.BeginReceive(_DataBuffer, 0, _BufSize, SocketFlags.None, new AsyncCallback(ReceiveData), remote);
        }

        /// <summary>
        /// 버튼 설정
        /// </summary>
        private void SetButtons(ClientStates oClientState)
        {
            switch (oClientState)
            {
                case ClientStates.Disconnected:
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    btnSend.Enabled = false;
                    break;
                case ClientStates.Connected:
                    SetBtnConnect(oClientState);
                    SetBtnDisconnect(oClientState);
                    SetBtnSend(oClientState);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Set Connect Button
        /// </summary>
        private void SetBtnConnect(ClientStates oClientState)
        {

            if (btnConnect.InvokeRequired == true)
            {
                btnConnect.Invoke(new MethodInvoker(
                    delegate
                    {
                        switch (oClientState)
                        {
                            case ClientStates.Connected:
                                btnConnect.Enabled = false;
                                break;
                            case ClientStates.Disconnected:
                                btnConnect.Enabled = true;
                                break;
                            default:
                                break;
                        }
                    }
                ));
            }
            else
            {
                switch (oClientState)
                {
                    case ClientStates.Connected:
                        btnConnect.Enabled = false;
                        break;
                    case ClientStates.Disconnected:
                        btnConnect.Enabled = true;
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Set Disconnect Button
        /// </summary>
        private void SetBtnDisconnect(ClientStates oClientState)
        {

            if (btnDisconnect.InvokeRequired == true)
            {
                btnDisconnect.Invoke(new MethodInvoker(
                    delegate
                    {
                        switch (oClientState)
                        {
                            case ClientStates.Connected:
                                btnDisconnect.Enabled = true;
                                break;
                            case ClientStates.Disconnected:
                                btnDisconnect.Enabled = false;
                                break;
                            default:
                                break;
                        }
                    }
                ));
            }
            else
            {
                switch (oClientState)
                {
                    case ClientStates.Connected:
                        btnDisconnect.Enabled = true;
                        break;
                    case ClientStates.Disconnected:
                        btnDisconnect.Enabled = false;
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Set Send Button
        /// </summary>
        private void SetBtnSend(ClientStates oClientState)
        {
            if (btnSend.InvokeRequired == true)
            {
                btnSend.Invoke(new MethodInvoker(
                    delegate
                    {
                        switch (oClientState)
                        {
                            case ClientStates.Connected:
                                btnSend.Enabled = true;
                                break;
                            case ClientStates.Disconnected:
                                btnSend.Enabled = false;
                                break;
                            default:
                                break;
                        }
                    }
                ));
            }
            else
            {
                switch (oClientState)
                {
                    case ClientStates.Connected:
                        btnSend.Enabled = true;
                        break;
                    case ClientStates.Disconnected:
                        btnSend.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Display Data
        /// </summary>
        private void DisplayData_BeginInvoke(String sData)
        {
            txtMessage.Text += sData + Environment.NewLine;
        }

        #endregion // Private Methods

    }
}