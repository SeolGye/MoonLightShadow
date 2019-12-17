using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{


    public int ach07Code;
    public float MilicaHealthValue;
    public bool timeOver;
    public GameObject PressText;

    public GameObject Canvas;
    public GameObject Canvas2;

    void Start()
    {
        timeOver = false;
        //Canvas2 = GameObject.Find("Canvas2");

        MilicaHealthValue = PlayerPrefs.GetFloat("MilicaHealthValue");
        Canvas = GameObject.Find("Canvas");
        
        StartCoroutine(EndCoroutine());
    }

    void Update()
    {
        ach07Code = PlayerPrefs.GetInt("Ach07");

        if(Input.GetMouseButtonDown(0)&& timeOver == true)
        {
            SceneManager.LoadScene(1);


        }

    }

    IEnumerator Cut(string Num, float Dur)
    {
        Canvas.transform.Find(Num).gameObject.SetActive(true);
        Canvas.transform.Find("FadeIn").gameObject.SetActive(true);
        yield return new WaitForSeconds(Dur);
        Canvas.transform.Find("FadeOut").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find(Num).gameObject.SetActive(false);
        Canvas.transform.Find("FadeIn").gameObject.SetActive(false);
        Canvas.transform.Find("FadeOut").gameObject.SetActive(false);
    }

    IEnumerator ShortCut(string Num, float Dur)
    {
        Canvas.transform.Find(Num).gameObject.SetActive(true);
        yield return new WaitForSeconds(Dur);
        Canvas.transform.Find(Num).gameObject.SetActive(false);
    }



    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(4f);
        timeOver = true;
        PressText.SetActive(true);
    }
    IEnumerator TimeCoroutine2()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);

    }

    IEnumerator EndCoroutine()
    {

        yield return StartCoroutine(Cut("1",3f));

        yield return StartCoroutine(Cut("2", 3f));

        yield return StartCoroutine(Cut("3", 3f));

        yield return StartCoroutine(Cut("4", 1.5f));

        yield return StartCoroutine(Cut("5", 1.5f));

        yield return StartCoroutine(Cut("6", 1.5f));

        yield return StartCoroutine(Cut("7", 1.5f));

        yield return StartCoroutine(Cut("8", 2f));

        yield return StartCoroutine(Cut("9", 1.5f));

        yield return StartCoroutine(Cut("10", 1.5f));

        yield return StartCoroutine(Cut("11", 2.5f));

        yield return StartCoroutine(Cut("12", 1.5f));


        yield return StartCoroutine(Cut("13", 3f));

        yield return StartCoroutine(ShortCut("14", 1.5f));

        yield return StartCoroutine(ShortCut("15", 1.5f));

        yield return StartCoroutine(ShortCut("16", 1.5f));

        yield return StartCoroutine(ShortCut("17", 1.5f));

        yield return StartCoroutine(ShortCut("18", 1.5f));

        yield return StartCoroutine(ShortCut("19", 1.5f));

      //  yield return StartCoroutine(ShortCut("20", 1.5f));

        yield return StartCoroutine(ShortCut("21", 0.75f));

        yield return StartCoroutine(ShortCut("22", 0.75f));

        yield return StartCoroutine(ShortCut("23", 1.5f));

        yield return StartCoroutine(ShortCut("24", 1.5f));

        //yield return StartCoroutine(ShortCut("25", 1.5f));


       // yield return StartCoroutine(ShortCut("26", 1.5f));


        yield return StartCoroutine(ShortCut("27", 1.5f));

        yield return StartCoroutine(ShortCut("29", 1.5f));

        yield return StartCoroutine(ShortCut("28", 1.5f));



        Canvas.transform.Find("TitleMain").gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Canvas.transform.Find("TitleMain").gameObject.transform.Find("Vow1").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        Canvas.transform.Find("TitleMain").gameObject.transform.Find("Con1").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        Canvas.transform.Find("TitleMain").gameObject.transform.Find("Vow2").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        Canvas.transform.Find("TitleMain").gameObject.transform.Find("Con2").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        Canvas.transform.Find("TitleMain").gameObject.transform.Find("Vow3").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        Canvas.transform.Find("TitleMain").gameObject.transform.Find("Con3").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        Canvas.transform.Find("TitleMain").gameObject.transform.Find("Vow4").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        Canvas.transform.Find("TitleMain").gameObject.transform.Find("Con4").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);


        Canvas.transform.Find("Present").gameObject.SetActive(true);
        Canvas.transform.Find("Name").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Present").gameObject.SetActive(false);
        Canvas.transform.Find("Name").gameObject.SetActive(false);

        Canvas.transform.Find("Director").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Director").gameObject.SetActive(false);

        Canvas.transform.Find("Designer").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Designer").gameObject.SetActive(false);

        Canvas.transform.Find("Programming").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Programming").gameObject.SetActive(false);

        Canvas.transform.Find("Name (1)").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Name (1)").gameObject.SetActive(false);

        Canvas.transform.Find("Vocal").gameObject.SetActive(true);
        Canvas.transform.Find("Name (2)").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Vocal").gameObject.SetActive(false);
        Canvas.transform.Find("Name (2)").gameObject.SetActive(false);

        Canvas.transform.Find("Sound").gameObject.SetActive(true);
        Canvas.transform.Find("Name (3)").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Sound").gameObject.SetActive(false);
        Canvas.transform.Find("Name (3)").gameObject.SetActive(false);

  
        /*
        Canvas.transform.Find("Special").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Special").gameObject.SetActive(false);

        Canvas.transform.Find("You").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("You").gameObject.SetActive(false);

        */

        yield return new WaitForSeconds(1.5f);
        Canvas.transform.Find("Continue").gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Canvas.transform.Find("Continue").gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);

        if (ach07Code != 9407 && MilicaHealthValue>0.5)
        {
            Debug.Log(MilicaHealthValue);
            Canvas.SetActive(false);
            Canvas2.SetActive(true);
            timeOver = false;
            ach07Code = 9407;
            PlayerPrefs.SetInt("Ach07", ach07Code);
            yield return StartCoroutine(TimeCoroutine());

        }
        else
        {
            yield return StartCoroutine(TimeCoroutine2());

        }

    }
}
