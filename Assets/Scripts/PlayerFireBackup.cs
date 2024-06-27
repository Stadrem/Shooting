using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
//
public class PlayerFireBackup : MonoBehaviour
{
    //bullt 지정
    public GameObject bulletMake;

    //발사 위치 지정
    public GameObject firePositionC;

    //생성시간
    public float createTime = 0.1f;

    //현재시간
    public float currentTime = 0;

    //총알 갯수
    public int bulletCount = 10;

    //총알 탄창
    GameObject[] bulletArrayA;

    private void Start()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            bulletArrayA[i] = Instantiate(bulletMake);

            bulletArrayA[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (currentTime > createTime)
            {
                for (int j = 0; j < bulletCount; j++)
                {
                    if (bulletArrayA[j].gameObject.activeSelf == false)
                    {
                        bulletArrayA[j].gameObject.SetActive(true);
                        
                        bulletArrayA[j].transform.position = firePositionC.transform.position;

                        currentTime = 0;

                        break;
                    }
                }
            }
        }
    }
}
