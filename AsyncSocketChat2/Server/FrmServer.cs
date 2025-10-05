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

namespace Server
{
    /// <summary>
    /// Server Class
    /// </summary>
    public partial class FrmServer : Form
    {
        //////////////////////////////////////////////////////////////////////////////////////////
        // Private Attributes
        #region Private Attributes

        /// <summary>
        /// Server Socket
        /// </summary>
        private Socket _SvrSocket;

        /// <summary>
        /// Client Socket List
        /// </summary>
        private List<Socket> _oClientSockets = null;

        /// <summary>
        /// 통신 Buffer
        /// </summary>
        private byte[] _DataBuffer = new byte[1024];

        /// <summary>
        /// Buffer Size
        /// </summary>
        private int _BufSize = 1024;

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
        public FrmServer()
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
        private void FrmServer_Load(object sender, EventArgs e)
        {
            // Client Socket list 생성
            _oClientSockets = new List<Socket>();

            // Server Socket 생성
            _SvrSocket = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream,
                                    ProtocolType.Tcp);

            // Endpoint 생성
            IPEndPoint oIPEndPoint = new IPEndPoint(IPAddress.Any, 9090);

            _SvrSocket.Bind(oIPEndPoint);
            _SvrSocket.Listen(5);

            _SvrSocket.BeginAccept(new AsyncCallback(AcceptConn), _SvrSocket);
            
            // 상태표시
            stsLvlSvrState.Text = "Listening ( Client 연결 대기중 )";
        }

        /// <summary>
        /// Form Closing
        /// </summary>
        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Socket oSocket in _oClientSockets)
            {
                if (oSocket.Connected == true)
                    oSocket.Disconnect(false);
                oSocket.Close();
            }

            _SvrSocket.Close();
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
        /// Close Click
        /// </summary>
        private void btnSvrClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion // UI Events

        //////////////////////////////////////////////////////////////////////////////////////////
        // Private Methods
        #region Private Methods

        /// <summary>
        /// AcceptConn
        /// </summary>
        private void AcceptConn(IAsyncResult iar)
        {
            _SvrSocket = (Socket)iar.AsyncState;
            //Socket SockListener = (Socket)iar.AsyncState;
            Socket oClientSock = _SvrSocket.EndAccept(iar);
            //Socket oClientSock = SockListener.EndAccept(iar);
            string sWelcome = "서버 메세지: Welcome to EG server";

            // 접속 Client 추가
            _oClientSockets.Add(oClientSock);
            
            // 상태표시
            stsLvlSvrState.Text = oClientSock.RemoteEndPoint.ToString() + "의 연결 요청 수락";
            
            byte[] message1 = Encoding.UTF8.GetBytes(sWelcome);
            
            // Send Welcome
            oClientSock.BeginSend(message1, 0, message1.Length, SocketFlags.None,
                                new AsyncCallback(SendData), oClientSock);

            _SvrSocket.BeginAccept(new AsyncCallback(AcceptConn), _SvrSocket);
            //SockListener.BeginAccept(new AsyncCallback(AcceptConn), SockListener);
        }

        /// <summary>
        /// SendData
        /// </summary>
        private void SendData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
            client.BeginReceive(_DataBuffer, 0, _BufSize, SocketFlags.None, 
                            new AsyncCallback(ReceiveData), client);
        }

        /// <summary>
        /// ReceiveData
        /// </summary>
        private void ReceiveData(IAsyncResult iar)
        {
            Socket oClientSock = (Socket)iar.AsyncState;
            int iRcvBytes = 0;

            // Socket 접속 상태 및 수신 바이트 확인
            if (oClientSock.Connected == false)
            {
                oClientSock.Disconnect(false);
                oClientSock.Close();

                _oClientSockets.Remove(oClientSock);

                if (_oClientSockets.Count == 0)
                {
                    stsLvlSvrState.Text = "연결요청 대기중...";
                    _SvrSocket.BeginAccept(new AsyncCallback(AcceptConn), _SvrSocket);
                }
                return;
            }

            iRcvBytes = oClientSock.EndReceive(iar);
                
            if (iRcvBytes > 0)
            {
                string recvData = Encoding.UTF8.GetString(_DataBuffer, 0, iRcvBytes);

                // Dispaly ReceiveData
                this.BeginInvoke(new SetDataCallback(DisplayData_BeginInvoke),
                                                        new object[] { recvData });

                byte[] message2 = Encoding.UTF8.GetBytes(recvData);
                oClientSock.BeginSend(message2, 0, message2.Length, SocketFlags.None,
                                new AsyncCallback(SendData), oClientSock);
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