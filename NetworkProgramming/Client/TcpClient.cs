using System;
using System.Net.Sockets;
using System.Text;

class TcpClient01
{
    void Main()
    {
        TcpClient tcpClient = new TcpClient("192.168.219.103", 13);
        if(tcpClient.Connected)
        {
            System.Console.WriteLine("서버 연결 성공");
            NetworkStream ns = tcpClient.GetStream();
            string Message = "Hello World!";
            byte[] SendByteMessage = Encoding.ASCII.GetBytes(Message);
            ns.Write(SendByteMessage, 0, SendByteMessage.Length); // 서버로 메시지 발송

            byte[] receiveByteMessage = new byte[32];
            ns.Read(receiveByteMessage, 0, 32);
            string receiveMessage = Encoding.ASCII.GetString(receiveByteMessage);
            System.Console.WriteLine(receiveMessage);
        }
        else
            System.Console.WriteLine("서버 연결 실패");
        tcpClient.Close();
        Console.ReadKey();
    }
}