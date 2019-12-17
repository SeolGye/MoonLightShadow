using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{

    public GameObject fire;

    private BoxCollider2D area;

    public int count;

    public List<GameObject> fires = new List<GameObject>();
    //맡은 구역에서 생성되는 불 리스트
    public Transform[] moveSpot = new Transform[5];
    //불의 이동 목표 지점


    public Vector3 size;
    public Vector3 basePosition;
    



    private float waitTime;
    public float startWaitTime;
    //리스폰 시간

    private float movX;
    private float movY;
    private float movZ;

    private FireMovement fireComponent;
    //각 불의 움직이는 기능 




    void Start()
    {
        waitTime = startWaitTime;

        area = GetComponent<BoxCollider2D>();
        // 각 구역 박스 콜라이더 불러오기
        size = area.size;
        // 각 구역 박스 콜라이더 사이즈
        basePosition = transform.position;
        // 각 구역 위치를 기준으로 지정
        for (int i = 0; i < count; i++)
        {
            Spawn();
            //원하는 수 만큼  불을 생성
        }

        for (int i = 0; i < moveSpot.Length; i++) // 이동 지점 수만큼 반복한다. 
        {
            float movX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
            float movY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
            float movZ = 0f;
            moveSpot[i].position = new Vector3(movX, movY, movZ);
            // 이동 지점 위치를 랜덤으로 생성하고 설정한다.
        }



    }

    private void Spawn()
    {


        Vector3 spawnPos = GetRandomPosition();
        GameObject instance = Instantiate(fire, spawnPos, Quaternion.identity);
        fires.Add(instance);

    }

    private Vector3 GetRandomPosition()
    {

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = 0f;
        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }



    void Update()
    {

        for (int i = 0; i < fires.Count; i++)
        {
            fireComponent = fires[i].GetComponent<FireMovement>();
            fireComponent.Move(moveSpot[i].position);
            if (Vector3.Distance(fires[i].transform.position, moveSpot[i].position) < 0.1f)
            {
                if (waitTime <= 0)
                {
                    float movX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
                    float movY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
                    float movZ = 0f;
                    moveSpot[i].position = new Vector3(movX, movY, movZ);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }

            }
        }


    }
}
