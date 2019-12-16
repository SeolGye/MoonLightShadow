using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallManager1 : MonoBehaviour
{
    public GameObject fire;
    public Transform StaPoint;
    public Transform DesiPoint;
    private StraightFireMovement fireComponent;



    void Start()
    {

            StartCoroutine(MakeCoroutine());
        
    }


        IEnumerator MakeCoroutine()
    {
        while (true)
        {

            for (int i = 0; i < 6; i += 2)
            {
                GameObject instance = Instantiate(fire, StaPoint.GetChild(i).transform.position, Quaternion.Euler(0,0,90f));
                fireComponent = instance.GetComponent<StraightFireMovement>();
                fireComponent.SetPos(DesiPoint.GetChild(i).transform.position);
            }
            //짝수 불 날리기

            yield return new WaitForSeconds(0.5f);


            for (int i = 1; i < 6; i += 2)
            {
                GameObject instance = Instantiate(fire, StaPoint.GetChild(i).transform.position, Quaternion.Euler(0, 0, 90f));
                fireComponent = instance.GetComponent<StraightFireMovement>();
                fireComponent.SetPos(DesiPoint.GetChild(i).transform.position);
            }

            yield return new WaitForSeconds(0.5f);
        }

        }
    }



