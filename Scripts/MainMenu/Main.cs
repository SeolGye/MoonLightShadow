using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour
{


  

    public void PlayBtn()
    {

        StartCoroutine(LoadScene());        
        

    }
    public void PlayStory()
    {
        StartCoroutine(StoryScene());
    }

    public void Collection()
    {
        StartCoroutine(CollectionScene());
    }

    public void Donation()
    {
        StartCoroutine(DonationScene());
    }
    public void Exit()
    {
        StartCoroutine(ExitScene());
    }

    
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);

    }
    IEnumerator CollectionScene()
    {
       yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);


    }
    IEnumerator DonationScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);


    }
    IEnumerator ExitScene()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();

    }
    IEnumerator StoryScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(11);
    }
}
