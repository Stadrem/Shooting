using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�ӵ�
    public float speed = 5;

    //�÷��̾�
    GameObject player;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //Random.Range 0~9 ������ ���� ����
        int random = Random.Range(0, 10);
        
        if (random < 4)
        {
            //40% Ȯ���� ���� ����
            dir = Vector3.back;
            Debug.Log(random + " ����");
        }
        else
        {
            //�÷��̾� ã��
            player = GameObject.Find("Player");

            //60% Ȯ���� �÷��̾� ����
            dir = player.transform.position - transform.position;

            //dir�� ũ�⸦ 1�� ����
            dir.Normalize();
            Debug.Log(random + " �÷��̾�");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //2. �� �������� �̵�
        transform.position += dir * speed * Time.deltaTime;
    }
}
