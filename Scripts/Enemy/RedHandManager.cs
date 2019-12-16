using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHandManager : MonoBehaviour
{

    private int handNum;
    public GameObject redHand;
    private float movX;
    private float movY;
    private float movZ;
    private Vector3 redPosition;
    private Vector3 basePosition;
    public List<GameObject> redHands = new List<GameObject>();
    private bool once ;


    void Start()
    {
        once = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name   == "Milica" && once == true)
        {
            once = false;
            basePosition = other.transform.position;
            StartCoroutine(SpawnCoroutine());
        }
    }

    IEnumerator SpawnCoroutine()
    {
            handNum = Random.Range(1, 4);

            for (int i = 0; i < handNum; i++)
            {
                movX = basePosition.x + Random.Range(-3.0f, 3.0f);
                movY = basePosition.y + Random.Range(-3.0f, 3.0f);
                movZ = 0;
                redPosition = new Vector3(movX, movY, movZ);

                GameObject instance = Instantiate(redHand, redPosition, Quaternion.identity);
                redHands.Add(instance);
            }
            yield return new WaitForSeconds(2.5f);

        for (int i = 0; i<handNum; i ++)
        {
            Destroy(redHands[i].gameObject); 
        }
        redHands.Clear();

            once = true;
       
    }
}
