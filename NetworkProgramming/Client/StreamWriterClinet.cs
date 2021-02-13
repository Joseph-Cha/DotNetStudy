using System.Net.Sockets;
using System.Text;
using System.IO;

class StreamWriterClient
{
    void Main()
    {
        char[] buffer = new char[100];
        TcpClient tcpClient = new TcpClient("localhost", 3000);
        NetworkStream ns = tcpClient.GetStream();
        using (StreamReader sr = new StreamReader(ns))
        {
            string str = sr.ReadLine();
            System.Console.WriteLine(str);
            str = sr.ReadLine();
            System.Console.WriteLine(str);
            str = sr.ReadLine();
            System.Console.WriteLine(str);
            str = sr.ReadLine();
            System.Console.WriteLine(str);
        }

        ns.Close();
        tcpClient.Close();
    }
}