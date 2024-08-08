using System.Collections.Generic;
using System;

public class Pool<T>
{

    Func<T> _factoryMethod;

    Action<T> _turnOnCallback;
    Action<T> _turnOffCallback;

    List<T> _currentStock;

    public Pool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialAmount)
    {
        _currentStock = new List<T>();
        _factoryMethod = factoryMethod;
        _turnOnCallback = turnOnCallback;
        _turnOffCallback = turnOffCallback;

        for (int i = 0; i < initialAmount; i++)
        {
            T obj = _factoryMethod();

            _turnOffCallback(obj);

            _currentStock.Add(obj);
        }
    }
    public T GetObject()
    {
        T result;

        if(_currentStock.Count == 0)
        {
            result = _factoryMethod();
        }
        else
        {
            result = _currentStock[0];
            _currentStock.RemoveAt(0);
        }

        _turnOnCallback(result);

        return result;
    }
    public void ReturnObjectToPool(T obj)
    {
        _turnOnCallback(obj);
        _currentStock.Add(obj);
    }
}
