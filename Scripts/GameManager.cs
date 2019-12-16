using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance; //게임 매니저는 오직 한 개만
    public GameObject Ready;
    public GameObject CountDown;
    public GameObject StartMe; 

    public GameObject Score;
    public GameObject BestScore;

    public Text messageText; //시작 메세지
    public Text countText;
    public Text startText;

    public Text currentScore; //점수 메세지
    public Text currentBestScore;

    public int score; //점수 값
    public int bestScore; //최고 점수 값
    public bool isRoundActive= false; //라운드 시작 판별 

    public  CameraTrack cameraTrack; //카메라 스크립트
    public RedWheelFollow redWheel;

    public MilicaMovement milicaMovement; // 플레이어 움직임 스크립트
    public GameObject milicaObject; // 플레이어 게임오브젝트
    public Transform startPoint; //스타트 포인트
    public Transform startPoint2;
    public Transform phase1; //첫 페이즈
    public Transform startShot;


    public GameObject RoundReadyPannel; // 레디 패널 게임 오브젝트
    public GameObject DeadPanel;
    public PhaseManager phaseManager; // 첫 페이즈 스크립트
    public RedWheelManager redWheelManager;
    public GameObject HealthUI;
    public GameObject HealthUI2;
    public GameObject HealthBar;

    public GameObject Canvas1;
    public GameObject Canvas2;


    private int endingNum;

   
    public void AddScore(int newScore) //점수 증가
    {
        score += newScore;
        UpdateBestScore();
        UpdateUI();
    }

    public void UpdateBestScore()
    {
        if(GetBestScore()< score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }

    int GetBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        return bestScore;
    }
    void Awake()
    {
        Application.targetFrameRate = 30;

    }
    void Start()
    {
        GameManager.instance = this;
       /*if (instance == null)
        {

            DontDestroyOnLoad(this.gameObject); //이동해도 삭제하지 않는다
            
            instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
       */

        UpdateUI(); 
        StartCoroutine("RoundRoutine"); //첫 게임 시작할 때 코루틴 발동


    }

   /* void Update()
    {
        if (Application.platform == RuntimePlatform.Android)// 안드로이드 기기 확인

        {

            if (Input.GetKey(KeyCode.Escape) || Input.GetMouseButtonDown(0)) //뒤로가기 버튼을 누르면

            {
                Time.timeScale = 0; // 일시정지가 되고
                Canvas2.transform.FindChild("StopPanel").gameObject.SetActive(true); //스탑 패널 찾아서 킨다. 그러면 아이들 상태이기에 창이 떠오른다
                // Application.Quit();

            }

        }
       
    }
    */

    void UpdateUI()
    {
        currentScore.text = "" + score;
        currentBestScore.text = "" +  GetBestScore();


    } //점수 메세지 업데이트

    public void OnPlayerDestroy()
    {
        UpdateUI();
        endingNum = 0;
        isRoundActive = false;
    } //캐릭터 죽으면

    public void OnPlayerFall()
    {
        UpdateUI();
        endingNum = 1;
        isRoundActive = false;
    }
    //떨어질 때
    public void Reset()
    {
        Instantiate(milicaObject, startPoint.transform.position, transform.rotation);

        score = 0;
        UpdateUI();
        StartCoroutine("RoundRoutine");
    } // 다시 시작



    public void LoadMainMenuFun()
    {
        StartCoroutine(LoadMainMenu());
    }

    public void LoadBackFun()
    {
        StartCoroutine(LoadBack());
    }

    IEnumerator LoadMainMenu()
    {
        Canvas2.transform.Find("FadeAction").gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Canvas2.transform.Find("FadeAction").gameObject.SetActive(false);
        Canvas2.transform.Find("StopPanel").gameObject.SetActive(false); //스탑 패널 찾아서 킨다. 그러면 아이들 상태이기에 창이 떠오른다
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

        //종료 버튼을 누르면  캔버스2 페이드액션 오브젝트를 찾아 페이드아웃이된다
        //시간을 준다
        //다시 원상태로 페이드아웃을 꺼놓는다
        //스탑패널도 꺼서 원상태로 만든다
        //메인메뉴로 돌아간다
    }
    IEnumerator LoadBack()
    {
        Canvas2.transform.Find("StopPanel").gameObject.GetComponent<Animator>().SetTrigger("Disappear");
        yield return new WaitForSeconds(1f);
        Canvas2.transform.Find("StopPanel").gameObject.SetActive(false); //스탑 패널 찾아서 킨다. 그러면 아이들 상태이기에 창이 떠오른다
        Time.timeScale = 1; 
        //취소를 누르면 스탑패널에서 애니메이터에 있는 트리거를 실행시켜서 투명하게 바꾼다
        //투명해지는데 시간을준다
        //다시 스탑패널을 꺼서 원상태로 바꾼다
        //다시 플레이한다


    }

    IEnumerator RoundRoutine()
    {
        phaseManager.enabled = false; // 첫 페이즈 스크립트 끄기
        cameraTrack.SetTarget(startShot.transform); // 첫 페이즈로 카메라 위치 잡기
        milicaMovement.enabled = false; //캐릭터 움직이는 스크립트 끄기
        milicaObject.SetActive(true); // 캐릭터 게임오브젝트 끄기
        isRoundActive = false;//라운드 시작 ㄴㄴ
        redWheelManager.enabled = false;

        //yield return new WaitForSeconds(5f);
        //Canvas1.SetActive(false);
        Canvas2.SetActive(true);

        RoundReadyPannel.SetActive(true); //레디 패널 켜기
        redWheel.SetTarget(startPoint2.transform);




        yield return new WaitForSeconds(1f);
        
        yield return new WaitForSeconds(0.5f);
        while (Vector3.Distance(cameraTrack.transform.position, phase1.GetChild(0).transform.position) > 0.1f)
        {
            cameraTrack.transform.position = Vector3.Lerp(cameraTrack.transform.position, phase1.GetChild(0).transform.position, Time.deltaTime * 2f);

            //cameraTrack.Move(phase1.GetChild(0).transform);
            yield return new WaitForSeconds(0.01f);
            if (Vector3.Distance(cameraTrack.transform.position, phase1.GetChild(0).transform.position) < 0.1f)
            {
                break;
            }
        }
        



        //Ready 상태
        // phaseManager2.enabled = false;

       
        

        /*yield return new WaitForSeconds(0.5f);
        Ready.SetActive(true);
        messageText.text = "준비";
        yield return new WaitForSeconds(1f);
        Ready.SetActive(false);
        */
        CountDown.SetActive(true);
        countText.text = "3";
        yield return new WaitForSeconds(1f);
        CountDown.SetActive(false);

        CountDown.SetActive(true);
        countText.text = "2";
        yield return new WaitForSeconds(1f);
        CountDown.SetActive(false);

        CountDown.SetActive(true);
        countText.text = "1";
        yield return new WaitForSeconds(1f);
        CountDown.SetActive(false);
        

        StartMe.SetActive(true);
        startText.text = "시작";
        yield return new WaitForSeconds(1f);
        StartMe.SetActive(false);

        //HealthUI.SetActive(true);
        CountDown.SetActive(false);
        HealthBar.SetActive(true);
        isRoundActive = true; //라운드 시작
        Score.SetActive(true);
        BestScore.SetActive(true);
        RoundReadyPannel.SetActive(false); //패널 끄기



        //Play
        milicaMovement.transform.position = startPoint.transform.position;

        milicaObject.SetActive(true); //캐릭터 오브젝트 키기

        milicaMovement.enabled = true; //캐릭터 움직임 스크립트 키기


        //yield return new WaitForSeconds(0.5f);

        redWheelManager.enabled = true;
        phaseManager.enabled = true; // 첫 페이즈 스크립트 시작
        //HealthUI2.SetActive(true);

        while (isRoundActive==true)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        DeadPanel.SetActive(true);
        yield return new WaitForSeconds(1f);



        if(endingNum ==0) //죽을 때
        {
            SceneManager.LoadScene(7);

        }
        if(endingNum == 1) // 떨어질 때
        {
            SceneManager.LoadScene(8);

        }
        //End




    }
}
