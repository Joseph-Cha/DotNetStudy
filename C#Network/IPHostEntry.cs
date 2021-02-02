using System;
using System.Net;

class IPHostEntryClass
{
    void Main()
    {
        IPHostEntry HostInfo = Dns.GetHostEntry("www.naver.com");

        foreach (var ip in HostInfo.AddressList)
        {
            System.Console.WriteLine($"{ip}");
        }
        System.Console.WriteLine($"{HostInfo.HostName}");
    }
}