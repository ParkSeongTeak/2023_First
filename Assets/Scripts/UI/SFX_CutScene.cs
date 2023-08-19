using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_CutScene : MonoBehaviour
{
    // Start is called before the first frame update
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

    private void sfx0Play()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(sfx[0]);
    }
    private void sfx1Play()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(sfx[1]);
    }
    private void sfx2Play()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(sfx[2]);
    }
    private void sfx3Play()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(sfx[3]);
    }
    private void sfx4Play()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(sfx[4]);
    }


}
