using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundKnife : MonoBehaviour
{

    public int DamageAmount;
    public GameObject DamagePanel;
    private bool damaged = false;
    private MilicaHealth milicahealth;
    public GameObject milicaAni;
    public GameObject camera;

    private GameObject milicaObject;
    public Vector3 milicaDirection;
    public Vector3 desPosition;


    void OnTriggerStay2D(Collider2D other)
    {
       

        if(other.tag == "Player")
        {
        
            Vector3 direction = new Vector3(other.gameObject.transform.position.x - transform.position.x, other.gameObject.transform.position.y - transform.position.y,0f);
            milicaDirection = direction.normalized * 2;
            milicaObject = other.gameObject;
            desPosition = milicaObject.transform.position + milicaDirection;
            Debug.Log(desPosition);
            MilicaMovement.instance.SetMousePosition(desPosition);
            MilicaMovement.instance.isMoving = false;
            DamagePanel = GameObject.Find("Canvas2");
            camera = GameObject.Find("Main Camera");
            milicaAni = GameObject.FindWithTag("Player");
            milicahealth = milicaAni.gameObject.GetComponent<MilicaHealth>();
            StartCoroutine(DamageCoroutine());
        }
    }


  

    IEnumerator DamageCoroutine()
    {
        if (damaged == false)
        {
           
            MilicaSound.instance.HurtSound();

            MilicaMovement.instance.StopMove();
            damaged = true;
            milicahealth.Damage(DamageAmount);
            camera.GetComponent<CameraTrack>().ShakeCamera(0.2f, 0.5f);
            DamagePanel.transform.Find("Damage").gameObject.GetComponent<Animation>().Play("DamagePanelA");
            milicaAni.GetComponent<Animation>().Play("Damaged1");
            MilicaMovement.instance.CanMove();

            yield return new WaitForSeconds(1.5f);
           // DamagePanel.transform.FindChild("Damage").gameObject.SetActive(false);

            damaged = false;
        }
    }

  

}
