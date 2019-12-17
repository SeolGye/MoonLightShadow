using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DonationManager : MonoBehaviour
{
    private bool timeOver;
    public GameObject FadeIn;
    public GameObject FadeOut;

    void Start()
    {

        timeOver = false;
        StartCoroutine(TimeCoroutine());
    }

    public void BackButtonFunc()
    {
        if (timeOver == true)
        {
            StartCoroutine(TimeCoroutine2());
        }

    }
    /* void Update()
    {
       if (Input.GetMouseButtonDown(0) && timeOver == true)
        {
            StartCoroutine(TimeCoroutine2());
        }
       

} */

    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(1f);
        timeOver = true;
        FadeIn.SetActive(false);

    }
    IEnumerator TimeCoroutine2()
    {
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);


    }
}
