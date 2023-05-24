using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btnsound : MonoBehaviour
{
    public AudioClip bgm;
    public AudioClip[] sfx;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void sfx0Play()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(sfx[0]);
    }
    public void sfx1Play()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(sfx[1]);
    }


}



