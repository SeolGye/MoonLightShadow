using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCount : MonoBehaviour
{


    public static int ach01Count;


    public int ach01Trigger = 1;
    public int ach01Code;

    public int ach02Trigger = 2;
    public int ach02Code;

    public int ach03Trigger = 3;
    public int ach03Code;

    public int ach04Trigger = 4;
    public int ach04Code;

    public int ach05Trigger = 5;
    public int ach05Code;

    public int ach06Trigger = 6;
    public int ach06Code;

    public int ach07Trigger = 7;
    public int ach07Code;

    public int ach08Trigger = 8;
    public int ach08Code;

    public int ach09Trigger = 9;
    public int ach09Code;


    void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");
        ach02Code = PlayerPrefs.GetInt("Ach02");
        ach03Code = PlayerPrefs.GetInt("Ach03");
        ach04Code = PlayerPrefs.GetInt("Ach04");
        ach05Code = PlayerPrefs.GetInt("Ach05");
        ach06Code = PlayerPrefs.GetInt("Ach06");
        ach07Code = PlayerPrefs.GetInt("Ach08");
        ach08Code = PlayerPrefs.GetInt("Ach08");
        ach09Code = PlayerPrefs.GetInt("Ach09");

        if (ach01Count ==  ach01Trigger && ach01Code != 9401)
        {
            StartCoroutine(Trigger01Ach());
        }

        if (ach01Count == ach02Trigger && ach02Code != 9402)
        {
            StartCoroutine(Trigger02Ach());
        }
        if (ach01Count == ach03Trigger && ach03Code != 9403)
        {
            StartCoroutine(Trigger03Ach());
        }
        if (ach01Count == ach04Trigger && ach04Code != 9404)
        {
            StartCoroutine(Trigger04Ach());
        }
        if (ach01Count == ach05Trigger && ach05Code != 9405)
        {
            StartCoroutine(Trigger05Ach());
        }
        if (ach01Count == ach06Trigger && ach06Code != 9406)
        {
            StartCoroutine(Trigger06Ach());
        }
        if (ach01Count == ach07Trigger && ach07Code != 9407)
        {
            StartCoroutine(Trigger07Ach());
        }
        if (ach01Count == ach08Trigger && ach08Code != 9408)
        {
            StartCoroutine(Trigger08Ach());

        }
        if (ach01Count == ach09Trigger && ach09Code != 9409)
        {
            StartCoroutine(Trigger09Ach());
        }

    }

    IEnumerator Trigger01Ach()
    {
        ach01Code = 9401;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Trigger02Ach()
    {
        ach02Code = 9402;
        PlayerPrefs.SetInt("Ach02", ach02Code);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Trigger03Ach()
    {
        ach03Code = 9403;
        PlayerPrefs.SetInt("Ach03", ach03Code);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Trigger04Ach()
    {
        ach04Code = 9404;
        PlayerPrefs.SetInt("Ach04", ach04Code);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Trigger05Ach()
    {
        ach05Code = 9405;
        PlayerPrefs.SetInt("Ach05", ach05Code);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Trigger06Ach()
    {
        ach06Code = 9406;
        PlayerPrefs.SetInt("Ach06", ach06Code);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Trigger07Ach()
    {
        ach07Code = 9407;
        PlayerPrefs.SetInt("Ach07", ach07Code);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Trigger08Ach()
    {
        ach08Code = 9408;
        PlayerPrefs.SetInt("Ach08", ach08Code);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Trigger09Ach()
    {
        ach09Code = 9409;
        PlayerPrefs.SetInt("Ach09", ach09Code);
        yield return new WaitForSeconds(1f);
    }
}
