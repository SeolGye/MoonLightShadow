using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBoundary : MonoBehaviour
{

    public MessageManager message;
    private bool once = false;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Milica" &&   once == false)
        {
            once = true;
            //message.Alert("어둠속으로 가지 마십시오", 3);
            once = false;

        }

    }


}
