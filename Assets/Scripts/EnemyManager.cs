using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Enemy Prefab ����
    public GameObject enemyPrefab;

    //�����ð�
    public float createTime = 0;

    //����ð�
    public float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //�ð��� �帣�� ��
        currentTime += Time.deltaTime;

        //���࿡ 1�ʰ� �����ٸ�
        if (currentTime > createTime)
        {
            //Enemy�� �ϳ� ����
            GameObject enemyCreate = Instantiate(enemyPrefab, transform.position, transform.rotation);

            //�ð� �ʱ�ȭ
            currentTime = 0;

            //�����ð� ����
            createTime = Random.Range(0.5f, 1);
        }
    }
}
