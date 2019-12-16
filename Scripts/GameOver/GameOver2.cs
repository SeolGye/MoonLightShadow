using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver2 : MonoBehaviour
{
    public bool timeOver;
    public bool endScene;
    public GameObject PressText;
    public GameObject PressText2;

    public GameObject Canvas;
    public GameObject Canvas2;

    public int ach05Code;


    void Start()
    {
        endScene = false;
        timeOver = false;
        StartCoroutine(TimeCoroutine());
    }

    void Update()
    {
        ach05Code = PlayerPrefs.GetInt("Ach05");


        if (Input.GetMouseButtonDown(0) && timeOver == true)
        {

           

            if (ach05Code != 9405)
            {
                Canvas.SetActive(false);
                Canvas2.SetActive(true);
                timeOver = false;
                ach05Code = 9405;
                PlayerPrefs.SetInt("Ach05", ach05Code);
                StartCoroutine(TimeCoroutine2());

            }
            else
            {
                SceneManager.LoadScene(9);

            }

        }

        if (Input.GetMouseButtonDown(0) && endScene == true)
        {
            SceneManager.LoadScene(9);
        }

        if(Input.GetKeyDown("r"))
        {
            PlayerPrefs.DeleteAll();
        }

    }

    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(4f);
        timeOver = true;
        PressText.SetActive(true);

    }
    IEnumerator TimeCoroutine2()
    {
        yield return new WaitForSeconds(1f);
        endScene = true;
        PressText2.SetActive(true);

    }

}
