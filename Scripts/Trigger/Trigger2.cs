using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    public GameObject Dok;
    public GameObject RedWheel;
    public FireGenerator area1;
    public FireGenerator area2;
    public FireGenerator area3;
    public FireGenerator area4;
    public GameObject Collider;
    public GameObject Deco1;






    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name =="Milica")
        {

            Dok.SetActive(true);
            area1.enabled = true;
            area2.enabled = true;
            area3.enabled = true;
            area4.enabled = true;
            Collider.SetActive(false);
            this.enabled = false;
            RedWheel.SetActive(false);
            Deco1.SetActive(false);


        }
    }
}
