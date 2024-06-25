using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //속도
    public int speed = 5;

    //플레이어
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1. 플레이어를 향하는 방향
        Vector3 dir = player.transform.position - transform.position;

        //dir의 크기를 1로 변경
        dir.Normalize();

        //2. 그 방향으로 이동
        transform.position += dir * speed * Time.deltaTime;
    }
}
