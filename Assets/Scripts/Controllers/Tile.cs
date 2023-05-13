using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    int _cnt;
    public int Cnt{ get {return _cnt; } set { _cnt = value; } }

    private void Start()
    {
        //Cnt = 3;
        Cnt = GameManager.InGameDataManager.NormalQuestHandler[1].Jump;
    }
    public void JumpOnMe() 
    {
        Cnt--;
        Debug.Log($"Cnt{Cnt}");
        if (Cnt == 0)
        {
            Debug.Log("¸¸°³!");
            
        }
        if(Cnt < 0)
        {
            Destroy(gameObject);
            //GameManager.Á×À½! 
            //GetComponent<GameOver>().EnableGameOverMenu();
        }
    }

}
