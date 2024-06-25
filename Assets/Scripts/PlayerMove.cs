using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//주석걸기 컨트롤 + K + C
//주석해제 컨트롤 + K + U
//코드정렬 컨트롤 + K + F

/*
 사용자의 입력을 받아서 이동방향을 정하고
 그 방향으로 움직임
 */

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //1.사용자의 입력을 받음(W, A, S, D)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        //2. 입력 받을 값을 이용해서 이동방향을 정함
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.forward * v;
        Vector3 dir = dirH + dirV;

        //dir의 크기를 1로 변경
        dir.Normalize();

        //이동 공식 p = p0 + vt
        //transform.position(P) = transform.position(현재위치) + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;
    }
}
