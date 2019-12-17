using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger8 : MonoBehaviour
{
    public GameObject FireAsile;
    public FireBallManager2 fireBallManager2;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Milica")
        {
            FireAsile.SetActive(false);
            fireBallManager2.enabled = true;
            this.enabled = false;
        }
    }
}
