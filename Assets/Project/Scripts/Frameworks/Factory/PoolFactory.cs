using System.Collections.Generic;
using UnityEngine;

public abstract class PoolFactory
{
    protected Dictionary<int, Queue<Poolable>> _pool;

    public void Init()
    {
        _pool = new Dictionary<int, Queue<Poolable>>();
    }

    public void Release()
    {
        _pool.Clear();
    }
    
    public void ObjRelease(int id, Poolable obj)
    {
        if (_pool.ContainsKey(id))
        {
            _pool[id].Enqueue(obj);
        }
        else
        {
            Queue<Poolable> queue = new Queue<Poolable>();
            queue.Enqueue(obj);
            _pool.Add(id, queue);
        }
    }

    protected Poolable CreateObj(string path, int id, Transform parent = null)
    {
        GameObject obj = ResourceLoader.Instantiate(path, parent);
        obj.SetActive(false);
        Poolable poolable = obj.AddComponent<Poolable>();
        poolable.InitOnCreate(this, id);
        return poolable;
    }
    
}