using System.Net.Sockets;
using System.IO;

class BinaryReaderClient
{
    static void Main()
    {
        bool YesNo;
        int Number;
        float Pi;
        string Messsage;

        TcpClient tcpClient = new TcpClient("localhost", 3000);
        NetworkStream ns = tcpClient.GetStream();
        using(BinaryReader br = new BinaryReader(ns))
        {
            YesNo = br.ReadBoolean();
            Number = br.ReadInt32();
            Pi = br.ReadSingle();
            Messsage = br.ReadString();
        }

        ns.Close();
        tcpClient.Close();
        System.Console.WriteLine(YesNo);
        System.Console.WriteLine(Number);
        System.Console.WriteLine(Pi);
        System.Console.WriteLine(Messsage);
    }
}