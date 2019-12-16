using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager3 : MonoBehaviour
{

    public Transform targetPosition; //목표점
    public DokFollow Dokkaebi;

    public CameraTrack cameraTrack; //카메라
    public Transform phase3; //현재 스크립트 부모
    public int index3 = 0; //순서
    public int index3Temp;
    public int count = 0;
    public PhaseManager4 nextPhase; // 다음 스크립트
    public GameObject trigger3;

    public MessageManager message;

    private bool once = false;
    private bool once2 = false;


    void Update()
    {

        Move(phase3);

    }

    void Move(Transform phase)
    {

        targetPosition = phase.GetChild(index3).transform;
        cameraTrack.Move(targetPosition);

        if (Vector3.Distance(cameraTrack.transform.position, targetPosition.position) < 0.1f)
        {
            while(true)
            {
                index3Temp = Random.Range(0, 3);
                if (index3 == index3Temp)
                {
                    continue;
                }
                else
                {
                    index3 = index3Temp;
                    count++;
                    break;
                }
            }
           
          
            
        }
        if (count == 7)
        {
            nextPhase.enabled = true;
            trigger3.SetActive(true);
            this.enabled = false;
            Dokkaebi.animator.SetTrigger("Dead");
            Dokkaebi.notMove = true;

        }
        if(count ==0 && once == false)
        {
            once = true;
            //message.Alert("뜨거운 화염이 생겼습니다.  .", 5);
            once = false;
        }
        if(count ==1 && once2 == false)
        {
            once2 = true;
            //message.Alert("임의 방향으로 이동합니다.", 5);
            once2 = false;

        }
        if (index3 == 0 && count !=0)
        {

        }
    }
}
