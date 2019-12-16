using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager5 : MonoBehaviour
{

    public Transform targetPosition;
    public CameraTrack cameraTrack;
    public Transform phase5;
    public int index5 = 0;
    public PhaseManager6 nextPhase;
    public MessageManager message;


    private bool once = false;
    private bool once2 = false;
    private bool once3 = false;

    void Update()
    {
        Move(phase5);
    }

    void Move(Transform phase5)
    {
        targetPosition = phase5.GetChild(index5).transform;
        cameraTrack.Move(targetPosition);
        if (Vector3.Distance(cameraTrack.transform.position, targetPosition.position) < 0.1f)
        {
            if (index5 < phase5.childCount - 1)
            {
                index5++;
            }
            else if (index5 == phase5.childCount - 1)
            {
                nextPhase.enabled = true;
                this.enabled = false;

            }
        }

        if(index5 == 3 && once == false)
        {
            once = true;
            //message.Alert("화염이 쏟아지고 있습니다.", 4);
            once = false;

        }
        if(index5 == 5 && once2 == false)
        {
            once2 = true;
            //message.Alert("역방향으로 갑니다", 4);
            once2 = false;
        }
        if( index5 == 6 && once3 == false)
        {
            once3 = true;
            //message.Alert("전방에 화염이 옵니다", 4);
            once3 = false;
        }

    }
}
