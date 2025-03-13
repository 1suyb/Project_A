using System;
using System.Collections.Generic;

public class InfoManager : Singleton<InfoManager>
{
    private Dictionary<Type, object> _infoLoaders = new Dictionary<Type, object>();

    public InfoLoader<T> GetInfoLoader<T>() where T : LoadedInfoBase
    {
        Type type = typeof(T);
        if (_infoLoaders.ContainsKey(type))
        {
            return _infoLoaders[type] as InfoLoader<T>;
        }

        InfoLoader<T> loader = new InfoLoader<T>();
        _infoLoaders.Add(type, loader);
        return loader;
    }
    
    public T Load<T>(int id) where T : LoadedInfoBase
    {
        InfoLoader<T> loader = GetInfoLoader<T>();
        return loader.Load(id);
    }
}