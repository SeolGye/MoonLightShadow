using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StroyIntroManager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject TestCha;
    public GameObject Outline;
    public GameObject Title;
    public GameObject ContentsText;


    public bool[] process = new bool[8];
    public Text contentExp;


    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        StartCoroutine(IntroCoroutine());

    }
    IEnumerator IntroCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Canvas.transform.Find("FadeIn").gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);        
        Canvas.transform.Find("FadeOut").gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Canvas.transform.Find("Present").gameObject.SetActive(false);
        Canvas.transform.Find("FadeOut").gameObject.SetActive(false);



        Canvas.transform.Find("FadeIn").gameObject.SetActive(true);
        Canvas.transform.Find("Director").gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Canvas.transform.Find("FadeIn").gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Canvas.transform.Find("FadeOut").gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        Canvas.transform.Find("FadeOut").gameObject.SetActive(false );
        Canvas.transform.Find("Director").gameObject.SetActive(false);

        Canvas.transform.Find("CutScene").gameObject.SetActive(true);
        yield return new WaitForSeconds(50f);
        Canvas.transform.Find("CutScene").gameObject.SetActive(false);

        SceneManager.LoadScene(4);



       






    }

}
