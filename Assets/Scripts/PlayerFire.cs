using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //bullt 모양 지정
    public GameObject bulletMake;
    public GameObject bulletMakeB;

    //발사 위치 지정
    public GameObject firePositionA;
    public GameObject firePositionB;
    public GameObject firePositionC;

    //총알 갯수
    int bulletCount = 10;
    int bulletCountB = 10;
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
        //Fire1 탄창 장전
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

        //Fire2 360 총알 탄창 bulletCountC 갯수 만큼 만들기
        for (int i = 0; i < bulletCountC; i++)
        {
            magazineC.Add(Instantiate(bulletMake));

            magazineC[i].SetActive(false);
        }
    }

    // Update is called once per frame//
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTimeB += Time.deltaTime;
        currentTimeC += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            Fire1Fire();
        }

        if (Input.GetButton("Fire2"))
        {
            Fire2Fire();
        }
    }

    void Fire1Fire()
    {
        if (currentTime > createTime)
        {
            for (int j = 0; j < bulletCount; j++)
            {
                if (magazine[j].gameObject.activeSelf == false)
                {
                    BulletFire(j);

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

                    BulletFireB(j);

                    break;
                }
            }
            for (int j = 0; j < bulletCountB; j++)
            {
                if (magazineB[j].gameObject.activeSelf == false)
                {
                    magazineB[j].transform.position = firePositionB.transform.position;

                    BulletFireB(j);

                    break;
                }
            }
        }
    }

    void BulletFire(int j)
    {
        magazine[j].transform.position = firePositionC.transform.position;

        magazine[j].SetActive(true);

        BulletFire bulletComp = magazine[j].GetComponent<BulletFire>();

        bulletComp.PlaySound();

        currentTime = 0;
    }

    void BulletFireB(int i)
    {
        magazineB[i].SetActive(true);

        BulletFire bulletComp = magazineB[i].GetComponent<BulletFire>();

        bulletComp.PlaySound();

        currentTimeB = 0;
    }

    void Fire2Fire()
    {
        bulletTimer += Time.deltaTime;

        //0.05초마다 탄창 배열에서 순차적으로 가져오기
        if (bulletTimer >= 0.05f && bIndex < bulletCountC)
        {
            //총알의 위치를 플레이어 위치로
            magazineC[bIndex].transform.position = transform.position;

            //총알 위치 및 방향 지정
            //Y축, 360도 / 총알의 갯수 만큼 * 총알의 배열 번호
            magazineC[bIndex].transform.rotation = Quaternion.Euler(0, 360 / bulletCountC * bIndex, 0);

            //총알의 정면 방향으로 5 만큼 배치
            magazineC[bIndex].transform.position += magazineC[bIndex].transform.forward * 5;

            magazineC[bIndex].SetActive(true);

            //이펙트, 사운드
            BulletFire bulletComp = magazineC[bIndex].GetComponent<BulletFire>();
            bulletComp.PlaySound();

            bulletTimer = 0f;

            bIndex++;
        }
        //총알 배열 최대 발사에 도달하면 0으로 초기화
        else if (bIndex == bulletCountC)
        {
            bIndex = 0;
        }
    }
}
