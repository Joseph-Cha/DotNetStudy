using System;
using System.Collections.Generic;
using System.Net;

public class IPAddress01
{
    void Main()
    {
        string Address = Console.ReadLine();
        IPAddress IP = IPAddress.Parse(Address);
        System.Console.WriteLine($"ip : {Address}");
        // IP 정보를 string 타입으로 반환
        System.Console.WriteLine(IP.ToString());
    }
}
