using System.Net;
using System;
using System.Text;
using System.Net.Sockets;


// 대기 상태
class TcpListenerServer
{
    static void Main()
    {
        IPAddress ip = IPAddress.Parse("192.168.219.103");
        TcpListener tcpListener = new TcpListener(ip, 13); // ip와 포트번호
        System.Console.WriteLine($"{tcpListener.LocalEndpoint.ToString()}");

        tcpListener.Start();
        System.Console.WriteLine("대기 상태 시작");
        TcpClient tcpClient = tcpListener.AcceptTcpClient(); // TcpClinet 개체가 생성 => 연결 수락
        System.Console.WriteLine("대기 상태 종료");
        NetworkStream ns = tcpClient.GetStream();
        byte[] receiveMessage = new byte[100];
        ns.Read(receiveMessage, 0, 100);
        string strMessage = Encoding.ASCII.GetString(receiveMessage);
        System.Console.WriteLine(strMessage);

        string EchoMessage = "Hi~~~";
        byte[] SendMessage = Encoding.ASCII.GetBytes(EchoMessage);
        ns.Write(SendMessage, 0, SendMessage.Length); // 클라이언트에 메시지 발송
        ns.Close();
        tcpClient.Close();
        tcpListener.Stop();
        Console.ReadKey();
    }
}
