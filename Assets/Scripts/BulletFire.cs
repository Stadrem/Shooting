using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float speed = 30;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void PlaySound()
    {
        //AudioSource 컴포넌트 가져오기
        AudioSource audio = GetComponent<AudioSource>();

        //가져온 컴포넌트에서 Play 실행
        audio.Play();
    }
}