using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCollection : MonoBehaviour
{   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PanelColl());
        }
    }

    IEnumerator PanelColl()
    {
        yield return new WaitForSeconds(0.11f);
        
        this.gameObject.SetActive(false);


    }
}
