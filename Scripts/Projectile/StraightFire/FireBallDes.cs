using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDes : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.tag== "fire")
        {
            Destroy(other.gameObject);
        }
    }
   
}
