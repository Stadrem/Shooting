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

    //모양의 transform
    public Transform trModel;

    // Start is called before the first frame update
    void Start()
    {
        //Random.Range 0~9 사이의 숫자 대입
        int random = Random.Range(0, 10);
        
        if (random < 2)
        {
            //20% 확률로 직선 방향
            dir = Vector3.back;
        }
        else
        {
            //플레이어 찾기
            player = GameObject.Find("Player");

            //플레이어를 잘 찾았다면
            if(player != null)
            {
                //80% 확률로 플레이어 방향
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
        //모양의 정면을 dir로 셋팅

        trModel.forward = dir;
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

            /*
            //ScoreManager GameObject 찾기
            GameObject goSm = GameObject.Find("ScoreManager");

            //찾은 Object가 가지고 있는 ScoreManager Component 가져오기
            ScoreManage sm = goSm.GetComponent<ScoreManage>();

            //가지고 있는 AddScore 함수 실행
            sm.AddScore(10);
            */

            ScoreManage.instance.CrurrentScore = 10;
            ScoreManage.instance.Number = 10;

        }

        //나를 없애자
        Destroy(gameObject);
    }
}
