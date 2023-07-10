using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Move : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.A))
                animator.SetBool("SkipBool", true);

            else if (Input.GetKeyDown(KeyCode.S))
                animator.SetBool("SkipBool", false);


            else if (Input.GetKeyDown(KeyCode.D))
                animator.SetBool("JumpBool", true);

            else if(Input.GetKeyDown(KeyCode.W))
                animator.SetBool("JumpBool", false);


    }



}
        
    


    

   
