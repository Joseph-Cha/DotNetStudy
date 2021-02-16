using System;
using System.Collections.Generic;
using System.Collections;


namespace C_
{
    public class Movie
    {
        string[] _movieName;

        public Movie(int length)
        {
            _movieName = new string[length]; 
        } 

        public string this[int index]
        {
            get {return _movieName[index];  }
            set {_movieName[index] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _movieName.Length; i++)
            {
                yield return _movieName[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Movie> AType = new Dictionary<string, Movie>();
            Dictionary<string, Movie> BType = new Dictionary<string, Movie>();   
            Dictionary<string, Movie> CType = new Dictionary<string, Movie>();   
            Dictionary<string, Movie> DType = new Dictionary<string, Movie>();   

            AType.Add("1", new Movie(5));
            AType.Add("2", new Movie(3));
            AType.Add("3", new Movie(4));

            BType.Add("1", new Movie(5));
            BType.Add("2", new Movie(2));
            BType.Add("3", new Movie(4));

            CType.Add("1", new Movie(10));
            CType.Add("2", new Movie(4));
            CType.Add("3", new Movie(8));

            AType["1"][0] = "A-1-0";
            AType["1"][1] = "A-1-1";
            AType["1"][2] = "A-1-2";
            AType["1"][3] = "A-1-3";
            AType["1"][4] = "A-1-4";

            AType["2"][0] = "A-2-0";
            AType["2"][1] = "A-2-1";
            AType["2"][2] = "A-2-3";

            AType["3"][0] = "A-3-0";
            AType["3"][1] = "A-3-1";
            AType["3"][2] = "A-3-2";
            AType["3"][3] = "A-3-3";
            

            foreach (var key in AType.Keys)
            {             
                foreach (var value in AType[key])
                {
                    System.Console.WriteLine(value);                    
                }
            }
        }
    }
}
