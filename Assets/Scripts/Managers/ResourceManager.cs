using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    Dictionary<string, UnityEngine.Object> Pool = new Dictionary<string, UnityEngine.Object>(); 
    public T Load<T>(string path) where T : Object
    {
        if (!Pool.ContainsKey(path))
        {
            Pool.Add(path, Resources.Load<T>(path));
        }

        return Pool[path] as T;
    }

    /// <summary> GameObject 持失 </summary>
    public GameObject Instantiate(string path, Transform parent = null) => Instantiate<GameObject>(path, parent);
    /// <summary> T type object 持失 </summary>
    public T Instantiate<T>(string path, Transform parent = null) where T : UnityEngine.Object
    {
        T prefab = Load<T>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.LogError($"Failed to load prefab : {path}");
            return null;
        }

        T instance = UnityEngine.Object.Instantiate<T>(prefab, parent);
        instance.name = prefab.name;

        return instance;
    }
    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
    public void Clear()
    {
        Pool.Clear();
    }
}
