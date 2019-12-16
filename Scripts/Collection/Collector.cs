using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private int achCode1;
    private int achCode2;
    private int achCode3;
    private int achCode4;
    private int achCode5;
    private int achCode6;
    private int achCode7;
    private int achCode8;
    private int achCode9;

    private GameObject Collection;

    void Start()
    {
        Collection = GameObject.Find("Canvas");
        achCode1 = PlayerPrefs.GetInt("Ach01");
        achCode2 = PlayerPrefs.GetInt("Ach02");
        achCode3 = PlayerPrefs.GetInt("Ach03");
        achCode4 = PlayerPrefs.GetInt("Ach04");
        achCode5 = PlayerPrefs.GetInt("Ach05");
        achCode6 = PlayerPrefs.GetInt("Ach06");
        achCode7 = PlayerPrefs.GetInt("Ach07");
        achCode8 = PlayerPrefs.GetInt("Ach08");
        achCode9 = PlayerPrefs.GetInt("Ach09");

        StartCoroutine(CollectorCoroutine());

    }

    IEnumerator CollectorCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (achCode1 == 9401)
        {
            Collection.transform.Find("1").gameObject.SetActive(true);
        }
        if (achCode2 == 9402)
        {
            Collection.transform.Find("2").gameObject.SetActive(true);
        }
        if (achCode3 == 9403)
        {
            Collection.transform.Find("3").gameObject.SetActive(true);
        }
        if (achCode4 == 9404)
        {
            Collection.transform.Find("4").gameObject.SetActive(true);
        }
            if (achCode5 == 9405)
            {
                Collection.transform.Find("5").gameObject.SetActive(true);
            }
            if (achCode6 == 9406)
            {
                Collection.transform.Find("6").gameObject.SetActive(true);
            }
            if (achCode7 == 9407)
            {
                Collection.transform.Find("7").gameObject.SetActive(true);
            }
            if (achCode8 == 9408)
            {
                Collection.transform.Find("8").gameObject.SetActive(true);
            }
            if (achCode9 == 9409)
            {
                Collection.transform.Find("9").gameObject.SetActive(true);
            }
        
    }
}
