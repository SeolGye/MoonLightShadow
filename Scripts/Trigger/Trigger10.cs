using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger10 : MonoBehaviour
{
    public GameObject FireAile4;
    public GameObject bosal;
    public GameObject[] Pot = new GameObject[8];


 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Milica")
        {
            FireAile4.SetActive(false);
            bosal.SetActive(true);

            for(int i = 0;i <Pot.Length; i++)
            {
                Pot[i].SetActive(false);
            }
           
        }
    }
}
