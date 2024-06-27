using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //속도
    public float speed = 5;

    public GameObject effectObject;

    //플레이어
    GameObject player;

    //방향
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //Random.Range 0~9 사이의 숫자 대입
        int random = Random.Range(0, 10);
        
        if (random < 4)
        {
            //40% 확률로 직선 방향
            dir = Vector3.back;
        }
        else
        {
            //플레이어 찾기
            player = GameObject.Find("Player");

            //플레이어를 잘 찾았다면
            if(player != null)
            {
                //60% 확률로 플레이어 방향
                dir = player.transform.position - transform.position;

                //dir의 크기를 1로 변경
                dir.Normalize();
            }
            //Player를 못 찾았다면
            else
            {
                dir = Vector3.back;
            }
        }
    }

    // Update is called once per frame.
    void Update()
    {
        //2. 그 방향으로 이동
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //부딪힌 오브젝트 없애기
            Destroy(other.gameObject);

            GameObject effect = Instantiate(effectObject);
            effect.transform.position = transform.position;
        }
        else if (other.gameObject.name.Contains("Bullet") == true)
        {
            other.gameObject.SetActive(false);

            GameObject effect = Instantiate(effectObject);
            effect.transform.position = transform.position;
        }

        //나를 없애자
        Destroy(gameObject);
    }
}
