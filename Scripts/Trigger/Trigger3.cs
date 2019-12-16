using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3 : MonoBehaviour
{
    
    public CameraTrack cam;
    public GameObject[] phases;
    public GameObject Bell;
    public GameObject Dove;
   
  



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Milica")
        {

            phases[0].SetActive(false);
            phases[1].SetActive(false);
            phases[2].SetActive(false);
            //이전 카메라 트렉 삭제
            Bell.SetActive(true);
            Dove.SetActive(false);


        }
    }
}
