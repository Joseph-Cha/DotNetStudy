using System;
using System.Net;

class DNSClass
{
    void Main()
    {
        
        IPAddress[] IP = Dns.GetHostAddresses("www.naver.com");
        foreach(IPAddress HostIP in IP)
        {
            System.Console.WriteLine($"{HostIP}");
        }
    }
}