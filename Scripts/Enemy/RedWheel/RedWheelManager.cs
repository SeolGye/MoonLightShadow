using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWheelManager : MonoBehaviour
{

    public Transform targetPosition;
    public RedWheelFollow redWheel;
    public Transform phase1;
    private int index = 0;

    public RedWheelManager2 nextPhase;


    void Start()
    {
        redWheel.redSpeed = 3f;

    }

    // Update is called once per frame
    void Update()
    {
        Move(phase1);

    }


    void Move(Transform phase)
    {

        if (index ==2 )
        {
            redWheel.redSpeed = 2.5f;
        }

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
                nextPhase.enabled = true;
                this.enabled = false;

            }
        }

        if(index == 6)
        {
            redWheel.redSpeed = 2.2f;
        }


    }
}
