using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int HealAmount;
    public GameObject HealPanel;
    private bool healed = false;
    private MilicaHealth milicahealth;
    public GameObject milicaAni;
    private bool once = false;
    public int CollectionNum;
    


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && once ==false)
        {

            CollectionCount.ach01Count = CollectionNum;
            HealPanel = GameObject.Find("Canvas2");
            milicaAni = GameObject.FindWithTag("Player");
            milicahealth = milicaAni.gameObject.GetComponent<MilicaHealth>();
            StartCoroutine(HealCoroutine());
        }

    }

    IEnumerator HealCoroutine()
    {
        if (healed == false)
        {
            healed = true;
            milicahealth.Heal(HealAmount);
            HealPanel.transform.Find("Heal").gameObject.SetActive(true); //캔버스에서 힐 이펙트 화면을 튼다.

            yield return new WaitForSeconds(1f);
            HealPanel.transform.Find("Heal").gameObject.SetActive(false);

            healed = false;
            once = true;
        }
    }
}

