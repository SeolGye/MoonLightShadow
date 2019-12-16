using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{

    public float speed;

    public void Move(Vector3 moveSpot)
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
    }


  
}
