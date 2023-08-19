using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class FlowerBudTile : Tile
{
    int JumpLeft;
    public Define.FlowerTypes MyFlowerType { get; set; }
    public Define.BudFlower FlowerJumpType { get; set; }
    
    Animator _animator;
    AnimationClip _animationClip;
    float plusTime_bloom = 0.05f; 

    public override void Init()
    {
        _animator = gameObject.GetComponent<Animator>();
        _animator.enabled= true;
        FlowerJumpType = TileController.Instance.SetCosmosFlowerType();
        MyFlowerType = TileController.Instance.SetFlowerType(); //���߿� 3�� �� �������� ���� ���� �ڵ�� �����ؾ���
        _animator.speed = 1.0f;

        JumpLeft = (int)FlowerJumpType + 1;
        string AnimName = $"{Enum.GetName(typeof(Define.FlowerTypes), MyFlowerType)}{JumpLeft}";

        if (_animator == null)
        {
            Debug.Log($"null :: Animation/FlowerBudAnims/{AnimName}");
        }

        if (JumpLeft != 0)
        {
            _animationClip = GameManager.ResourceManager.Load<AnimationClip>($"Animation/FlowerBudAnims/{AnimName}");


            _animator.Play(_animationClip?.name);
            
        }
        
       

    }
    public override void JumpOnMe()
    {
        
        //���� ����� �Լ�(base == Tile)�� JumpOnMe() ����
        //base.JumpOnMe();
        if (JumpLeft > 0)
        {

            JumpLeft--;

            string AnimName = $"{Enum.GetName(typeof(Define.FlowerTypes), MyFlowerType)}{JumpLeft}";
            Debug.Log(AnimName);
            _animationClip = GameManager.ResourceManager.Load<AnimationClip>($"Animation/FlowerBudAnims/{AnimName}");
            _animator.Play(_animationClip?.name);
            
            
            if (JumpLeft == 0)
            {
                //transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[(int)MyFlowerType];
                //GameManager.InGameDataManager.NowState.BloomCnt++;
                StartCoroutine(Bloom());
            }
        }
        else
        {
            if (!GameManager.InGameDataManager.NowUnbeat)
            {
                if (GameManager.InGameDataManager.NowState.LifeCnt > 2)
                {
                    GameManager.InGameDataManager.NowState.LifeCnt --;                       //목숨 깎임
                    GameManager.SoundManager.Play(Define.SFX.GlassBreak);

                }
                else if (GameManager.InGameDataManager.NowState.LifeCnt == 2)
                {
                    GameManager.UIManager.ShowSceneUI<GameUI>().LifeIcon.SetActive(false);  //목숨 아이템 소모 : 아이콘 해제
                    GameManager.InGameDataManager.NowState.LifeCnt = 1;                       //목숨 깎임
                    GameManager.SoundManager.Play(Define.SFX.GlassBreak);
                    GameUI.Instance.PlusLifeItemIcon.SetActive(false);


                }
                else
                {
                    TileController.Instance.TileBreak(this);
                    GameManager.SoundManager.Play(Define.SFX.Falling_02);//Falling_02효과음
                    GameManager.SoundManager.StopBGM(Define.BGM.블라썸컴퍼니_01);
                    Debug.Log("멈춤");
                }
            }

        }
    }


    public override void SkipOnMe()
    {
         
    }

    public override void AllBloom()
    {
        StartCoroutine(Bloom(0));
    }

    IEnumerator Bloom(float time = 0.05f)
    {
        _animator.enabled = false;
        JumpLeft = 0;

        GameManager.SoundManager.StopSFX(Define.SFX.Jump_01);//Jump_01효과음 중지
        GameManager.SoundManager.Play(Define.SFX.Bloom_01);//Bloom_01효과음
        GameUI.Instance.BloomCnt(time);
        

        yield return new WaitForSeconds(0.02f);
        
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[(int)MyFlowerType];
    }
}
