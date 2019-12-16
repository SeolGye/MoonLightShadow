using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDead : MonoBehaviour
{
    public GameObject milicaAni;




    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            milicaAni = GameObject.FindWithTag("Player");
            StartCoroutine(FallCoroutine());

        }
    }

    IEnumerator FallCoroutine()
    {
        MilicaSound.instance.FallSound();

        milicaAni.GetComponent<Animation>().Play("Fall");
        MilicaMovement.instance.StopMove();
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
        GameManager.instance.OnPlayerFall();


    }



}
