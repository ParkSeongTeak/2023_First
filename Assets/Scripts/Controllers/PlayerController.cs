using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.InputManager.InputAction += JumpBtn;
        
        GameManager.UIManager.UiImages[(int)Define.Images.flowerImg].sprite = GameManager.ResourceManager.Load<Sprite>("Sprites/img");

    }


    public void JumpBtn()
    {
        //����Ű ������ ��¼�� ��¼��
        //

    } 

}
