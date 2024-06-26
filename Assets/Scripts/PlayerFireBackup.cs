using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerFireBackup : MonoBehaviour
{
    //bullt ����
    public GameObject bulletMake;

    //�߻� ��ġ ����
    public GameObject firePositionC;

    //�����ð�
    public float createTime = 0.1f;

    //����ð�
    public float currentTime = 0;

    //�Ѿ� ����
    public int bulletCount = 10;

    //�Ѿ� źâ
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
