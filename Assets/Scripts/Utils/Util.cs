using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
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
        
        handler parseJsonToList = JsonUtility.FromJson<handler>($"{{\"{handle}\" : {json} }}");
        if (ConvertToDic) { parseJsonToList.ConvertToDic(); } 
        return parseJsonToList;
        
    }
    

}
