using Chat_Client.Model;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Utils.DPI;
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

namespace Chat_Client
{
    public partial class Client : Form
    {
        private readonly UserModel _user;

        TcpClient Chat_Client;

        StreamReader Reader;
        StreamWriter Writer;
        NetworkStream stream;

        bool Connected;

        private delegate void AddTextDelegate(string strText);

        private CancellationTokenSource cts;

        public Client()
        {
            InitializeComponent();
            AddEvent();
        }

        public Client(UserModel user) : this()
        {
            _user = user;
        }

        private void AddEvent()
        {
            this.Load += Client_Load;
            this.sendButton.Click += SendButton_Click;
            this.FormClosing += Chat_Client_FormClosing;
            this.connectBtn.Click += ConnectBtn_Click;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            if(_user != null)
            {
                AppendChat($"환영합니다, {_user.NickName}님!\r\n");
            }
            else
            {
                AppendChat("로그인 정보 없음.\r\n");
            }
            //AppendChat("클라이언트 준비 완료.\r\n");
        }

        private void AppendChat(string message)
        {
            if (txt_client_chat.InvokeRequired)
            {
                //var d = new AddTextDelegate(AppendChat); // 델리게이트 생성
                txt_client_chat.Invoke(new Action(() => AppendChat(message))); // UI 스레드에서 실행
            }
            else
            {
                txt_client_chat.AppendText(message);
            }
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                //txt_client_chat.AppendText("서버와 연결 시도중...\r\n");
                //bool success = await ConnectAsync(ipAddress.Text, int.Parse(portAddress.Text));
                sendButton.Enabled = false;
                AppendChat("서버와 연결이 끊겼습니다. 연결 시도중...\r\n");
                await Task.Delay(3000);
                sendButton.Enabled = true;
                await ConnectAsync();
                if (Connected)
                {
                    ipAddress.Enabled = false;
                    portAddress.Enabled = false;
                    connectBtn.Enabled = false;
                }
                return;

                //if (!success)
                //{
                //    txt_client_chat.AppendText("서버 재연결 실패\r\n");
                //    return;
                //}
                //else
                //{
                //    txt_client_chat.AppendText("서버 연결 성공\r\n");
                //}
            }

            string message = txt_client_send.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                AppendChat("전송할 메시지를 입력하세요.\r\n");
                return;
            }

            try
            {
                await Writer.WriteLineAsync(txt_client_send.Text);
                await Writer.FlushAsync();
                AppendChat($"Client: {message}\r\n"); // 보내는 메시지 채팅창에 표시
                txt_client_send.Text = string.Empty; // send text box 초기화
            }
            catch (Exception ex)
            {
                AppendChat($"메시지 전송 실패: {ex.Message}\r\n");
                Connected = false;
            }
        }

        private async void ConnectBtn_Click(object sender, EventArgs e)
        {
            connectBtn.Enabled = false;
            try
            {
                await ConnectAsync();

                //if (!string.IsNullOrEmpty(ipAddress.Text) && int.TryParse(portAddress.Text, out int port))
                if (Connected)
                {
                    ipAddress.Enabled = false;
                    portAddress.Enabled = false;
                    connectBtn.Enabled = false;
                    //connectBtn.Enabled = true;
                }
                
                else
                {
                    ipAddress.Enabled = true;
                    portAddress.Enabled = true;
                    await Task.Delay(3000); // 3초 대기
                    connectBtn.Enabled = true;
                    //await ConnectAsync();
                    //await Task.Delay(3000); // 3초 대기
                    //connectBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                AppendChat($"다시 접속 시도해주세요.오류: {ex.Message}\r\n");
                ipAddress.Enabled = true;
                portAddress.Enabled = true;
                connectBtn.Enabled = true;
            }

        }

        private async Task ConnectAsync()
        {
            //string ip = ipAddress.Text;
            //if (string.IsNullOrEmpty(ip))
            //{
            //    AppendChat("IP 주소를 입력하세요.\r\n");
            //    return;
            //}
            var ip = string.IsNullOrWhiteSpace(ipAddress.Text) ? "127.0.0.1" : ipAddress.Text;
            if (!IPAddress.TryParse(ip, out var addr))
            {
                ipAddress.Enabled = true;
                return;
            }

            if (!int.TryParse(portAddress.Text, out int port))
            {
                AppendChat("유효한 PORT번호를 입력하세요.\r\n");
                portAddress.Enabled = true;
                return;
            }

            ipAddress.Text = addr.ToString();

            try
            {
                Reader?.Dispose();
                Writer?.Dispose();
                stream?.Dispose();
                Chat_Client?.Close();

                Chat_Client = new TcpClient();
                await Chat_Client.ConnectAsync(ip, port);

                stream = Chat_Client.GetStream();
                Reader = new StreamReader(stream, Encoding.UTF8); // 스트림 리더 생성
                Writer = new StreamWriter(stream, Encoding.UTF8); // 스트림 라이터 생성

                Connected = true;
                cts = new CancellationTokenSource();
                Receive(cts.Token);

                AppendChat("서버 연결 성공\r\n");

                // 비동기 방식에선 없어도 됨
                //ReceiveThread = new Thread(new ThreadStart(Receive)); // receive thread 생성
                //ReceiveThread.Start(); // receive thread start
            }
            catch (Exception ex)
            {
                AppendChat($"서버 연결 실패: {ex.Message}\r\n");
                Connected = false;
            }
        }

        private async void Chat_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connected = false;
            cts?.Cancel();

            try
            {
                // 서버가 이미 닫혔을 수도 있기 때문에 Write 시도 전에 체크
                if (Chat_Client?.Connected == true && Writer != null)
                {
                    try
                    {
                        if (Connected && Writer != null)
                        {
                            await Writer.WriteLineAsync("CLIENT_EXIT");
                            await Writer.FlushAsync();
                            Chat_Client.Close();
                        }
                    }
                    catch (IOException) { } //서버닫혔으면 종료 진행
                    catch (ObjectDisposedException) { } //닫힌 스트림 무시
                }
                Writer?.Dispose();
                Reader?.Dispose();
                stream?.Dispose();
                Chat_Client?.Close();
            }

            catch (Exception ex)
            {
                AppendChat($"클라이언트 종료 중 오류: {ex.Message}\r\n");
            }

            AppendChat("클라이언트 종료\r\n");
            //if (Reader != null) Reader.Close();
            //if (Writer != null) Writer.Close();
            //if (Chat_Client != null) Chat_Client.Close();
        }
        private async void Receive(CancellationToken token)
        {
            //AddTextDelegate AddText = new AddTextDelegate(txt_client_chat.AppendText);

            try
            {
                while (!token.IsCancellationRequested && Connected)
                {
                    string ReceiveData = await Reader.ReadLineAsync();
                    //if (ReceiveData == null) break;
                    Console.WriteLine("여기왔다가??");

                    if (ReceiveData == "SERVER_RESET" || ReceiveData == null)
                    {
                        AppendChat("서버가 종료되었습니다.\r\n");
                        Connected = false;
                        Writer?.Dispose();
                        Reader?.Dispose();
                        stream?.Dispose();
                        Chat_Client?.Close();

                        ipAddress.Enabled = true;
                        portAddress.Enabled = true;
                        connectBtn.Enabled = true;
                        break;
                    }
                    AppendChat("Server: " + ReceiveData + "\r\n");
                }
            }
            catch (IOException)
            {
                AppendChat("서버 연결 끊김\r\n");
                Connected = false;
            }
            catch (ObjectDisposedException)
            {
                Connected = false;
            }
        }
    }
}
