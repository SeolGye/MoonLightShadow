using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger7 : MonoBehaviour
{
    public GameObject FireAsile;
    public FireBallManager1 fireBallManager1;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Milica")
        {
            FireAsile.SetActive(false);
            fireBallManager1.enabled = true;
            this.enabled = false;
        }
    }
}
