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
        int index = 1;
        while (true)
        {
            yield return new WaitForSeconds(m_Speed);
            _image.sprite = GameManager.ResourceManager.Load<Sprite>($"Sprites/Character/idle{index++}");
            if (index >= 7) 
            { 
                index = 1; 
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    
}
