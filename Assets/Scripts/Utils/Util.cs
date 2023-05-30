using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
    /// <summary>
    /// json 파일 파싱하여 오브젝트로 반환<br/>
    /// * 필요 클래스<br/>
    /// 실제 데이터 가지고 있는 클래스<br/>
    /// 데이터들의 List등을 관리해줄 handler 클래스
    /// * json 파일<br/>
    /// path의 default 경로 Assets/Resources/Jsons/handler(에서 뒤에 Handler뺀거).json
    /// handle의 default 이름 (List로 구현) "_" + (소문자 시작)handler
    /// ConvertToDic default = true 개인적으로 List보다는 Dic을 선호하고 Key값은 알아서 결정
    /// </summary>
    /// <typeparam name="handler"></typeparam>
    /// <param name="path"> Assets/Resources/Jsons/File.json </param>
    /// <param name="handle"> Handler 내부구현 List명</param>
    /// <param name="ConvertToDic"> List 를 Dic으로 바꿀지 결정</param>
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
