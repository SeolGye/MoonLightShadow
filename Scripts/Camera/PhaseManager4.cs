using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager4 : MonoBehaviour
{
    public Transform targetPosition;
  

    public CameraTrack cameraTrack;
    public Transform phase4;
    public int index4 = 0;

    public FireGenerator[] fire = new FireGenerator[4]; // 불 구역

    public RedWheelManager3 nextRedPhase;
    public GameObject RedWheel;
    public GameObject StartPoint2;
    //레드휠 리스폰 지점
    public PhaseManager5 nextPhase;

    public MessageManager message;

    private bool once = false;


    void Start()
    {
        for(int i = 0; i <4; i++)
        {
            for(int j = 0; j <5; j++)
            {
                Destroy( fire[i].fires[j]);
                fire[i].enabled = false;

            }
        }
        // 불 구역 불 삭제
       
    }

    void Update()
    {
        Move(phase4);

    }



    void Move(Transform phase4)
    {

        targetPosition = phase4.GetChild(index4).transform;
        cameraTrack.Move(targetPosition);
        if (Vector3.Distance(cameraTrack.transform.position, targetPosition.position) < 0.1f)
        {
            if (index4 < phase4.childCount - 1)
            {
              
                index4++;
            }
            else if (index4 == phase4.childCount - 1)
            {

                nextPhase.enabled = true;
                RedWheel.SetActive(true);
                RedWheel.transform.position = StartPoint2.transform.position;
                nextRedPhase.enabled = true;
               
                //레드휠 스크립트 돌리기
                this.enabled = false;

            }
        }

        if(index4 ==0 && once == false)
        {
            once = true;
           // message.Alert("옥졸이 더 이상 쫓아오지 않습니다.", 5);
            once = false;

        }
    }

    
}
