using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�ӵ�
    public int speed = 5;

    //�÷��̾�
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1. �÷��̾ ���ϴ� ����
        Vector3 dir = player.transform.position - transform.position;

        //dir�� ũ�⸦ 1�� ����
        dir.Normalize();

        //2. �� �������� �̵�
        transform.position += dir * speed * Time.deltaTime;
    }
}
