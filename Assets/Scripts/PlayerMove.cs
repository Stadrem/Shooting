using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;

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

        if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }

        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }

        if (v != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //dir의 크기를 1로 변경
        dir.Normalize();

        //이동 공식 p = p0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
