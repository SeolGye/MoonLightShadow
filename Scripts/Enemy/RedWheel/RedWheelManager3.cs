using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWheelManager3 : MonoBehaviour
{
    public Transform targetPosition;
    public RedWheelFollow redWheel;
    public Transform phase3;
    private int index = 0;



    
    void Update()
    {
        Move(phase3);

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


        if(index == 0)
        {
            redWheel.redSpeed = 2.5f;

        }
        if (index == 2)
        {
            redWheel.redSpeed = 3f;

        }
        if (index == 3 || index == 5)
        {
            redWheel.redSpeed = 1f;
        }
        if(index == 4 || index == 6)
        {
            redWheel.redSpeed = 1.5f;
        }



    }
}
