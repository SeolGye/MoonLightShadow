using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionManager : MonoBehaviour
{
    private bool timeOver;
    public bool ClearScreen;
    public GameObject FadeIn;
    public GameObject FadeOut;

    void Start()
    {
        
        timeOver = false;
        StartCoroutine(TimeCoroutine());
    }

   
    public void BackButtonFunc()
    {
        if ( timeOver == true )
        {
            StartCoroutine(TimeCoroutine2());
        }

    }
    public void ZeroButtonFunc()
    {
        PlayerPrefs.DeleteAll();

    }

    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(3f);
        timeOver = true;
        FadeIn.SetActive(false);

    }
    IEnumerator TimeCoroutine2()
    {
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);


    }
}
