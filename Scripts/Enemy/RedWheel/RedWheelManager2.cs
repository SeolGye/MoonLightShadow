using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWheelManager2 : MonoBehaviour
{
    public Transform targetPosition;
    public RedWheelFollow redWheel;
    public Transform phase2;
    private int index = 0;




    // Update is called once per frame
    void Update()
    {
        Move(phase2);

    }
    void Start()
    {
        redWheel.redSpeed = 2.2f;
    }

    void Move(Transform phase)
    {


        targetPosition = phase.GetChild(index).transform;
        redWheel.Move(targetPosition);
        if (Vector3.Distance(redWheel.transform.position, targetPosition.position) < 0.1f)
        {
            if (index < phase.childCount - 1)
            {
                index++;
            }
            else if (index == phase.childCount - 1)
            {
                this.enabled = false;

            }
        }
        if (index == 10)
        {
            CameraTrack.instance.cameraSpeed = 1.7f;

        }
        if (index == 14)
        {
            CameraTrack.instance.cameraSpeed = 2.2f;
        }

    }
}
