using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{

    public Trigger2 trigger2;
    public CameraTrack cam;




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Milica") 
        {
            trigger2.enabled = true;
            this.enabled = false;
        }
    }
  

}