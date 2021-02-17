using System;
using System.Collections.Generic;
using System.Linq;

public class MbtiInfo
{
    public string Alphabet;
    public string CodeNumber;
    public string Name;
    public string Content;
    public MbtiInfo(string alphabet, string codenumber, string name, string content)
    {
        Alphabet = alphabet;
        CodeNumber = codenumber;
        Name = name;
        Content = content;
    }
}

class ClassList
{    
    void Main()
    {
        List<MbtiInfo> m_Mbti = new List<MbtiInfo>();

        m_Mbti.Add(new MbtiInfo("A", "00", "망고", "내용1"));
        m_Mbti.Add(new MbtiInfo("B", "01", "사과", "내용2"));
        m_Mbti.Add(new MbtiInfo("C", "02", "수박", "내용3"));
        m_Mbti.Add(new MbtiInfo("D", "03", "멜론", "내용4"));
        
        // Alphabet에서 A가 들어가 있는 Name 데이터를 추출
        foreach (var MbtiInfo in m_Mbti)
        {
            if(MbtiInfo.Alphabet.Contains("A"))
            {
                System.Console.WriteLine(MbtiInfo.Name);
            }
        }

        // 위에 문장을 한줄로 줄이고 싶은데 어떻게 해야할까요?
        m_Mbti.ForEach(x => x.Alphabet.Contains("A"));
    }
}