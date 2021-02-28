using System.Net;
using System;
using System.Text;
using System.Net.Sockets;

// 대기 상태
class TcpListenerServer
{
    void Main()
    {       

        IPAddress ip = IPAddress.Parse("192.168.219.103");
        TcpListener tcpListener = new TcpListener(ip, 13); // ip와 포트번호
        Console.WriteLine($"{tcpListener.LocalEndpoint.ToString()}");
        tcpListener.Start();
        Console.WriteLine("대기 상태 시작");
        // AcceptTcpClient는 클라이어튼가 접속이 되었을 때 TcpClient 객체를 생성한다.
        TcpClient tcpClient = tcpListener.AcceptTcpClient(); // TcpClinet 개체가 생성 => 연결 수락
        Console.WriteLine("대기 상태 종료");
        NetworkStream ns = tcpClient.GetStream();
        byte[] receiveMessage = new byte[100];
        ns.Read(receiveMessage, 0, 100);
        string strMessage = Encoding.ASCII.GetString(receiveMessage);
        Console.WriteLine(strMessage);

        string EchoMessage = "Hi~~~";
        byte[] SendMessage = Encoding.ASCII.GetBytes(EchoMessage);
        ns.Write(SendMessage, 0, SendMessage.Length); // 클라이언트에 메시지 발송
        ns.Close();
        tcpClient.Close();
        tcpListener.Stop();
        Console.ReadKey();
    }
}
