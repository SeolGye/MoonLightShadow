using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    private GameObject Canvas;
    private GameObject Cha; //캐릭터
    private GameObject Outline; //바깥
    private GameObject Title; // 타이틀
    private GameObject ContentsText; // 글
    private GameObject Frame;
    public GameObject Click;
    public GameObject Hand;
    private GameObject Skip;

    public GameObject FadeOut;
    public GameObject FadeIn;

    private Text contentExp;

    public int Count;
    public bool once;
    public bool talking;
    public bool repeat;

    [TextArea]
    public string[] sentence;
    public string[] ChaAni;
    public string[] FrameAni;



    void Awake()
    {
        Application.targetFrameRate = 30;
        Count = 0;

    }

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Cha = Canvas.transform.Find("Cha").gameObject;
        Outline = Canvas.transform.Find("BackUI").gameObject;
        Title = Canvas.transform.Find("Title").gameObject;
        ContentsText = Canvas.transform.Find("ConExp").gameObject;
        Frame = Canvas.transform.Find("Cut1").gameObject;
        contentExp = ContentsText.GetComponent<Text>();
        Skip = Canvas.transform.Find("Skip").gameObject;
        FadeIn = Canvas.transform.Find("FadeIn").gameObject;
        FadeOut = Canvas.transform.Find("FadeOut").gameObject;
     
        //Canvas.transform.Find("BackUI").gameObject.GetComponent<Animator>().SetTrigger("Into2");
        contentExp.text = "";

        once = true;
        repeat = true;
        StartCoroutine(FadeInCoroutine());

        StartCoroutine(TutorialCoroutine());

    }



    void Update()
    {
        if (once)
        {


            if (Input.GetMouseButtonDown(0) && talking)
            {
                Debug.Log("실행");
                talking = false;
                contentExp.text = "";
                Count++;
                Skip.SetActive(false);


                if (Count == sentence.Length)
                {
                    Count = 0;
                    SceneManager.LoadScene(10);


                }
                else if (talking == false)
                {
                    StartCoroutine(TutorialCoroutine());
                }



                // Canvas.transform.Find("Cut1").gameObject.GetComponent<Animator>().SetTrigger("Into2");
                //TestCha.GetComponent<Animator>().SetTrigger("Into2");




            }
        }

    }



    IEnumerator TutorialCoroutine()
    {


        if (Count == 4)
        {

            Cha.GetComponent<Animator>().SetTrigger("Into2");
            yield return new WaitForSeconds(3f);
            Cha.GetComponent<Animator>().SetTrigger("IntoIdleO"); //캐릭터 아이들
            talking = true;
            Skip.SetActive(true);

        }


        if (Count == 7)
        {
            Canvas.transform.Find("Cut1").gameObject.GetComponent<Animator>().SetTrigger("Into1");
            yield return new WaitForSeconds(1f);
            contentExp.text = sentence[Count];
            yield return new WaitForSeconds(2f);
            talking = true;
            Skip.SetActive(true);

        }
        else if (Count == 8)
        {
            Canvas.transform.Find("Cut1").gameObject.GetComponent<Animator>().SetTrigger("Into2");
            yield return new WaitForSeconds(1f);
            contentExp.text = sentence[Count];
            yield return new WaitForSeconds(2f);
            talking = true;
            Skip.SetActive(true);

        }

        else if (Count == 10)
        {
            Canvas.transform.Find("Cut1").gameObject.GetComponent<Animator>().SetTrigger("Into3");
            yield return new WaitForSeconds(1f);
            contentExp.text = sentence[Count];
            yield return new WaitForSeconds(2f);
            talking = true;
            Skip.SetActive(true);

        }
        else if (Count == 11)
        {
            Cha.GetComponent<Animator>().SetTrigger("Into3");
            yield return new WaitForSeconds(1f);
            contentExp.text = sentence[Count];
            yield return new WaitForSeconds(2f);
            talking = true;
            Skip.SetActive(true);

        }
        else if (Count == 13)
        {
            Debug.Log("13번째");
            talking = false;

            Frame.GetComponent<Animator>().SetTrigger("Into4"); // 틀 효과 정지
            Debug.Log("틀 효과 정지");
            yield return new WaitForSeconds(1f);
            Debug.Log("1초");
            contentExp.text = sentence[Count]; // 설명
            Debug.Log("설명");

            yield return new WaitForSeconds(2f);
            Debug.Log("2초");
            Hand.SetActive(true);// 손 등장
            Debug.Log("손 등장");
            yield return new WaitForSeconds(1f);
            Debug.Log("1초 2");
            Hand.GetComponent<Animator>().SetTrigger("IntoClick"); //손 클릭
            Debug.Log("손 클릭");
            yield return new WaitForSeconds(1f);
            Debug.Log("1초 3");
            Click.SetActive(true); // 클릭 효과 등장
            Debug.Log("클릭 효과");
            Hand.GetComponent<Animator>().SetTrigger("IntoDisa"); // 손 사라짐
            Debug.Log("손 사라짐");
            yield return new WaitForSeconds(1f);
            Debug.Log("1초 4");
            Cha.GetComponent<Animator>().SetTrigger("Into4"); //캐릭터 뜀
            Debug.Log("캐릭터 뜀");
            yield return new WaitForSeconds(2f);
            Debug.Log("3초 ");
            Click.SetActive(false);
            Debug.Log("클릭효과 삭제");


            Cha.GetComponent<Animator>().SetTrigger("IntoIdle"); //캐릭터 아이들
            Debug.Log("캐릭터 아이들");
            yield return new WaitForSeconds(1f);
            Debug.Log("1초 5");
            talking = true;
            Debug.Log("넘기기가능");
            Skip.SetActive(true);
        }

        else if (Count == 14)
        {
            Debug.Log("14번째");
            contentExp.text = sentence[Count];
            //contentExp.text = sentence[Count];
            yield return new WaitForSeconds(2f);
            talking = true;
            Skip.SetActive(true);
        }
        else if (Count == 19)
        {

            yield return StartCoroutine(FadeOutCoroutine());

        }
        else
        {
            contentExp.text = sentence[Count];
            //contentExp.text = sentence[Count];
            yield return new WaitForSeconds(1f);
            talking = true;
            Skip.SetActive(true);

        }

    }

    IEnumerator FadeInCoroutine()
    {
        yield return new WaitForSeconds(2f);
        FadeIn.SetActive(false);
        talking = true;


    }


    IEnumerator FadeOutCoroutine()
    {
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(10);
    }
}
