﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 20;
    float h = 0;
    float v = 0;
    float rootSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        #region 좌우 회전 이동
        /*
        //A / D키 입력을 받아서 회전.
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //h값으로 회전
        transform.Rotate(0, h * rootSpeed * Time.deltaTime, 0);

        //만약 w를 눌렀을 때 앞으로 간다
        if (v != 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        */
        #endregion

        #region 기존 이동
        
        //1.사용자의 입력을 받음(W, A, S, D)
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");


        //2. 입력 받을 값을 이용해서 이동방향을 정함
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.forward * v;
        Vector3 dir = dirH + dirV;

        //dir의 크기를 1로 변경
        dir.Normalize();

        //이동 공식 p = p0 + vt
        transform.position += dir * speed * Time.deltaTime;
        
        #endregion
    }
}
