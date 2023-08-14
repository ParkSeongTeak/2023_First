using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D _myRgbd2D;
    //const float _jumpForce = 17f;
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
        _myRgbd2D.gravityScale = 18;
        ///
    }


    public void Jump(float jumpForce = 17f, bool isJumperItem = false)
    {
        
        if (_canJump | isJumperItem)
        {
            //점프키 누르면 어쩌구 저쩌구
            _canJump = false;
            //GameManager.InGameDataManager.NowState.JumpCnt++;
            _myRgbd2D.AddForce(new Vector3(0, 1f, 0) * jumpForce, ForceMode2D.Impulse);
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
    public void Unbeatable(float time = 10f)
    {
        if (GameUI.Instance.isUnbeatable)   //true상태
        {
            UnbeatCoroutine = StartCoroutine(UnbeatAnim(anims.Idle_unbeatable, time));
        }
       
    }
    public void UnbeatableEnd()
    {
        if(UnbeatCoroutine != null)
        {
            StopCoroutine(UnbeatCoroutine);
        }
        string str = Enum.GetName(typeof(anims), anims.Idle_unbeatable);
        _animator.SetBool($"{str}Bool", false);
        //isUnbeatAnim = false;


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

    //bool isUnbeatAnim = false;

    IEnumerator UnbeatAnim(anims anim, float time = 10f)
    {
        //무적 중복 적용 시 코루틴을 끊고 재시작해야 하는데, 동시 출력을 막으려고 2~3중으로 if 문을 걸어 에러가 남

        //if (!isUnbeatAnim)
        //{
        //isUnbeatAnim = true;
        string str = Enum.GetName(typeof(anims), anim);
        _animator.SetBool($"{str}Bool", true);
        yield return new WaitForSeconds(time);
        _animator.SetBool($"{str}Bool", false);
        //isUnbeatAnim = false;

        //}
    }

}
