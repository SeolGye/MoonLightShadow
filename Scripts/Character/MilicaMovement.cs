using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilicaMovement : MonoBehaviour
{
    public static MilicaMovement instance;
    public Animator animator;
    public float speed;
    public bool notMove = false;

    private bool damaged = false;
    private float nextTime = 0f;
    private float TimeLeft = 1f;
    public bool isMoving = true;

    Camera camera;
   public  Vector3 MousePosition;
    public Vector3 KnockBackPosition;
    Vector3 Direction;


    void Awake()
   {

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        MilicaMovement.instance = this;
    /*   if (instance == null)
       {
           DontDestroyOnLoad(this.gameObject); //이동해도 삭제하지 않는다

           instance = this;
       }
       else
       {
           Destroy(this.gameObject);
       }
      */
} // 실행할 때 캐릭터 중복 금지 기능  



    void OnEnable()
    {
        animator = GetComponent<Animator>();
    }
    
    public void StopMove()
    {
        notMove = true;
    }

    public void CanMove()
    {
        notMove = false;
    }

    void Update()
    {
        
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft;
                GameManager.instance.AddScore(1);
            }
        
    
   
        if (!notMove && Input.GetMouseButton(0) ) //누르고 있고 움직일 수 있을 때
        {
            isMoving= true;
            MousePosition = Input.mousePosition;
            MousePosition = camera.ScreenToWorldPoint(MousePosition);
            MousePosition.z = 0;

            Direction = new Vector3(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y, 0);

          

            /*  joystickHor = joystick.Horizontal;
              joystickVer = joystick.Vertical;
              animator.SetFloat("Horizontal", joystick.Horizontal);
                  animator.SetFloat("Vertical", joystick.Vertical);
                  animator.SetBool("Walking", true);
                  transform.Translate(new Vector3(joystick.Horizontal* speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime,0f));
              */

        }
        if(Direction.x!=0 || Direction.y!=0)
        {
        }
        


        if (isMoving && Vector3.Distance(transform.position, MousePosition) > 0.1f)
        {
            Move(MousePosition);
            animator.SetFloat("Horizontal", Direction.x);
            animator.SetFloat("Vertical", Direction.y);
            animator.SetBool("Walking", true);
            StepSound.instance.StartStepSound();

        }
        if (!isMoving)
        {
            animator.SetBool("Walking", false); //걷고 있지 않다는 변수 애니메이터에 전달
            StepSound.instance.StopStepSound();
            Move(KnockBackPosition);
            
        }

        if (Vector3.Distance(transform.position, MousePosition) < 0.1f || Vector3.Distance(transform.position, KnockBackPosition) < 0.1f)
        {
            animator.SetBool("Walking", false);
            StepSound.instance.StopStepSound();
        }



    }

    public void Move(Vector3 DesPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, DesPosition, speed * Time.deltaTime);
        //transform.Translate(new Vector3(Direction.x * speed * Time.deltaTime, Direction.y* speed * Time.deltaTime, 0f));
        //transform.position = Vector3.MoveTowards(transform.position, DesPosition, speed * Time.deltaTime);
    }

    public void SetMousePosition(Vector3 mousePosition)
    {
        KnockBackPosition = mousePosition;
    }    

}
