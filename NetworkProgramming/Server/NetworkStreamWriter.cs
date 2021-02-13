using System.Net;
using System;
using System.Text;
using System.Net.Sockets;
using System.IO;

class NetworkStreamWriter
{
    void Main()
    {
        TcpListener tcpListener = new TcpListener(3000);
        tcpListener.Start();
        TcpClient tcpClient = tcpListener.AcceptTcpClient();

        bool YesNo = false;
        int Val1 = 12;
        float Pi = 3.14f;
        string Message = "Hello World!";

        NetworkStream ns = tcpClient.GetStream();
        using(StreamWriter sw = new StreamWriter(ns))
        {
            sw.AutoFlush = true;
            sw.WriteLine(YesNo);
            sw.WriteLine(Val1);
            sw.WriteLine(Pi);
            sw.WriteLine(Message);
        }
        // sw 객체의 아래 함수들을 실행하고 나서 곧바로 sw 객체를 소멸키는 역할

        ns.Close();
        tcpClient.Close();
        tcpListener.Stop();

    }
}