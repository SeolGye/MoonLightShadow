using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection1 : MonoBehaviour
{
    private bool healed = false;
    private GameObject Heal;
    private bool once = false;
    public string HealName;
    AudioSource myAudio;
    public AudioClip getSoundClip;

    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && once == false)
        {
          
            Heal = GameObject.Find(HealName); //오브젝트를 찾는다
            StartCoroutine(HealCoroutine());
        }


    }

    IEnumerator HealCoroutine()
    {
        if (healed == false) // 중복실행 방지
        {
            healed = true;
            Heal.transform.Find("Letter").gameObject.SetActive(true);
            Heal.transform.Find("HealEffect").gameObject.SetActive(true);
            //오브젝트 자식들을 켜준다
            if (!myAudio.isPlaying)
            {
                myAudio.clip = getSoundClip;
                myAudio.loop = false;
                myAudio.Play();
            }
            yield return new WaitForSeconds(1f);

            healed = false;
            once = true; // 한 번만 실행
        }
    }
}
