using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    /// <summary>
    /// json ���� �Ľ��Ͽ� ������Ʈ�� ��ȯ<br/>
    /// * �ʿ� Ŭ����<br/>
    /// ���� ������ ������ �ִ� Ŭ����<br/>
    /// �����͵��� List���� �������� handler Ŭ����
    /// * json ����<br/>
    /// path�� default ��� Assets/Resources/Jsons/handler(���� �ڿ� Handler����).json
    /// handle�� default �̸� (List�� ����) "_" + (�ҹ��� ����)handler
    /// ConvertToDic default = true ���������� List���ٴ� Dic�� ��ȣ�ϰ� Key���� �˾Ƽ� ����
    /// </summary>
    /// <typeparam name="handler"></typeparam>
    /// <param name="path"> Assets/Resources/Jsons/File.json </param>
    /// <param name="handle"> Handler ���α��� List��</param>
    /// <param name="ConvertToDic"> List �� Dic���� �ٲ��� ����</param>
    /// <returns></returns>
    public static handler ParseJson<handler>(string path = null, string handle = null, bool ConvertToDic = true) where handler : Handler
    {
        if (string.IsNullOrEmpty(path))
        {
            string name = typeof(handler).Name;
            int idx = name.IndexOf("Handler");

            path = string.Concat(name.Substring(0, idx));
            handle =  "_" + char.ToLower(name[0]) + name.Substring(1);
        }
        else if (string.IsNullOrEmpty(handle))
        {
            string name = typeof(handler).Name;
            handle = "_" + char.ToLower(name[0]) + name.Substring(1);
        }

        TextAsset jsonTxt = Resources.Load<TextAsset>($"Jsons/{path}");
        if (jsonTxt == null)
        {
            Debug.LogError($"Can't load json : {path}");
            return default(handler);
        }
        string json = jsonTxt.text;
        Debug.Log(json);
        handler parseJsonToList = JsonUtility.FromJson<handler>($"{{\"{handle}\" : {json} }}");


        if (ConvertToDic) { parseJsonToList.ConvertToDic(); } 
        return parseJsonToList;
        
    }
    /// <summary>
    /// �ش� Game Object�� �ڽ� �� T ������Ʈ�� ���� �ڽ� ���
    /// </summary>
    /// <param name="name">�ڽ��� �̸�</param>
    /// <param name="recursive">����� Ž�� ����</param>
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null) return null;

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform child = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || child.name == name)
                {
                    T component = child.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach (T child in go.GetComponentsInChildren<T>())
                if (string.IsNullOrEmpty(name) || child.name == name)
                    return child;
        }

        return null;
    }

    /// <summary>
    /// Game Object ���� FindChild
    /// </summary>
    
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null) return null;
        return transform.gameObject;
    }
    
}
