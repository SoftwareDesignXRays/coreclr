using System;
using System.Collections.Generic;
/// <summary>
///IsReadOnly 
/// </summary>
public class ListICollectionIsReadOnly 
{
    public static int Main()
    {
        ListICollectionIsReadOnly ListICollectionIsReadOnly = new ListICollectionIsReadOnly();
        TestLibrary.TestFramework.BeginTestCase("ListICollectionIsReadOnly");
        if (ListICollectionIsReadOnly.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: In the default implementation of List, this property IsReadOnly always returns false.");
        try
        {
            List<int> myList = new List<int>();
            bool expectValue = false;
            bool returnValue = ((ICollection<int>)myList).IsReadOnly;
            if (expectValue != returnValue)
            {
                TestLibrary.TestFramework.LogError("001.1" , " Calling IsReadOnly property should return false");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest2: In the user define implementation of List, this property IsReadOnly may return true.");
        try
        {
            MyTestListICollection<int> myList = new MyTestListICollection<int>();
            bool expectValue = true;
            bool returnValue = ((ICollection<int>)myList).IsReadOnly;
            if (expectValue != returnValue)
            {
                TestLibrary.TestFramework.LogError("002.1", " Calling IsReadOnly property should return true");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    
}
public class MyTestListICollection<T> :List<T>, ICollection<T>
{


    #region ICollection<T> Members

    void ICollection<T>.Add(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    void ICollection<T>.Clear()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    bool ICollection<T>.Contains(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    int ICollection<T>.Count
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    bool ICollection<T>.IsReadOnly
    {
        get { return true; }
    }

    bool ICollection<T>.Remove(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IEnumerable<T> Members

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}
