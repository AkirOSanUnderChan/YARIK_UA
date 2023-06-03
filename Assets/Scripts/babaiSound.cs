using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babaiSound : MonoBehaviour
{
    public AudioClip BabaiSongClip;

    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(BabaiSongClip, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void BabaiSong()
    {
        GetComponent<AudioSource>().PlayOneShot(BabaiSongClip, 1.0f);

    }



}
