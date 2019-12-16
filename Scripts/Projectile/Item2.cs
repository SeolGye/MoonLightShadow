using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    public GameObject HealPanel;
    private bool healed = false;
    private MilicaHealth milicahealth;
    public GameObject milicaAni;



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HealPanel = GameObject.Find("Canvas2");
            milicaAni = GameObject.FindWithTag("Player");
            milicahealth = milicaAni.gameObject.GetComponent<MilicaHealth>();
            StartCoroutine(CountCoroutine());
        }

    }

    IEnumerator CountCoroutine()
    {
        if (healed == false)
        {
            healed = true;
            HealPanel.transform.Find("Heal").gameObject.SetActive(true);
            milicahealth.LastCount();
            yield return new WaitForSeconds(0.5f);
            HealPanel.transform.Find("Heal").gameObject.SetActive(false);
            MilicaSound.instance.ItemSound();
            healed = false;
        }
    }
}
