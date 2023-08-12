using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D _myRgbd2D;
    float _jumpForce = 16f;
    public const float SPEED = 0.15f; 
    bool _canJump;
    Tile _onTile;
    [SerializeField]
    Animator _animator;
    bool _isUnbeatable;



    //public Sprite imageUnderThreshold;
    //public Sprite defaultImage;

    private SpriteRenderer spriteRenderer;
    bool isAnim = false;
    enum anims
    {
        Idle,
        Jump,
        Skip,
        Idle_unbeatable,
        Jump_unbeatable,
        Skip_unbeatable,
    }

    // Start is called before the first frame update
    void Start()
    {
        _canJump = true;
        _myRgbd2D = GetComponent<Rigidbody2D>();
        //animator = transform.GetChild(0).GetComponent<Animator>();
        _animator = Util.FindChild<Animator>(gameObject, "PlayerAnim");

        ///
        GameManager.벨런스용_차후삭제필요();
        _myRgbd2D.gravityScale = Resources.Load<DataFix>("DataFix").Gravity_낙하속도;
        _jumpForce = Resources.Load<DataFix>("DataFix").JumpPower_점프높이;
        ///
    }


    public void Jump()
    {
        if (_canJump)
        {
            //점프키 누르면 어쩌구 저쩌구
            _canJump = false;
            //GameManager.InGameDataManager.NowState.JumpCnt++;
            _myRgbd2D.AddForce(new Vector3(0, 1f, 0) * _jumpForce, ForceMode2D.Impulse);
            _onTile.JumpOnMe();
            
            if (GameUI.Instance.isUnbeatable == true)
            {
                StartCoroutine(AnimPlay(anims.Jump_unbeatable));
            }
            else
            {
                StartCoroutine(AnimPlay(anims.Jump));
            }
                
        }
    }


    public void Skip()
    {
        if (GameUI.Instance.isUnbeatable)
        {
            StartCoroutine(AnimPlay(anims.Skip_unbeatable));
        }
        else
            StartCoroutine(AnimPlay(anims.Skip));
    }

    Coroutine UnbeatCoroutine;
    public void Unbeatable()
    {
        if (GameUI.Instance.isUnbeatable)   //true상태
        {
            UnbeatCoroutine = StartCoroutine(UnbeatAnim(anims.Idle_unbeatable));
        }
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Flower")
        {
            _canJump = true;
            _onTile = collision.transform.GetComponent<Tile>();
        }

    }

    

    GameObject newTile;

 
    private void Restart()
    {
        TileController tileController = TileController.Instance;

        if (tileController != null)
        {
          
            List<Tile> nowGeneratedTiles = tileController.NowGeneratedTiles;

            for (int i = 3; i <= 13; i++)
            {
                Tile tile = nowGeneratedTiles[i];

                TileController.Instance.MoveTiles();
            }
        }
    }


    IEnumerator AnimPlay(anims anim,float time = 0.33f)
    {
        if (!isAnim)
        {
            isAnim = true;
            string str = Enum.GetName(typeof(anims), anim);
            _animator.SetBool($"{str}Bool", true);
            yield return new WaitForSeconds(time);
            _animator.SetBool($"{str}Bool", false);
            isAnim = false;

        }
    }

    bool isUnbeatAnim = false;

    IEnumerator UnbeatAnim(anims anim, float time = 10f)
    {
        if (!isUnbeatAnim)
        {
            isUnbeatAnim = true;
            string str = Enum.GetName(typeof(anims), anim);
            _animator.SetBool($"{str}Bool", true);
            yield return new WaitForSeconds(time);
            _animator.SetBool($"{str}Bool", false);
            isUnbeatAnim = false;

        }
    }

}
