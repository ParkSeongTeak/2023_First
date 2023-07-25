using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpTmp : MonoBehaviour
{
    // Start is called before the first frame update
    Coroutine coroutine;

    IEnumerator tmptmp()
    {
        Debug.Log("½Ã");
        //gameObject.SetActive(false);

        Color tmpColor = new Color(1, 1, 1, 0);

        gameObject.GetComponent<SpriteRenderer>().color = tmpColor;
        yield return new WaitForSeconds(3.0f);

        Debug.Log("³¡");

        Destroy(this);
    }

    void Start()
    {
        coroutine = StartCoroutine(tmptmp());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
