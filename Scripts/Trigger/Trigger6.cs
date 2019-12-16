using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger6 : MonoBehaviour
{
    public GameObject FireDes;
    public GameObject NextPos;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Milica")
        {
            FireDes.transform.position = NextPos.transform.position;
            this.enabled = false;
        }
    }

}
