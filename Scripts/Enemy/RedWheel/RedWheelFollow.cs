using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWheelFollow : MonoBehaviour
{



    public float redSpeed;
    public float smoothTime = 1f;
    private Vector3 lastMovingVelocity;
    private float lastZoomSpeed;
    public AudioSource[] explosionSound = new AudioSource[8];
    public AudioClip[] explosionSoundClip = new AudioClip[8];
    private bool once = false;



    public void SetTarget(Transform newTarget)
    {
        transform.position = newTarget.position;
        

    } //카메라 위치 잡기

    public void Move(Transform targetPoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, redSpeed * Time.deltaTime);
        //Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPoint.position, ref lastMovingVelocity, smoothTime);
        //transform.position = smoothPosition;
        //StartCoroutine(ExplosionCoroutine());


    } //움직이기 
   
    IEnumerator ExplosionCoroutine()
    {

        if (once == false)
        {
            once = true;
            for(int i = 0; i <8; i ++)
            {
                explosionSound[i].PlayOneShot(explosionSoundClip[i]);
                yield return new WaitForSeconds(0.5f);
            }

            once = false;
        }
    }

   


    public void Play(int index)
    {
        explosionSound[index].PlayOneShot(explosionSoundClip[index]);
    }
}
