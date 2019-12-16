using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DokFollow : MonoBehaviour
{

    public Transform target;
    public float speed;
    public float stoppingDistance;
    
    public  Animator animator;

    public GameObject projectile;
    private Transform player;
    public bool notMove = false;
    private bool once = true;

    private int bulletCount;

    public AudioClip throwAudioClip;
    public AudioClip[] moveAudioClip = new AudioClip[2];
    public AudioSource dockAudioSource;
    private int moveSoundNum;


    void Awake()
    {
        dockAudioSource = this.gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    void Update()
    {
        if(once&&!notMove)
        {
            once = false;
            StartCoroutine(MoveCoroutine());
        }
       
        
        

    }

    IEnumerator MoveCoroutine()
    {
        while(Vector2.Distance(transform.position, target.position) > stoppingDistance && !notMove)
        {
             if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
            {
                break;
            }
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetBool("Jump", true);
            MoveSound();
            yield return new WaitForSeconds(0.01f);
        }
        animator.SetBool("Jump", false);
        animator.SetBool("Attack", true);
        ThrowSound();
        yield return new WaitForSeconds(1f);


        Vector3 projectileDir = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
        Vector3 projectileMoveDir = projectileDir.normalized * 4f;
        GameObject tempProjectile =     Instantiate(projectile, transform.position, Quaternion.identity);
        tempProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDir.x, projectileMoveDir.y, 0);


        Vector3 projectileDir2 = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
        Vector3 projectileMoveDir2 = Quaternion.Euler(0,0,-20f)*projectileDir2.normalized * 4f;
        GameObject tempProjectile2 = Instantiate(projectile, transform.position, Quaternion.identity);
        tempProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDir2.x, projectileMoveDir2.y, 0);

        Vector3 projectileDir3 = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
        Vector3 projectileMoveDir3 = Quaternion.Euler(0, 0, 20f) * projectileDir3.normalized * 4f;
        GameObject tempProjectile3 = Instantiate(projectile, transform.position, Quaternion.identity);
        tempProjectile3.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDir3.x, projectileMoveDir3.y, 0);

        //불 던지기 3개 

        animator.SetBool("Attack", false);
        
        once = true;
    }

    public void ThrowSound()
    {
        if (!dockAudioSource.isPlaying)
        {
            dockAudioSource.Stop();
            dockAudioSource.clip = throwAudioClip;
            dockAudioSource.Play();
        }
    }

    public void MoveSound()
    {
        if (!dockAudioSource.isPlaying)
        {
            moveSoundNum = Random.Range(0, 2);
            dockAudioSource.Stop();
            dockAudioSource.clip = moveAudioClip[moveSoundNum];
            dockAudioSource.Play();
        }
    }

}
