using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip BGM1;
    public AudioClip BGM2;
    public AudioClip BGM3;
    public AudioClip BGM4;

    AudioSource myAudio;
    public static SoundManager instance;


    void Awake()
    {
        Application.targetFrameRate = 30;
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();


    }

    void Update()
    {
        if (Application.loadedLevel == 0 ) // 타이틀
        {
            if (!myAudio.isPlaying)
            {
                myAudio.volume = 1f;
                myAudio.clip = BGM1;
                myAudio.Play();
            }
        }
        if (Application.loadedLevel == 1 ) // 메인 화면
        {
            if (!myAudio.isPlaying)
            {
                myAudio.volume = 1f;
                myAudio.clip = BGM1;
                myAudio.Play();
            }
        }
        if (Application.loadedLevel == 2) //  콜렉션
        {
            if (!myAudio.isPlaying)
            {
                myAudio.volume = 1f;
                myAudio.clip = BGM1;
                myAudio.Play();
            }
        }


        if (Application.loadedLevel == 4) // 로딩화면 끄기
        {
            myAudio.Stop();
        }


        if (Application.loadedLevel == 5) // 게임 플레이
        {

            if (!myAudio.isPlaying && GameManager.instance.isRoundActive == true)
            {
                myAudio.volume = 1f;
                myAudio.clip = BGM2;
                myAudio.Play();
            }

        }

        if (Application.loadedLevel == 6 ) // 엔딩 
        {
            myAudio.volume = 1f;

            myAudio.Stop();
        }

        if (Application.loadedLevel == 7) // 엔딩
        {
            myAudio.volume = 1f;

            myAudio.Stop();
        }

        if (Application.loadedLevel == 8) // 엔딩
        {
            myAudio.volume = 1f;

            myAudio.Stop();
        }

        if (Application.loadedLevel == 9) // 엔딩크레딧 
        {
            if (!myAudio.isPlaying)
            {
                myAudio.volume = 1f;
                myAudio.clip = BGM3;
                myAudio.Play();
            }
        }
        if (Application.loadedLevel == 10) //스토리
        {
            myAudio.Stop();

        }
        if (Application.loadedLevel == 11) //튜토리얼
        {
            if (!myAudio.isPlaying)
            {
                myAudio.volume = 1f;
                myAudio.clip = BGM4;
                myAudio.Play();
            }

        }

        


    }

    
  


}
    

