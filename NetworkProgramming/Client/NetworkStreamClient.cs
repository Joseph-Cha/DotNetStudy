using System;
using System.Net.Sockets;
using System.Text;

class Program
{

    void Main()
    {
        TcpClient tcpClient = new TcpClient("localhost", 7);
        NetworkStream ns = tcpClient.GetStream();
        Console.WriteLine("클라이언트");

        byte[] Buffer = new byte[1024];
        byte[] SendMessage = Encoding.ASCII.GetBytes("Hello world");
        ns.Write(SendMessage, 0, SendMessage.Length);
        int TotalCount = 0, ReadCount = 0;


        // 메시지를 한번에 받는 것이 아니라 조금씩 쪼개서 받아옴
        while(TotalCount < SendMessage.Length)
        {
            ReadCount = ns.Read(Buffer, 0, Buffer.Length);
            TotalCount += ReadCount;

            string RecvMessage = Encoding.ASCII.GetString(Buffer);
            System.Console.WriteLine(RecvMessage);
        }

        System.Console.WriteLine("받은 문자열 바이트 수 : {0}", TotalCount);
        ns.Close();
        tcpClient.Close();
    }
    
}