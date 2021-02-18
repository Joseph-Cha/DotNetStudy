using System;
using System.Collections;
using System.Collections.Generic;

// Simple business object.
public class Person
{
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }

    public string firstName;
    public string lastName;
}

// Collection of Person objects. This class
// implements IEnumerable so that it can be used
// with ForEach syntax.
public class People : IEnumerable
{
    List<int> a = new List<int>();
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];

        for (int i = 0; i < pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }

    // Implementation for the GetEnumerator method.
    // IEnumerable 인터페이스를 구현하기 위해 IEnumerator IEnumerable.GetEnumerator() 메소드 구현
    IEnumerator IEnumerable.GetEnumerator()
    {
        // 실제로 리턴되는 값은 아래 GetEnumerator 메소드의 리턴 값
        return GetEnumerator();
    }


    public PeopleEnum GetEnumerator()
    {
        // person 데이터가 저장된 People 데이터로 PeopleEnum 개체 생성
        return new PeopleEnum(_people);
    }
}

// When you implement IEnumerable, you must also implement IEnumerator.
public class PeopleEnum : IEnumerator
{
    public Person[] _people;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public PeopleEnum(Person[] list)
    {
        _people = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

class App
{
    static void Main()
    {
        // 단 몇줄의 코드를 위해 얼마나 깊은 설계가 들어갔는지 생각해보자\
        // 
        Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };

        // Person[]에 저장된 데이터를 가지고 People개체 생성
        People peopleList = new People(peopleArray);

        // People이 IEnumeralbe 인터페이스를 구현했기 때문에 열거형식으로 사용이 가능함
        foreach (Person p in peopleList)
            Console.WriteLine(p.firstName + " " + p.lastName);
    }
}

/* This code produces output similar to the following:
 *
 * John Smith
 * Jim Johnson
 * Sue Rabon
 *
 */