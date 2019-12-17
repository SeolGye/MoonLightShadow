using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MessageManager : MonoBehaviour
{
    public Text messageText; //시작 메세지
    public Animator message;
    private int indexTime;


    public void Alert(string str, int indextime)
    {
        message.SetTrigger("Alarm");
        messageText.text = str;
        indexTime = indextime;
        StartCoroutine(MessageCoroutine());

    }

    public void DamagedAlert()
    {
        message.SetTrigger("Alarm");
        messageText.text = "죽음은 모면했습니다";
        indexTime = 3;
        StartCoroutine(MessageCoroutine());

    }
    IEnumerator MessageCoroutine()
    {
        
        yield return new WaitForSeconds(indexTime);
        message.SetTrigger("NotAlarm");
    }
}
