using System;
using System.Linq;
using System.Collections.Generic;

public class RingArray<T>
{
    private T[] _array;
    private int _index;
    private int _arraySize;

    public T this[int index]
    {
        get
        {
            return _array[index];
        }
    } 
    
    public RingArray(IEnumerable<T> enumerable)
    {
        _arraySize = enumerable.Count();
        _array = enumerable.ToArray();
        _index = 0;
    }

    public T Next()
    {
        _index = (_index + 1) % _array.Length;

        return _array[_index];
    }

    public T GetCurrent()
    {
        return _array[_index];  
    }

    public T[] ToArray()
    {
        T[] array = new T[_arraySize];
        _array.CopyTo(array, 0);

        return array;
    }  
}