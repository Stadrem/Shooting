using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //bullt ����
    public GameObject bulletMake;

    //�߻� ��ġ ����
    public GameObject firePositionC;

    //�Ѿ� ����
    public int bulletCount = 10;

    //�����ð�
    public float createTime = 0.1f;

    //����ð�
    public float currentTime = 0;

    //�Ѿ� źâ
    public List<GameObject> magazine = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < bulletCount; i++)
        {
            magazine.Add(Instantiate(bulletMake));

            magazine[i].SetActive(false);
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
                    if (magazine[j].gameObject.activeSelf == false)
                    {
                        magazine[j].transform.position = firePositionC.transform.position;

                        magazine[j].SetActive(true);

                        currentTime = 0;

                        break;
                    }
                }
            }
        }
    }
}
