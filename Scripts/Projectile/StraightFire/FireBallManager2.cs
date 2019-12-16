using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallManager2 : MonoBehaviour
{
    public GameObject fire;
    public Transform StaPoint;
    public Transform DesiPoint;
    public Transform CameraPosi;
    private StraightFireMovement fireComponent;



    void Start()
    {

        StartCoroutine(MakeCoroutine());

    }

    void Update()
    {
        if(transform.position.y <CameraPosi.position.y )
        {
            transform.position = Vector3.MoveTowards(transform.position, CameraPosi.position, 3f);

        }
    }


    IEnumerator MakeCoroutine()
    {
        while (true)
        {

            for (int i = 0; i < 5; i += 2)
            {
                GameObject instance = Instantiate(fire, StaPoint.GetChild(i).transform.position, Quaternion.Euler(0, 0, 90f));
                fireComponent = instance.GetComponent<StraightFireMovement>();
                fireComponent.SetPos(DesiPoint.GetChild(i).transform.position);
            }
            //짝수 불 날리기



            if (Vector3.Distance(transform.position, CameraPosi.position) < 0.1f)
            {
                yield return new WaitForSeconds(0.4f);

            }
            else
            {
                yield return new WaitForSeconds(0.7f);

            }


            for (int i = 1; i < 5; i += 2)
            {
                GameObject instance = Instantiate(fire, StaPoint.GetChild(i).transform.position, Quaternion.Euler(0, 0, 90f));
                fireComponent = instance.GetComponent<StraightFireMovement>();
                fireComponent.SetPos(DesiPoint.GetChild(i).transform.position);
            }


            if (Vector3.Distance(transform.position, CameraPosi.position) < 0.1f)
            {
                yield return new WaitForSeconds(0.4f);

            }
            else
            {
                yield return new WaitForSeconds(0.7f);

            }
        }

    }
}
