using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //bullt 지정
    public GameObject bulletMake;

    //발사 위치 지정
    public GameObject firePositionA;
    public GameObject firePositionB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate로 생성해서 bullet 변수에 탑재
            GameObject bulletA = Instantiate(bulletMake);
            GameObject bulletB = Instantiate(bulletMake);

            //bullet의 위치를 firePosition으로 이동
            bulletA.transform.position = firePositionA.transform.position;
            bulletB.transform.position = firePositionB.transform.position;

            //1초 뒤 파괴
            Destroy(bulletA, 1f);
            Destroy(bulletB, 1f);
        }
    }
}
