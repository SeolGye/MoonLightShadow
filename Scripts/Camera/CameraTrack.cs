using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public static CameraTrack instance;
    public float cameraSpeed;
    public float smoothTime = 1f;
    private Vector3 lastMovingVelocity;
    private float lastZoomSpeed;
    public Camera cam;

    private bool canCameraMove;
    private bool canOnce;

    public float shakeTimer = 0f; //흔들림 시간
    public float shakeAmount = 0f; // 흔들림 범위

    public AudioClip[] DeadSoundClip = new AudioClip[2];
    public int deadSoundNum;
    AudioSource myAudio;


    void Awake()
    {
        CameraTrack.instance = this;
        canCameraMove = true;
        cam = GetComponent<Camera>();
        myAudio = this.gameObject.GetComponent<AudioSource>();

    }

    void Update()
    {
        if (shakeTimer >= 0)
        {
            Vector3 ShakePos = Random.insideUnitCircle * shakeAmount;

            transform.position = transform.position + new Vector3(ShakePos.x, ShakePos.y, 0);
            shakeTimer -= Time.deltaTime;
        }
    }

    
    public void SetTarget(Transform newTarget) 
    {
        transform.position = newTarget.position;

    } //카메라 위치 잡기

    public void Move(Transform targetPoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, cameraSpeed * Time.deltaTime);
        //Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPoint.position, ref lastMovingVelocity, smoothTime);
        //transform.position = smoothPosition;

    } //움직이기 

    public void ShakeCamera(float shakePwr,float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }

    public void DeadSound()
    {
        if (!myAudio.isPlaying)
        {
            myAudio.Stop();

            deadSoundNum = Random.Range(0, 2);
            myAudio.clip = DeadSoundClip[deadSoundNum];
            myAudio.Play();
        }
    }
}
