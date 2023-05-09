using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D _myRgbd2D;
    float _jumpForce = 10f;
    bool _canJump;
    Tile OnTile;
    // Start is called before the first frame update
    void Start()
    {
        _canJump = true;
        GameManager.UIManager.UiImages[(int)Define.Images.flowerImg].sprite = GameManager.ResourceManager.Load<Sprite>("Sprites/img");
        _myRgbd2D = GetComponent<Rigidbody2D>();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Flower")
        {
            _canJump = true;
            OnTile = collision.transform.GetComponent<Tile>();
        }
    }



}
