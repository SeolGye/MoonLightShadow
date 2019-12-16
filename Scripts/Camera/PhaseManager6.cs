using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager6 : MonoBehaviour
{
    public Transform targetPosition;
    public CameraTrack cameraTrack;
    public Transform phase6;
    public int index6 = 0;
    public PhaseManager7 nextPhase;

    public MessageManager message;


    private bool once = false;
    private bool once2 = false;

    void Update()
    {
        Move(phase6);
    }
    void Move(Transform phase)
    {
        cameraTrack.cameraSpeed = 2.5f;
        targetPosition = phase.GetChild(index6).transform;
        cameraTrack.Move(targetPosition);
        if (Vector3.Distance(cameraTrack.transform.position, targetPosition.position) < 0.1f)
        {
            if (index6 < phase.childCount - 1)
            {
                index6++;
            }
            else if (index6 == phase.childCount - 1)
            {
               nextPhase.enabled = true;
                this.enabled = false;

            }
        }
        if(index6 == 0 && once == false)
        {
            once = true;
            //message.Alert("끝임없이 움직이세요", 4);
            once = false;

        }

        if(index6 == 8 && once2 == false)
        {
            once2 = true;
           // message.Alert("구병시식을 시작합니다", 4);
           // message.Alert("10개를 시식하세요", 4);
            once2 = false;
        }



    }

}
