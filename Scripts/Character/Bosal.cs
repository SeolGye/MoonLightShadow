using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosal : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float stoppingDistance;
    private float difference;
    public Animator animator;
    private int projectileNumber;

    public GameObject projectile;
    private Transform player;
    public bool notMove = false;
    private bool once = true;

    private List<GameObject> bullets = new List<GameObject>();
    private Vector3 standardDirection;
    private Vector3 v3Direction;


    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (once && !notMove)
        {
            once = false;
            StartCoroutine(ShotCoroutine());
        }
    }

    IEnumerator ShotCoroutine()
    {

        projectileNumber = Random.Range(10,15);
        float angleStep = 360f / projectileNumber;
        float angle = 0f;


        while (Vector2.Distance(transform.position, target.position) > stoppingDistance && !notMove)
        {
            if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
            {
                break;
            }
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            difference = target.position.x - transform.position.x;
            animator.SetFloat("Direction", difference);


            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);

      

        for (int i = 0; i < projectileNumber; i++)
        {
            

            float projectileDirXPosition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * 1f;
            float projectileDirYPosition = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * 1f;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - transform.position).normalized * 7f;

            GameObject tempBullet = Instantiate(projectile, transform.position, Quaternion.identity);


            tempBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0);

            bullets.Add(tempBullet);
            angle += angleStep;
            yield return new WaitForSeconds(0.05f);

        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < projectileNumber; i++)
        {
            Destroy(bullets[i].gameObject);
        }
        bullets.Clear();
        once = true;

    }
}
