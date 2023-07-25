using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipJumpSwapItem : MonoBehaviour
{   private GameUI gameUI;
    private bool isEffectActive = false;
    private Coroutine coroutine;
    public GameObject Icon;

    GameObject icon;

    void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
        icon = Instantiate(Icon);
        icon.SetActive(false);
    }


    private IEnumerator isCounting()
    {

        while (isEffectActive == true)
        {
            Debug.Log("����");

            icon.SetActive(true);

            yield return new WaitForSecondsRealtime(7.0f);

            Debug.Log("��");
            isEffectActive = false;

            gameUI = FindObjectOfType<GameUI>();

            gameUI.isJumpActive = true;
            gameUI.isSkipActive = true;

            icon.SetActive(false);


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WingWing") 
        {

            if (isEffectActive == false)    //ȿ�� �����߾ƴ�  
            {
                isEffectActive = true;
                gameUI.isJumpActive = false;
                gameUI.isSkipActive = false;

                coroutine = StartCoroutine(isCounting());
            }
            else 
            {

                StopCoroutine(coroutine);

                isEffectActive = false;

                gameUI = FindObjectOfType<GameUI>();

                gameUI.isJumpActive = true;
                gameUI.isSkipActive = true;

                Debug.Log("�����");

                isEffectActive = true;
                gameUI.isJumpActive = false;
                gameUI.isSkipActive = false;

                coroutine = StartCoroutine(isCounting());

            }
        }
    }

}


