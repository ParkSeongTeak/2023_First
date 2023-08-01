using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class FlowerBudTile : Tile
{
    int JumpLeft;
    public Define.FlowerTypes MyFlowerType { get; set; }
    public Define.CosmosFlower FlowerJumpType { get; set; }
    
    Animator _animator;
    AnimationClip _animationClip;

    public override void Init()
    {
        _animator = GetComponent<Animator>();
        MyFlowerType = TileController.Instance.SetFlowerType(); //���߿� 3�� �� �������� ���� ���� �ڵ�� �����ؾ���

        FlowerJumpType = TileController.Instance.SetCosmosFlowerType();
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.CosmosFlowerSprites[(int)FlowerJumpType];
        JumpLeft = (int)FlowerJumpType;
        string AnimName = $"{Enum.GetName(typeof(Define.FlowerTypes), MyFlowerType)}{JumpLeft}";
        Debug.Log(AnimName);

    }
    public override void JumpOnMe()
    {
        //���� ����� �Լ�(base == Tile)�� JumpOnMe() ����
        //base.JumpOnMe();
        if (JumpLeft >= 0)
        {
            
            if (JumpLeft > 0)
            {
                //transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.CosmosFlowerSprites[JumpLeft];

                string AnimName = $"{Enum.GetName(typeof(Define.FlowerTypes), MyFlowerType)}{JumpLeft}";
                Debug.Log(AnimName);
                _animationClip = GameManager.ResourceManager.Load<AnimationClip>($"Animation/FlowerBudAnims/{AnimName}");
            
                if(_animationClip != null) 
                {
                    _animator.Play(_animationClip.name);
                }
                else
                {
                    transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.CosmosFlowerSprites[JumpLeft];

                }
            }

            JumpLeft--;
            
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
        yield return new WaitForSeconds(0.2f);

        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[(int)MyFlowerType];
        GameManager.InGameDataManager.NowState.BloomCnt++;
    }
}
