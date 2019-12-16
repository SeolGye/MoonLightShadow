using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas1Manager : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;

    

    void Start()
    {
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);

        StartCoroutine(CanvasCoroutine());
    }

    IEnumerator CanvasCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Text4.SetActive(true);
        text4.text = "1장";

        yield return new WaitForSeconds(1f);
        Text1.SetActive(true);
        text1.text = "시야에서";

        yield return new WaitForSeconds(1f);
        Text2.SetActive(true);
        text2.text = "사라지지";

        yield return new WaitForSeconds(1f);
        Text3.SetActive(true);
        text3.text = "말 것";
        yield return new WaitForSeconds(2f);




    }
}
