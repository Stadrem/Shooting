using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveB : MonoBehaviour
{
    float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //아래로 움직이고 싶다
        transform.position += Vector3.back * speed * Time.deltaTime;

        //만약에 위치의 z값이 -10보다 작으면
        if(transform.position.z < -10)
        {
            //나의 위치를 위로 10만큼 올려준다
            transform.position += Vector3.forward * 60;
        }
    }
}
