using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    //최대 HP
    public float MaxHP = 10;

    //현재 HP
    float currentHP = 0;

    //hp바 UI
    public Image hpBar;


    // Start is called before the first frame update
    void Start()
    {
        //현재 HP를 최대 HP로
        currentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //HP바를 갱신
        //hpBar.fillAmount = currentHP / MaxHP;
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, currentHP / MaxHP, 2 * Time.deltaTime);
    }

    //현재 HP를 증감하는 함수
    public void UpdateHP(float value)
    {
        //현재 HP value를 더함
        currentHP += value;

        //HP가 0이면
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }

    }
}
