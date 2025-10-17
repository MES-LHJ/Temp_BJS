using Chat_Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Server
{
    public partial class Server : Form
    {
        private TcpListener Chat_Server;
        private TcpClient Chat_Client;

        StreamReader Reader;
        StreamWriter Writer;
        NetworkStream stream;

        //Thread ReceiveThread;

        bool Connected;
        //private ServerAddress serverAddr = new ServerAddress();
        private CancellationTokenSource cts;

        private delegate void AddTextDelegate(string strText);
        public Server()
        {
            InitializeComponent();
            AddEvent();
        }

        private void AddEvent()
        {
            this.Load += Server_Load;
            this.sendButton.Click += sendButton_Click;
            this.serverStartBtn.Click += ServerStartBtn_Click;
            this.resetBtn.Click += ServerResetBtn_Click;
            this.FormClosing += Server_FormClosing;
        }

        private void AppendChat(string message)
        {
            if (txt_server_chat.InvokeRequired)
            {
                var d = new AddTextDelegate(AppendChat);
                txt_server_chat.Invoke(new Action(() => AppendChat(message)));
            }
            else
            {
                txt_server_chat.AppendText(message);
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            //Thread ListenThread = new Thread(new ThreadStart(Listen));
            //ListenThread.Start();

            //ipAddress.DataBindings.Add("Text", serverAddr, "IP");
            //portAddress.DataBindings.Add("Text", serverAddr, "Port");
            resetBtn.Enabled = false;

            //cts = new CancellationTokenSource();
            //Receive(cts.Token);
            //await StartServer();
        }

        private async void ServerStartBtn_Click(object sender, EventArgs e)
        {
            serverStartBtn.Enabled = false;
            ipAddress.Enabled = false;
            portAddress.Enabled = false;
            resetBtn.Enabled = true;
            await StartServer();
        }

        private async void ServerResetBtn_Click(object sender, EventArgs e)
        {
            ipAddress.Text = string.Empty;          //ipAddress 초기화
            portAddress.Text = string.Empty;        //portAddress 초기화
            txt_server_chat.Text = string.Empty;    //chatting 창 초기화
            txt_server_send.Text = string.Empty;    //send text box 초기화
            resetBtn.Enabled = false;               //resetBtn 비활성화
            ipAddress.Enabled = true;               //ipAddress 활성화
            portAddress.Enabled = true;             //portAddress 활성화
            await Task.Delay(1500);                  //버튼 활성화 대기
            serverStartBtn.Enabled = true;          //serverStartBtn 활성화

            try
            {
                Connected = false;
                cts?.Cancel();

                await Task.Delay(1000); // 취소 토큰이 처리될 시간

                Writer?.Dispose();
                Reader?.Dispose();
                stream?.Dispose();
                Chat_Client?.Close();
                Chat_Server?.Stop();
                Chat_Server = null;
                if (Chat_Server != null)
                {
                    AppendChat("이미 실행 중인 서버\r\n");
                }
            }
            catch (Exception ex)
            {
                AppendChat(Text + "오류: " + ex.Message + "\r\n");
            }
            await Task.Delay(300);
            AppendChat("서버 초기화\r\n");
        }

        private async Task StartServer()
        {
            // chatting 창에 text 추가 delegate 함수 선언
            //AddTextDelegate AddText = new AddTextDelegate(txt_server_chat.AppendText);

            // server setting
            //IPAddress addr = IPAddress.Parse("127.0.0.1"); //루프백 주소
            //int port = 8000; //포트 번호
            //Chat_Server = new TcpListener(addr, port);
            try
            {
                //if (!IPAddress.TryParse(ipAddress.Text, out var addr))
                //{
                //    AppendChat("유효한 IP 주소를 입력하세요.\r\n");
                //}

                if (!int.TryParse(portAddress.Text, out int port))
                {
                    AppendChat("유효한 PORT번호를 입력하세요.\r\n");
                    return;
                }

                //var addr = IPAddress.Parse(ipAddress.Text); // IP 주소 파싱

                // 기본값 설정
                var ipText = string.IsNullOrWhiteSpace(ipAddress.Text) ? "127.0.0.1" : ipAddress.Text; 
                if (!IPAddress.TryParse(ipText, out var addr)) return;

                Chat_Server = new TcpListener(addr, port); //TcpListener 객체 생성
                Chat_Server.Start(); //서버 시작

                // Ip and Port 매핑
                ipAddress.Text = addr.ToString();
                portAddress.Text = port.ToString();

                AppendChat("서버 시작\r\n클라이언트 접속 대기 중...\r\n"); // 서버 시작 메시지 출력

                // client setting
                Chat_Client = await Chat_Server.AcceptTcpClientAsync(); //클라이언트 접속 대기
                Connected = true;

                AppendChat("클라이언트 접속\r\n"); // 클라이언트 접속 메시지 출력

                // stream setting
                stream = Chat_Client.GetStream(); // 네트워크 스트림 얻기
                Reader = new StreamReader(stream); // 스트림 리더 생성
                Writer = new StreamWriter(stream); // 스트림 라이터 생성

                cts = new CancellationTokenSource();
                Receive(cts.Token);
            }
            catch (Exception ex)
            {
                AppendChat($"서버 시작 오류: {ex.Message}");
                Connected = false;
            }

            // receive thread start
            //ReceiveThread = new Thread(new ThreadStart(Receive));
            //ReceiveThread.Start();

        }

        private async void Receive(CancellationToken token)
        {
            AddTextDelegate AddText = new AddTextDelegate(txt_server_chat.AppendText);
            try
            {
                while (!token.IsCancellationRequested && Connected)
                {
                    string message = await Reader.ReadLineAsync();
                    if (string.IsNullOrEmpty(message))
                    {
                        AppendChat("클라이언트가 종료했습니다.\r\n");
                        Connected = false;
                        break; //클라이언트가 연결을 끊으면 루프 종료
                    }
                    AppendChat("Client: " + message + Environment.NewLine);
                }
            }
            catch (IOException)
            {
                AppendChat("클라이언트와의 연결이 끊어졌습니다.\r\n");
                Connected = false;
            }
            catch (Exception ex)
            {
                AppendChat($"{ex.Message}\r\n");
            }
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            // client가 연결되어 있지 않거나, client의 stream이 null이면 메시지 전송 불가
            if (!Connected || Writer == null)
            {
                AppendChat("연결된 클라이언트가 없습니다."+"\r\n");
                return;
            }

            string message = txt_server_send.Text;

            if (string.IsNullOrEmpty(message))
            {
                AppendChat("전송할 메시지를 입력하세요."+"\r\n");
                return;
            }

            try
            {

                // client로 메시지 전송
                await Writer.WriteLineAsync(message); // 비동기 메시지 전송
                await Writer.FlushAsync();            // 비동기 버퍼 플러시
                // chatting 창에 sendermessage 추가
                AppendChat("Server: " + message + "\r\n");

                // send text box 초기화
                txt_server_send.Text = string.Empty;

                //await Task.Delay(1000);
                //if (Chat_Client.Connected == false)
                //{
                //    txt_server_chat.AppendText("연결된 클라이언트가 없습니다." + "\r\n");
                //}


            }
            catch (Exception ex)
            {
                AppendChat("전송 오류: " + ex.Message + "\r\n");
                Connected = false;
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connected = false;
            cts?.Cancel();

            try
            {
                Reader?.Close();
                Writer?.Close();
                Chat_Client?.Close();
                Chat_Server?.Stop();
            }
            catch (Exception ex)
            {
                AppendChat(Text + "오류: " + ex.Message + "\r\n");
            }

            AppendChat("서버 종료\r\n");
            //if (ReceiveThread != null && ReceiveThread.IsAlive)
            //    ReceiveThread.Join(1000);
        }
    }
}
