using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilicaSound : MonoBehaviour
{

    public AudioClip[] HurtSoundClip = new AudioClip[6];
    public AudioClip[] DeadSoundClip = new AudioClip[2];
    public AudioClip FallSoundClip ;
    public AudioClip ItemSoundClip;


    public static MilicaSound instance;
    public int hurtSoundNum;
    public int deadSoundNum;
    public bool canHurt;
    AudioSource myAudio ;


    
    void Awake()
    {
        MilicaSound.instance = this;
        myAudio = this.gameObject.GetComponent<AudioSource>();
        canHurt = true;
    } 

    public void HurtSound()
    {
        if (canHurt)
        {
            myAudio.Stop();
            myAudio.loop = false;
            hurtSoundNum = Random.Range(0, 6);
            myAudio.clip = HurtSoundClip[hurtSoundNum];
            myAudio.Play();
        }
    }
    public void DeadSound()
    {
       
            myAudio.Stop();
        myAudio.loop = false;

        deadSoundNum = Random.Range(0, 2);
            myAudio.clip = DeadSoundClip[deadSoundNum];
            myAudio.Play();
       
    }
    public void FallSound()
    {
       
            myAudio.Stop();
        myAudio.loop = false;

        myAudio.clip = FallSoundClip;
            myAudio.Play();
        
    }

    public void ItemSound()
    {
        myAudio.Stop();
        myAudio.loop = false;
        myAudio.clip = ItemSoundClip;
        myAudio.Play();

        
    }

    
}
