using System;
using System.Collections.Generic;

public static class EventRouter
{
    private static Dictionary<Type,Delegate> _eventDict = new Dictionary<Type, Delegate>();
    
    public static void Subscribe<T>(Action<T> action)
    {
        var type = typeof(T);
        if (_eventDict.TryGetValue(type, out var del))
        {
            _eventDict[type] = Delegate.Combine(del, action);
        }
        else
        {
            _eventDict[type] = action;
        }
    }
    public static void Unsubscribe<T>(Action<T> action)
    {
        var type = typeof(T);
        if (_eventDict.TryGetValue(type, out var del))
        {
            _eventDict[type] = Delegate.Remove(del, action);
        }
    }
    public static void Publish<T>(T e)
    {
        var type = typeof(T);
        if (_eventDict.TryGetValue(type, out var del))
        {
            (del as Action<T>)?.Invoke(e);
        }
    }

    public static void ClearAll() => _eventDict.Clear();
    
}
