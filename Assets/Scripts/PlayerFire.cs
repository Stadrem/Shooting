using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //bullt ����
    public GameObject bulletMake;

    //�߻� ��ġ ����
    public GameObject firePositionA;
    public GameObject firePositionB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate�� �����ؼ� bullet ������ ž��
            GameObject bulletA = Instantiate(bulletMake);
            GameObject bulletB = Instantiate(bulletMake);

            //bullet�� ��ġ�� firePosition���� �̵�
            bulletA.transform.position = firePositionA.transform.position;
            bulletB.transform.position = firePositionB.transform.position;

            //1�� �� �ı�
            Destroy(bulletA, 1f);
            Destroy(bulletB, 1f);
        }
    }
}
