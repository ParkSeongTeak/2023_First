using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.InputManager.InputAction += JumpBtn;

    }


    public void JumpBtn()
    {
        //����Ű ������ ��¼�� ��¼��
        //

    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
