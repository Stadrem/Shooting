using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Enemy Prefab 설정
    public GameObject enemyPrefab;

    //생성시간
    public float createTime = 0;

    //현재시간
    public float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //시간을 흐르게 함
        currentTime += Time.deltaTime;

        //만약에 1초가 지났다면
        if (currentTime > createTime)
        {
            //Enemy를 하나 생성
            GameObject enemyCreate = Instantiate(enemyPrefab, transform.position, transform.rotation);

            //시간 초기화
            currentTime = 0;

            //생성시간 랜덤
            createTime = Random.Range(0.5f, 1);
        }
    }
}
