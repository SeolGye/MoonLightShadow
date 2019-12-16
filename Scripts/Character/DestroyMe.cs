using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float aliveTime;


    void Awake()
    {

        Destroy(gameObject, aliveTime);

    }
    
}
