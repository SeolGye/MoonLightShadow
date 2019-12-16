using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager7 : MonoBehaviour
{
    public Transform targetPosition;
    public CameraTrack cameraTrack;
    public Transform phase7;
    public int index7 = 0;
    private int count = 0;
    


    // Update is called once per frame
    void Update()
    {
        Move(phase7);
    }

    void Move(Transform phase)
    {

        cameraTrack.cameraSpeed = 2f;
        targetPosition = phase.GetChild(index7).transform;
        cameraTrack.Move(targetPosition);
        if (Vector3.Distance(cameraTrack.transform.position, targetPosition.position) < 0.1f)
        {
            if (index7 < phase.childCount - 1)
            {
                index7++;
            }
            else if (index7 == phase.childCount - 1)
            {
                index7 = 0;
               

            }

            //nextPhase.enabled = true;
            //this.enabled = false;
        }
    }
}
