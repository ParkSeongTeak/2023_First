using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D _myRgbd2D;
    float _jumpForce = 10f;
    bool _canJump;
    Tile OnTile;
    Animator animator;

    public Sprite imageUnderThreshold;
    public Sprite defaultImage;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _canJump = true;
        GameManager.UIManager.UiImages[(int)Define.Images.flowerImg].sprite = GameManager.ResourceManager.Load<Sprite>("Sprites/img");
        _myRgbd2D = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        if(animator == null)
        {
            Debug.Log("???");
        }
    }


    public void Jump()
    {
        if (_canJump)
        {
            //점프키 누르면 어쩌구 저쩌구
            _canJump = false;
            GameManager.InGameDataManager.JumpCnt++;
            _myRgbd2D.AddForce(new Vector3(0, 1f, 0) * _jumpForce, ForceMode2D.Impulse);
            OnTile.JumpOnMe();
 
        }
    }

    public void Skip()
    {
        animator.SetBool("skip", true);
    }
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Flower")
        {
            _canJump = true;
            OnTile = collision.transform.GetComponent<Tile>();
        }
    }

    void Update()
    {
        /*if (transform.position.y < -4f)
        {
            GetComponent<GameOver>().EnableGameOverMenu();
        }
        else
        {
            GetComponent<GameOver>().DisableGameOverMenu();
        }*/

        if (transform.position.y < -3)
        {
            transform.GetComponent<SpriteRenderer>().sprite = imageUnderThreshold;
        }
        else
        {

        }
    }

}
