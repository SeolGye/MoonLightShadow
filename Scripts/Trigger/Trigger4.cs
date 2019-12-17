using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger4 : MonoBehaviour
{
    public FireBallManager1 fireBallManager1;
    public GameObject[] Pot = new GameObject[8];

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name =="Milica")
        {
            fireBallManager1.enabled = true ;
            this.enabled = false;

            for(int i = 0; i<Pot.Length; i++ )
            {
                Pot[i].SetActive(true);
            }
        }

    }
}
