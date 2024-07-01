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
    int bulletCountC = 45;

    //생성시간
    public float createTime = 0.1f;
    public float createTimeB = 0.3f;
    public float createTimeC = 3.0f;

    //현재시간
    public float currentTime = 0;
    public float currentTimeB = 0;
    public float currentTimeC = 0;

    //총알 탄창
    public List<GameObject> magazine = new List<GameObject>();
    public List<GameObject> magazineB = new List<GameObject>();
    public List<GameObject> magazineC = new List<GameObject>();

    private float bulletTimer = 0f;
    private int bIndex = 0;

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

        //총알을 8개 만들기
        for (int i = 0; i < bulletCountC; i++)
        {
            magazineC.Add(Instantiate(bulletMake));

            magazineC[i].SetActive(false);

            magazineC[i].transform.position = transform.position;

            magazineC[i].transform.rotation = Quaternion.Euler(0, 360 / bulletCountC * i, 0);

            magazineC[i].transform.position += magazineC[i].transform.forward * 5;
        }
    }

    // Update is called once per frame//
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTimeB += Time.deltaTime;
        currentTimeC += Time.deltaTime;

        //if (Input.GetButton("Fire1"))
        //{
        if (currentTime > createTime)
        {
            for (int j = 0; j < bulletCount; j++)
            {
                if (magazine[j].gameObject.activeSelf == false)
                {
                    magazine[j].transform.position = firePositionC.transform.position;

                    magazine[j].SetActive(true);

                    BulletFire bulletComp = magazine[j].GetComponent<BulletFire>();

                    bulletComp.PlaySound();

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

                    BulletFire bulletComp = magazineB[j].GetComponent<BulletFire>();

                    bulletComp.PlaySound();

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

                    BulletFire bulletComp = magazineB[j].GetComponent<BulletFire>();

                    bulletComp.PlaySound();

                    currentTimeB = 0;

                    break;
                }
            }
        }
        /*
        if (currentTimeC > createTimeC)
        {
            for (int k = 0; k < bulletCountC; k++)
            {

                magazineC[k].transform.position = transform.position;

                magazineC[k].transform.rotation = Quaternion.Euler(0, 360 / bulletCountC * k, 0);

                magazineC[k].transform.position += magazineC[k].transform.forward * 5;

                magazineC[k].SetActive(true);

                BulletFire bulletComp = magazineC[k].GetComponent<BulletFire>();

                bulletComp.PlaySound();

                currentTimeC = 0;
            }
        }
        */

        if (Input.GetButton("Fire2"))
        {
            bulletTimer += Time.deltaTime;

            if (bulletTimer >= 0.05f && bIndex < bulletCountC)
            {
                magazineC[bIndex].transform.position = transform.position;
                magazineC[bIndex].transform.rotation = Quaternion.Euler(0, 360 / bulletCountC * bIndex, 0);
                magazineC[bIndex].transform.position += magazineC[bIndex].transform.forward * 5;
                magazineC[bIndex].SetActive(true);

                BulletFire bulletComp = magazineC[bIndex].GetComponent<BulletFire>();
                bulletComp.PlaySound();

                bulletTimer = 0f; // Reset the timer
                bIndex++; // Move to the next bullet
            }
            else if (bIndex == bulletCountC)
            {
                bIndex = 0;
            }
        }
    }
}
