using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Transform  Wheel;
    public Vector3 WheelAngle = new Vector3(0f, 0f, 0f);
    public Quaternion GoalAngle = Quaternion.identity;
    public Quaternion GoalAngle2 = Quaternion.identity;

    public float progress;

    private void Start()
    {
        WheelAngle = Wheel.transform.eulerAngles;
        StartCoroutine(LoadScene());
        
    }



    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(5);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            yield return null;
            GoalAngle.eulerAngles = new Vector3(0, 0, -178f);
            GoalAngle2.eulerAngles = new Vector3(0, 0, -179f);
            Wheel.Rotate(new Vector3(0, 0, Time.deltaTime*-100f));

            /*if(progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }

            else if (progressbar.value >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            if(progressbar.value>=1f&&operation.progress>=0.9f)
            {
                operation.allowSceneActivation = true;
            }

           

            if(Wheel.eulerAngles.z>=-179f)
            {
                WheelAngle.z = Mathf.MoveTowards(WheelAngle.z, -179f, Time.deltaTime*200f);
                Wheel.eulerAngles = WheelAngle;
            }
            else if (Wheel.eulerAngles.z <=-179f)
            {
                WheelAngle.z = Mathf.MoveTowards(WheelAngle.z, -180f, Time.deltaTime*200f);
                Wheel.eulerAngles = WheelAngle;

            }
          

            if (Wheel.eulerAngles.z> -178f)
            {
                Wheel.transform.rotation = Quaternion.Lerp(Wheel.transform.rotation, GoalAngle, Time.deltaTime );
                
            }
            else if(Wheel.eulerAngles.z <= -178f)
            {
                Wheel.transform.rotation = Quaternion.Lerp(Wheel.transform.rotation, GoalAngle2, Time.deltaTime);
            }
            
               */

            if ( operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;

            }

        }



    }
    
}
