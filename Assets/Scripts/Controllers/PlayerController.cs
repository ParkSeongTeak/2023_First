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
        //점프키 누르면 어쩌구 저쩌구
        //

    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
