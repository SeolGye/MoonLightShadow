using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MilicaHealth : MonoBehaviour
{

    public  float MilicaHealthValue;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public GameObject DeadEffect;
    public GameObject SparkEffect;
    public int healthAmount;
    public int healthAmountMax =100;
    public List<GameObject> sparks = new List<GameObject>();

    public int lastCount;

    public GameObject LastCountDown;
    public Text LastCountDownT;


    public PhaseManager7 phaseManager;
    public CameraTrack cameraTrack;
    public Transform LastShot;
    public Animator BossAni;
    public GameObject Bosal;
    public BossAct bossAct;
    // 주인공이 마지막 아이템 다 먹었을 때 보스 마지막 연출 

    public GameObject Pot;

    void Start()
    {
        lastCount = 0;
        healthAmount = healthAmountMax;
    }
    void Update()
    {

        MilicaHealthValue = GetHealthNormalized();
        PlayerPrefs.SetFloat("MilicaHealthValue", MilicaHealthValue);


        if (lastCount >=1)
        {

            LastCountDown= GameObject.Find("Canvas2");
            LastCountDown.transform.Find("LastCountDown").gameObject.SetActive(true);
            LastCountDown.transform.Find("LastCountDown").gameObject.GetComponent<Text>().text = string.Format("{0}", lastCount);  

        }



        if (sparks.Count == 3)
        {
            for (int i = 0; i < sparks.Count; i++)
            {
                Destroy(sparks[i].gameObject);
            }
            sparks.Clear();
        }



        if(lastCount == 10) // 다 채우면
        {

            StartCoroutine(LastSceneCoroutine());

           
        }
    }

    public void Damage(int amount)
    {
        healthAmount -= amount;
        GameObject instance =  Instantiate(SparkEffect, transform.position, transform.rotation);
        sparks.Add(instance);
        

        if (healthAmount <= 0)
        {
            healthAmount = 0;
            makeDead();
        }
        if (OnDamaged != null) OnDamaged(this, EventArgs.Empty);
    }

    public void Heal(int amount)
    {
        healthAmount += amount;
        if (healthAmount > healthAmountMax)
        {
            healthAmount = healthAmountMax;
        }
        if (OnHealed != null) OnHealed(this, EventArgs.Empty);

    }

    public float GetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }

    public void LastCount()
    {
        lastCount += 1;
    }

    public void makeDead()
    {
        CameraTrack.instance.DeadSound();

        Pot.SetActive(false);
        Destroy(gameObject);
        Instantiate(DeadEffect, transform.position, transform.rotation);

        GameManager.instance.OnPlayerDestroy();
    }

    IEnumerator LastSceneCoroutine()
    {

        LastCountDown.transform.Find("FadeAction").gameObject.SetActive(true);// 페이드 아웃
        yield return new WaitForSeconds(1f); // 1초 후
                                             /*LastCountDown.transform.FindChild("FadeAction").gameObject.GetComponent<Animator>().SetTrigger("FadeIn"); // 페이드 인
                                             phaseManager.enabled  = false ;//카메라 패턴 멈추고
                                             MilicaMovement.instance.StopMove();
                                             // 캐릭터 멈추고
                                             Bosal.SetActive(false);
                                             cameraTrack.SetTarget(LastShot.transform); // 카메라 위치 고정
                                             bossAct.enabled = false;

                                             BossAni.SetTrigger("BossDie");
                                             //연출 보여주고

                                             yield return new WaitForSeconds(8f);

                                             //페이드 아웃
                                             LastCountDown.transform.FindChild("FadeAction").gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
                                             */
        SceneManager.LoadScene(6); // 로딩

    }
}
