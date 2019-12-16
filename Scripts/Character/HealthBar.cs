using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float damagedHealthFadeTimerMax = 1f;
    public Image barImage; //체력 부분
    public Image damagedBarImage; // 체력 뒷 배경
    private Color damagedColor;
    private float damagedHealthFadeTimer;
    public MilicaHealth milicahealth;


    
    void Start()
    {
        SetHealth(milicahealth.GetHealthNormalized()); // 주인공 체력 스크립트에서 현재 주인공 체력 함수값 입력한다.
        milicahealth.OnDamaged += MilicaHealth_OnDamaged;
        milicahealth.OnHealed += MilicaHealth_OnHealed; //이벤트 핸들러에 등록한다.

        damagedColor = damagedBarImage.color; 
        damagedColor.a = 0f;
        damagedBarImage.color = damagedColor; 
        //체력 뒷 배경을 투명하게 하여 안 보이게 한다.

    }

    void Update() //상시 대기
    {
        if(damagedColor.a>0)  //보일 경우
        {
            damagedHealthFadeTimer -= Time.deltaTime; //딜레이 시간이 걸린다
            if(damagedHealthFadeTimer <0) //시간이 다 되면
            {
                float fadeAmount = 5f; 
                damagedColor.a -= fadeAmount * Time.deltaTime; //임시색 투명도를 줄여나간다
                damagedBarImage.color = damagedColor; //임시색 투명도를 실제 적용한다
            }

        }

        if (damagedColor.a <= 0) //투명도가 다 떨어지면
        {
            SetHealth2(milicahealth.GetHealthNormalized()); // 체력 뒷 배경 값을 체력값과 같게 한다.
        }
    }
    void SetHealth(float healthNormalized)
    {
        barImage.fillAmount = healthNormalized;
    } 
    // 체력바에 입력하는 기능

     void SetHealth2(float healthNormalized)
    {
        damagedBarImage.fillAmount = healthNormalized;
    }

    private void MilicaHealth_OnHealed(object sender,System.EventArgs e)
    {
        SetHealth(milicahealth.GetHealthNormalized());
    }

    private void MilicaHealth_OnDamaged(object sender, System.EventArgs e) // 데미지를 입으면
    {


        damagedColor.a = 1; //임시 색을 보이게 만들고
        damagedBarImage.color = damagedColor; //임시 색을 실제 백그라운드에 적용한다.
        damagedHealthFadeTimer = damagedHealthFadeTimerMax; // 딜레이 시간초를 설정한다.
        SetHealth(milicahealth.GetHealthNormalized()); // 체력값을 슬라이더에 적용한다.
       


    }


}
