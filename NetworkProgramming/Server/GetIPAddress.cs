using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

class WinFormPractice
{
    TcpListener tcpListener = new TcpListener(3000);
    TcpClient tcpClient = new TcpClient();
    BinaryReader br;
    BinaryWriter bw;
    NetworkStream  ns;

    float floatValue = 0;
    int intValue = 0;
    string strValue = null;

    // 해당 폼이 시작 됐을 때 호출되는 메서드
    // 폼이 시작되면 호스트의 IP 주소를 가지고 옴
    private void Form1_Load()
    {
        // 서버 역할을 하는 TCPListener를 시작
        tcpListener.Start();

        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        for (int i = 0; i < host.AddressList.Length; i++)
        {
            if(host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
            {
                string ip = host.AddressList[i].ToString();
                break;
            }
        }
    }

    // 접속 시작 버튼 클릭
    // 접속을 시도한 Client의 IP주소를 가지고 옴
    private void button1_Click(object sender, EventArgs e)
    {
        tcpClient = tcpListener.AcceptTcpClient();
        if(tcpClient.Connected)
        {
            string clientIP = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
        }
        ns = tcpClient.GetStream();
        bw = new BinaryWriter(ns);
        br = new BinaryReader(ns); 
    }

    // 데이터를 주고 받기 시작
    // tcpClient가 끊어졌을 때 또는 닫기 버튼을 클릭했을 때 
    // 종료
    private void button2_Click(object sender, EventArgs e)
    {
        while(true)
        {
            if(tcpClient.Connected)
            {
                if (DateReceive() == -1)
                    break;
                DateSend();
            }
            else
            {
                AllClose();
                break;
            }
        }
        AllClose();
    }

    private int DateReceive()
    {
        int intValue = br.ReadInt32();
        if(intValue == -1)
            return 1;
        floatValue = br.ReadSingle();
        strValue = br.ReadString();
        string str = intValue + "/" + floatValue + "/" + strValue;
        System.Console.WriteLine(str);
        return 0;        
    }

    private void DateSend()
    {
        bw.Write(intValue);
        bw.Write(floatValue);
        bw.Write(strValue);
        System.Console.WriteLine("보냈습니다.");
    }

    private void AllClose()
    {
        if (bw != null)
        {
            bw.Close();
            bw = null;
        }
        if(br != null)
        {
            br.Close();
            br = null;
        }
        if(ns != null)
        {
            ns.Close();
            ns = null;
        }
        if(tcpClient != null)
        {
            tcpClient.Close();
            tcpClient = null;
        }

    }
}
