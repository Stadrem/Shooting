using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //속도
    public float speed = 5;

    //플레이어
    GameObject player;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //Random.Range 0~9 사이의 숫자 대입
        int random = Random.Range(0, 10);
        
        if (random < 4)
        {
            //40% 확률로 직선 방향
            dir = Vector3.back;
            Debug.Log(random + " 직진");
        }
        else
        {
            //플레이어 찾기
            player = GameObject.Find("Player");

            //60% 확률로 플레이어 방향
            dir = player.transform.position - transform.position;

            //dir의 크기를 1로 변경
            dir.Normalize();
            Debug.Log(random + " 플레이어");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //2. 그 방향으로 이동
        transform.position += dir * speed * Time.deltaTime;
    }
}
