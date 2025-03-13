using UnityEngine;

public static class ResourceLoader{
    public static T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
    
    public static GameObject Instantiate(string path, Transform parent, bool parentWorldPositionStays = false) 
    {
        GameObject prefab = Load<GameObject>(path);
        return Instantiate(prefab, parent, parentWorldPositionStays);
    }

    public static GameObject Instantiate(string path, Vector3 position = default, Quaternion rotate = default,
        Transform parent = null)
    {
        GameObject prefab = Load<GameObject>(path);
        return Instantiate(prefab, position, rotate, parent);
    }
    
    public static GameObject Instantiate(GameObject obj, Transform parent, bool parentWorldPositionStays = false) 
    {
        return GameObject.Instantiate(obj, parent, parentWorldPositionStays);
    }
    
    public static GameObject Instantiate(GameObject obj, Vector3 position = default, Quaternion rotate = default,
        Transform parent = null)
    {
        return GameObject.Instantiate(obj, position, rotate, parent);
    }
}