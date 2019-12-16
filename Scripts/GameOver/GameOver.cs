using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public bool timeOver ;
    public GameObject PressText;

    void Start()
    {
        timeOver = false;
        StartCoroutine(TimeCoroutine());
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)&&timeOver ==true)
        {

            SceneManager.LoadScene(1);

        }

      

    }

    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(4f);
        timeOver = true;
        PressText.SetActive(true);

    }
   
}
