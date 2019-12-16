using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{

    public AudioClip StepSoundClip;
    public static StepSound instance;

    AudioSource myAudio;

    void Awake()
    {
        StepSound.instance = this;
        myAudio = this.gameObject.GetComponent<AudioSource>();
    }

    public void StartStepSound()
    {
        if (!myAudio.isPlaying)
        {
            myAudio.clip = StepSoundClip;
            myAudio.loop = true;
            myAudio.Play();
        }
    }

    public void StopStepSound()
    {
        myAudio.Stop();
    }
}
