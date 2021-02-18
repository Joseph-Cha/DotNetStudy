using System;
using System.Collections.Generic;

namespace CollectionInitailizer
{    
    class Person
    {
        public string Name {get; set;}
    }

    class Program
    {
        // 제네릭 개체를 초기화 하는 세 가지 방법 정리
        void Main()
        {
            // 1. 컬렉션 이니셜라이저를 사용해서 걸렉션 개체를 선언함과 동시에 특정 개체 값을초 초기화
            List<Person> GroupA = new List<Person>
            {
                // 개체 이니셜라이저로 생성할 때 바로 초기화
                // 생성자의 역할과 비슷한 듯
                new Person() {Name = "차동훈"},
                new Person {Name = "임미진"}
            };

            // 2. Add() 메서드로 리스트에 값 추가 : 개체 이니셜 라이저로 초기화
            List<Person> GroupB = new List<Person>();
            GroupB.Add(new Person() {Name = "차동훈"});
            GroupB.Add(new Person() {Name = "임미진"});            


            // 3. AddRange() 메서드로 리스트에 한 번에 값 추가
            List<Person> GroupC = new List<Person>();
            var tempGroup = new List<Person>()
            {
                new Person() {Name = "차동훈"},
                new Person {Name = "임미진"} 
            };
            GroupC.AddRange(tempGroup);
        }
    }
}