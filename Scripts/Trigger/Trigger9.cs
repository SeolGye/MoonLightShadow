using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger9 : MonoBehaviour
{
    public GameObject FireAsile;
    public FireBallManager2 fireBallManager2;
    public GameObject[] mapSprites;
    public GameObject Bell;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Milica")
        {
            FireAsile.SetActive(false);
            fireBallManager2.enabled = false;
            this.enabled = false;
            mapSprites[0].SetActive(false);
            mapSprites[1].SetActive(false);
            Bell.SetActive(false);

        }
    }
}
