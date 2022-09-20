using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

internal class TunedTestObject : IEnumerable<string>
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    private List<string> _items = new() { "1", "2", "3" };

    public IEnumerator<string> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
}

public class DisableEvaluation 
{
    public int Value
    {
        get
        {
            Thread.Sleep(1000);
            return 1;
        }
    }
    
    public string Text { get; set; }
    public override string ToString() => "something";
    public DisableEvaluation _eval => new DisableEvaluation();
}

class Base
{
    public int BaseProp { set; get; }
}

class BaseImpl : Base
{
    public int ImplBaseProp { set; get; }
    private int ImplBasePropPrivate { set; get; }
}

class GenericClass<T, T1>
{
    public GenericClass()
    {
        
    }
}

public class Program
{ 
    public static void Main()
    {
        DisableEvaluation testdisable = new DisableEvaluation(); // try disable evaluation for the object
        DisableEvaluation testdisable2 = new DisableEvaluation();

        var baseImpl = new BaseImpl(); // Flatten object hierarchy, private properties, compiler-generated members
        
        var testObject = new TunedTestObject(); //add raw for debugger browsable values

        var i = new int[1000]; //cluster big arrays

        Type s = typeof(int); // show fully qualified type names

        var genericClass = new GenericClass<int, string>(); //set breakpoint inside class method, check Show Type Variable option
        
        Console.ReadKey();
    }
}