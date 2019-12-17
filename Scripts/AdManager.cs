using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AdManager : MonoBehaviour
{

    public const string Android_GameID = "3362661";
    public const string Ios_GameID = "3362660";
    public const string RewardedVideoIndex = "rewardedVideo";
    public const string SkipVideoIndex = "video";
    public int ach06Code;
    public int ach08Code;
    public int ach09Code;
    public GameObject Canvas2;
    public bool endScene;
    public GameObject PressText2;
    public string blogLink = "http://blog.naver.com/artemis2494";

    //private string gameId= "3362661";


#if UNITY_ANDROID
        private string gameId = "3362661";
#elif UNITY_IOS
        private string gameId = "3362660";
#endif


    void Start()
    {
        endScene = false;
        Canvas2.SetActive(false);

        Init();
    }
    void Update()
    {
        ach06Code = PlayerPrefs.GetInt("Ach06");
        ach09Code = PlayerPrefs.GetInt("Ach09");

        if (endScene  == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);

        }

        if (Input.GetKeyDown("r"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    void Init()
    {

        Advertisement.Initialize(gameId,true);
        Debug.Log(gameId);

    }

    public void OpenBlog()
    {
        Application.OpenURL(blogLink);

        if (ach09Code != 9409)
        {
            Canvas2.SetActive(true);
            ach09Code = 9409;
            PlayerPrefs.SetInt("Ach09", ach09Code);
            StartCoroutine(TimeCoroutine2());

        }
    }

    public void ShowReward()
    {

        if (Advertisement.IsReady(RewardedVideoIndex))
        {
            var options = new ShowOptions { resultCallback = ResultAds };
            //광고가 끝나고 콜백함수를 호출한다.
            Advertisement.Show(RewardedVideoIndex, options);
            Debug.Log("dfd");

        }
    }

    void ResultAds(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown");
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end");
                break;
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown");
                if (ach06Code != 9406)
                {
                    Canvas2.SetActive(true);
                    ach06Code = 9406;
                    PlayerPrefs.SetInt("Ach06", ach06Code);
                    StartCoroutine(TimeCoroutine2());

                }

                break;

        }
    }
    public void SendEmail()
    {

        if (ach09Code != 9409)
        {
            Canvas2.SetActive(true);
            ach09Code = 9409;
            PlayerPrefs.SetInt("Ach09", ach09Code);
            StartCoroutine(TimeCoroutine2());

        }


        string mailTo = "artemis2494@naver.com";
        string subject = EscapeURL("월령기담 방명록");
        string body = EscapeURL
            (
            "이 곳에 내용을 작성해주세요. \n\n\n\n" +
            "_____________"
            );
        Application.OpenURL("mailto:" + mailTo + "?subject=" + subject + "&body=" + body);
    }
    public string EscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
        
    }

    public void Purchased()
    {
        if (ach09Code != 9408)
        {
            Canvas2.SetActive(true);
            ach08Code = 9408;
            PlayerPrefs.SetInt("Ach08", ach08Code);
            StartCoroutine(TimeCoroutine2());

        }
    }



    IEnumerator TimeCoroutine2()
    {
        yield return new WaitForSeconds(1f);
        endScene = true;
        PressText2.SetActive(true);

    }


}
