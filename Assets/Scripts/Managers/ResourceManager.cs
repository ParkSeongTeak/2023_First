using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    /// <summary>
    /// 굳이 Pooling까지 해야하나..... 고민중
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    /// <summary> GameObject 생성 </summary>
    public GameObject Instantiate(string path, Transform parent = null) => Instantiate<GameObject>(path, parent);
    /// <summary> T type object 생성 </summary>
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

    }
}
