using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAct : MonoBehaviour
{
    private Animator animator; // 보스 애니메이터 
    public GameObject Boss; //보스
    public GameObject Playertarget;
    public int rand; // 공격 순서
    private int spinesNum; // 가시 갯수
    public GameObject spine; //가시
    private float movX;
    private float movY;
    private float movZ;
    private Vector3 spinePosition; // 생성 위치
    private Vector3 basePosition; // 기본 위치
    private List<GameObject> spines= new List<GameObject>();
    private List<GameObject> bullets = new List<GameObject>();
    private bool once;
    public GameObject Bullet;
    private int numberBullet;
    public bool canMove;
    public CameraTrack camera;
    public AudioClip[] IdleClip = new AudioClip[3];
    public AudioSource myAudio;
    public int AudioNum;


    public bool TriggerEnter;
    private bool One = false;

    void Start()
    {
        animator = Boss.GetComponent<Animator>();
        canMove = true;
        myAudio = Boss.gameObject.GetComponent<AudioSource>();
        TriggerEnter = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Milica"  && TriggerEnter == true)
        {

            Debug.Log("충돌");
            TriggerEnter = false;
            once = true;
            One = true;
            StartCoroutine(AttackCoroutine());

        }
    }


    IEnumerator AttackCoroutine()
    {
        if (canMove)
        {

          

            while (once)
            {
                if (One)
                {

                    One = false;
                    basePosition = Playertarget.transform.position;
                    IdleSound();
                    rand = Random.Range(0, 4);
                    if (rand == 0) // 오른손
                    {
                        yield return StartCoroutine(RightHandAttack());

                    }
                    else if (rand == 1) //왼손
                    {
                        yield return StartCoroutine(LeftHandAttack());

                    }
                    else if (rand == 2) //양손
                    {
                        yield return StartCoroutine(DoubleHandAttack());

                    }
                    else if (rand == 3)// 숨 불기
                    {
                        numberBullet = Random.Range(10, 15);
                        yield return StartCoroutine(SpawnProjectile(numberBullet));
                        yield return new WaitForSeconds(1f);

                        numberBullet = Random.Range(10, 15);
                        yield return StartCoroutine(SpawnProjectile(numberBullet));
                        yield return new WaitForSeconds(0.5f);

                    }
                    One = true;
                }
            }
        }
    }


    IEnumerator RightHandAttack()
    {
        spinesNum = 12;
        animator.SetBool("BossRight", true);
        yield return new WaitForSeconds(0.5f);
        camera.ShakeCamera(0.3f, 1f);

        animator.SetBool("BossRight", false);

        for (int i = 0; i < spinesNum; i++)
        {
            movX = basePosition.x + (-6f+i);
            movY = basePosition.y;
            movZ = 0f;
            spinePosition = new Vector3(movX, movY, movZ);
            GameObject instance = Instantiate(spine, spinePosition, Quaternion.identity);
            yield return new WaitForSeconds(0.05f); // 가시 간격

        }
        
        yield return new WaitForSeconds(2f);
    }

    IEnumerator LeftHandAttack()
    {
        spinesNum = 12;
        animator.SetBool("BossLeft", true);
        yield return new WaitForSeconds(0.5f);
        camera.ShakeCamera(0.3f, 1f);

        animator.SetBool("BossLeft", false);

        for (int i = 0; i < spinesNum; i++)
        {
            movX = basePosition.x;
            movY = basePosition.y + (-6f+i);
            movZ = 0f;
            spinePosition = new Vector3(movX, movY, movZ);
            GameObject instance = Instantiate(spine, spinePosition, Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return new WaitForSeconds(2f);
    }

    IEnumerator DoubleHandAttack()
    {
        spinesNum = Random.Range(3,5);
        animator.SetBool("BossDouble", true);
        yield return new WaitForSeconds(0.5f);
        camera.ShakeCamera(0.3f, 1f);

        animator.SetBool("BossDouble", false);

        for (int i = 0; i < spinesNum; i++)
        {
            movX = basePosition.x + Random.Range(-3.0f, 3.0f); 
            movY = basePosition.y + Random.Range(-3.0f, 3.0f);
            movZ = 0f;
            spinePosition = new Vector3(movX, movY, movZ);
            GameObject instance = Instantiate(spine, spinePosition, Quaternion.identity);
        }
       
        yield return new WaitForSeconds(2f);
    }






    IEnumerator SpawnProjectile(int projectileNumber)
    {
        float angleStep = 360f / projectileNumber;
        float angle = 0f;

        animator.SetBool("BossBulletAttack", true);
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("BossBulletAttack", false);



        for (int i = 0; i < projectileNumber; i++)
        {
            float projectileDirXPosition = Boss.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * 1f;
            float projectileDirYPosition = Boss.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * 1f;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - Boss.transform.position).normalized * 4f;

            GameObject tempBullet = Instantiate(Bullet, Boss.transform.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y,0);
            angle += angleStep;
        }

    }

    public void IdleSound()
    {
        AudioNum = Random.Range(0, 3);
        myAudio.clip = IdleClip[AudioNum];
        myAudio.Play();
    }
}
