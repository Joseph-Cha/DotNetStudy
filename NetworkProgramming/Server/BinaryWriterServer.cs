using System.IO;
using System.Net;
using System.Net.Sockets;

class BinaryWriterServer
{
    static void Main()
    {
        TcpListener tcpListener = new TcpListener(IPAddress.Any, 3000);
        tcpListener.Start();

        TcpClient tcpClient = tcpListener.AcceptTcpClient();
        NetworkStream ns = tcpClient.GetStream();
        using (BinaryWriter bw = new BinaryWriter(ns))
        {
            bool YesNo = true;
            int Number = 12;
            float Pi = 3.14f;
            string Message = "Hello World";

            bw.Write(YesNo);
            bw.Write(Number);
            bw.Write(Pi);
            bw.Write(Message);
        }
        ns.Close();
        tcpClient.Close();
        tcpListener.Stop();
    }
}