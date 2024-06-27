using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //bullt 지정
    public GameObject bulletMake;
    public GameObject bulletMakeB;

    //발사 위치 지정
    public GameObject firePositionA;
    public GameObject firePositionB;
    public GameObject firePositionC;

    //총알 갯수
    public int bulletCount = 10;
    public int bulletCountB = 10;

    //생성시간
    public float createTime = 0.1f;
    public float createTimeB = 0.3f;

    //현재시간
    public float currentTime = 0;
    public float currentTimeB = 0;

    //총알 탄창
    public List<GameObject> magazine = new List<GameObject>();
    public List<GameObject> magazineB = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            magazine.Add(Instantiate(bulletMake));

            magazine[i].SetActive(false);
        }
        for (int i = 0; i < bulletCountB; i++)
        {
            magazineB.Add(Instantiate(bulletMakeB));

            magazineB[i].SetActive(false);
        }
    }

    // Update is called once per frame//
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTimeB += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (currentTime > createTime)
            {
                for (int j = 0; j < bulletCount; j++)
                {
                    if (magazine[j].gameObject.activeSelf == false)
                    {
                        magazine[j].transform.position = firePositionC.transform.position;

                        magazine[j].SetActive(true);

                        currentTime = 0;

                        break;
                    }
                }
            }
            if (currentTimeB > createTimeB)
            {
                for (int j = 0; j < bulletCountB; j++)
                {
                    if (magazineB[j].gameObject.activeSelf == false)
                    {
                        magazineB[j].transform.position = firePositionA.transform.position;

                        magazineB[j].SetActive(true);

                        currentTimeB = 0;

                        break;
                    }
                }
                for (int j = 0; j < bulletCountB; j++)
                {
                    if (magazineB[j].gameObject.activeSelf == false)
                    {
                        magazineB[j].transform.position = firePositionB.transform.position;

                        magazineB[j].SetActive(true);

                        currentTimeB = 0;

                        break;
                    }
                }
            }
        }
    }
}
