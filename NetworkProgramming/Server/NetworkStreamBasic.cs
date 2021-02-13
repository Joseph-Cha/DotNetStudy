using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

class NetworkStreamServer
{
    void Main()
    {
        TcpListener tcpListener = new TcpListener(IPAddress.Any, 7);
        tcpListener.Start();
        byte[] Buffer = new byte[1024];
        int TotalByteCount = 0, ReadyByteCount = 0;

        Console.WriteLine("서버");
        TcpClient tcpClient = tcpListener.AcceptTcpClient();
        NetworkStream ns = tcpClient.GetStream();
        
        while(true)
        {
            ReadyByteCount = ns.Read(Buffer, 0, Buffer.Length);
            if(ReadyByteCount == 0)
                break;
            
            TotalByteCount += ReadyByteCount;
            ns.Write(Buffer, 0, ReadyByteCount);
            Console.Write(Encoding.ASCII.GetString(Buffer));
        }

        Console.ReadKey();

    }
}