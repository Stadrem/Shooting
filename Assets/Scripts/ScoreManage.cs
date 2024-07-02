using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManage : MonoBehaviour
{
    //나를 담을 변수
    public static ScoreManage instance;

    // 현재 점수
    public int cureentScore = 0;

    private void Awake()
    {
        //만약에 instance 값이 없다면
        if(instance == null)
        {
            //나를 instance 변수에 담자
            instance = this;
        }
        //그렇지 않으면
        else
        {
            //나의 게임 오브젝트 파괴
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int addValue)
    {
        cureentScore += addValue;

        print("현재 점수 : " + cureentScore);
    }
}
