using UnityEngine;

public class Poolable : MonoBehaviour
{
    private PoolFactory _poolFactory;
    private int _id;
    public void InitOnCreate(PoolFactory poolFactory, int id)
    {
        _poolFactory = poolFactory;
        _id = id;
    }

    public void OnDisable()
    {
        Release();
    }

    private void Release()
    {
        _poolFactory.ObjRelease(_id, this);
        
    }
    
}