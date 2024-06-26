using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�ӵ�
    public float speed = 5;

    //�÷��̾�
    GameObject player;

    //����
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
        }
        else
        {
            //�÷��̾� ã��
            player = GameObject.Find("Player");

            //�÷��̾ �� ã�Ҵٸ�
            if(player != null)
            {
                //60% Ȯ���� �÷��̾� ����
                dir = player.transform.position - transform.position;

                //dir�� ũ�⸦ 1�� ����
                dir.Normalize();
            }
            //Player�� �� ã�Ҵٸ�
            else
            {
                dir = Vector3.back;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //2. �� �������� �̵�
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //�ε��� ������Ʈ ���ֱ�
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name.Contains("Bullet") == true)
        {
            other.gameObject.SetActive(false);
        }

        //���� ������
        Destroy(gameObject);
    }
}
