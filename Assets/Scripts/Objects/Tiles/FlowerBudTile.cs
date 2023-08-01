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
    [SerializeField]
    AnimationClip _animationClip;

    public override void Init()
    {
        
        _animator = GetComponent<Animator>();
        _animator.enabled= true;
        FlowerJumpType = TileController.Instance.SetCosmosFlowerType();
        MyFlowerType = TileController.Instance.SetFlowerType(); //���߿� 3�� �� �������� ���� ���� �ڵ�� �����ؾ���
        _animator.speed = 1.0f;

        JumpLeft = (int)FlowerJumpType;
        string AnimName = $"{Enum.GetName(typeof(Define.FlowerTypes), MyFlowerType)}{JumpLeft}";

        if (_animator == null)
        {
            Debug.Log($"null :: Animation/FlowerBudAnims/{AnimName}");
        }

        //transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.CosmosFlowerSprites[(int)FlowerJumpType];

        Debug.Log("AnimName = " + AnimName);
        if (JumpLeft != 0)
        {
            _animationClip = GameManager.ResourceManager.Load<AnimationClip>($"Animation/FlowerBudAnims/{AnimName}");
            _animator.Play(_animationClip?.name);
            if (_animationClip == null)
            {
                Debug.Log($"null :: Animation/FlowerBudAnims/{AnimName}");
            }
            else
            {
                Debug.Log($"Get :: {_animationClip.name}");

            }
            Debug.Log(AnimName);
        }
        else
        {
            StartCoroutine(Bloom());
            //transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[(int)MyFlowerType];
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
            if (GameManager.InGameDataManager.NowState.LifeCnt != 1)
            {
                GameManager.UIManager.ShowSceneUI<GameUI>().LifeIcon.SetActive(false);  //목숨 아이템 소모 : 아이콘 해제
                GameManager.InGameDataManager.NowState.LifeCnt--;                       //목숨 깎임
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }


    public override void SkipOnMe()
    {
         
    }

    public override void AllBloom()
    {
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[(int)MyFlowerType];
        GameManager.InGameDataManager.NowState.BloomCnt++;
    }

    IEnumerator Bloom()
    {
        _animator.enabled = false;

        yield return new WaitForSeconds(0.02f);
        
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[(int)MyFlowerType];
        GameManager.InGameDataManager.NowState.BloomCnt++;
    }
}
