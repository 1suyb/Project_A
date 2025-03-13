using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class InfoLoader<T> where T : LoadedInfoBase
{
    private Dictionary<int, T> _infoDic = new Dictionary<int, T>();
    private List<T> _infoList = new List<T>();

    [Serializable]
    public class Wrapper
    {
        public List<T> items;
    }
    
    public InfoLoader()
    {
        string jsonData = Resources.Load<TextAsset>($"Data/Json/{typeof(T).Name}").text;
        Wrapper wrapper = JsonConvert.DeserializeObject<Wrapper>(jsonData.Trim());
        _infoList = wrapper.items;
        foreach (T item in _infoList)
        {
            int id = item.ID;
            _infoDic.Add(id, item);
        }
    }
    
    public T Load(int id)
    {
        if (_infoDic.ContainsKey(id))
        {
            return _infoDic[id];
        }

        return null;
    }
    
    public List<T> LoadAll()
    {
        return _infoList;
    }
}

