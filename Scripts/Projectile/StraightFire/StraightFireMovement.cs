using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFireMovement : MonoBehaviour
{

    public float speed;
    public Vector2 target;

    void Update()
    {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void SetPos(Vector2 startSpot)
    {
        target= startSpot;
    }

}
