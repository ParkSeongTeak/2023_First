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
        _spriteArray = Resources.LoadAll<Sprite>("Sprites/Character/Idle");
        StartCoroutine(Func_PlayAnimUI());
    }
    
    IEnumerator Func_PlayAnimUI()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_Speed);
            if (m_IndexSprite >= _spriteArray.Length)
            {
                m_IndexSprite = 0;

            }
            _image.sprite = _spriteArray[m_IndexSprite];
            m_IndexSprite += 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    
}
