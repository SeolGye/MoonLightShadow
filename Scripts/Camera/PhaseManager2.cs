using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager2 : MonoBehaviour
{
    public Transform targetPosition;


    public Transform phase2;
    public int index2 = 0;
    

    public PhaseManager3 nextPhase;
    void Start()
    {
        CameraTrack.instance.cameraSpeed = 2.5f;


    }

    void Update()
    {
        Move(phase2);

    }



    void Move(Transform phase)
    {

        targetPosition = phase.GetChild(index2).transform;
        CameraTrack.instance.Move(targetPosition);
        if (Vector3.Distance(CameraTrack.instance.transform.position, targetPosition.position) < 0.1f)
        {
            if (index2 < phase.childCount - 1)
            {
                index2++;
            }
            else if (index2 == phase.childCount - 1)
            {
                nextPhase.enabled = true;
                this.enabled = false;

            }
        }
        if(index2== 10)
        {
            CameraTrack.instance.cameraSpeed = 2f;

        }

        if (index2 == 13)
        {
            CameraTrack.instance.cameraSpeed = 2.5f;
        }
        


    }
}
