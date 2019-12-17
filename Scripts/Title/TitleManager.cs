using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleManager : MonoBehaviour
{
    public Transform target;
    private float speed =3f;

    private bool timeOver;
    public GameObject PressText;
    public GameObject MainTitle;

    public Animator titleAni;
    public Animator[] MainTitleAni;
    
    
    void Start()
    {
        MainTitleAni = new Animator[8];
        titleAni = gameObject.GetComponent<Animator>();
        timeOver = false;
        StartCoroutine(TimeCoroutine());
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Input.GetMouseButtonDown(0) && timeOver == true)
        {
            StartCoroutine(FadeOutCoroutine());
            
        }

    }

    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(4f);
        timeOver = true;
        PressText.SetActive(true);
        MainTitle.SetActive(true);

    }
    IEnumerator FadeOutCoroutine()
    {
        titleAni.SetTrigger("FadeOut");


        MainTitle.transform.Find("Vow1").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        MainTitle.transform.Find("Con1").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        MainTitle.transform.Find("Vow2").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        MainTitle.transform.Find("Con2").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        MainTitle.transform.Find("Vow3").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        MainTitle.transform.Find("Con3").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        MainTitle.transform.Find("Vow4").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        MainTitle.transform.Find("Con4").gameObject.GetComponent<Animator>().SetTrigger("FadeOut");

        PressText.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
