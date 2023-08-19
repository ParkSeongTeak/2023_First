using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{

    Image _image;

    Sprite[] _spriteArray;
    float m_Speed = .175f;
    private int m_IndexSprite;
    



    void Init()
    {
        _image = GetComponent<Image>();
        StartCoroutine(Func_PlayAnimUI());
    }
    
    IEnumerator Func_PlayAnimUI()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_Speed);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    
}
