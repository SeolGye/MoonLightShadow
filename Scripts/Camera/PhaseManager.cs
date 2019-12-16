using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public Transform targetPosition;
    public MessageManager message;

    public Transform phase1;
    public int index=0;
    private bool once = false;
    private bool once2 = false;


    public PhaseManager2 nextPhase;



    void Update()
    {
        Move(phase1);

    }
   


    void Move(Transform phase)
    {

            targetPosition = phase.GetChild(index).transform;
            CameraTrack.instance.Move(targetPosition);
            if (Vector3.Distance(CameraTrack.instance.transform.position, targetPosition.position) < 0.1f)
            {
                if(index<phase.childCount-1)
                {
                    index++;
                }
                else if(index==phase.childCount-1)
                {
                nextPhase.enabled = true;
               this.enabled = false;
               // cameraTrack.cameraSpeed = 3f;

                }
            }


        if (index == 6 && once == false)
        {
            once = true;
            //cameraTrack.cameraSpeed = 2.5f;
           // message.Alert("좁은 길을 조심하세요.", 5);
            once = false;
            CameraTrack.instance.cameraSpeed = 2.2f;
        }
            if(index == 1&& once2 == false)
        {
            once2 = true;
           // message.Alert("악귀가 쫓아 옵니다",5);
            once2 = false;
        }
         



    }
}

