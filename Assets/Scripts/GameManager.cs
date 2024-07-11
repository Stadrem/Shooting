using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text countDown;

    float currentTime = 0;

    int i = 3;

    public bool isPlaying = false;

    int lastSecond = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //UI 크기 조절
        countDown.transform.localScale = Vector3.one * 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false)
        {
            CountDown();
        }
    }

    void CountDown()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 1.0f)
        {
            //UI 크기 조절
            countDown.transform.localScale = Vector3.one * 2.5f;

            countDown.text = i.ToString();

            if (i == 0)
            {
                countDown.text = "Start!";
            }
            else if (i < 0)
            {
                countDown.gameObject.SetActive(false);

                isPlaying = true;
            }

            currentTime = 0;

            i--;

            if (i != lastSecond)
            {
                //iTween
                Hashtable hash = iTween.Hash(
                    "scale", Vector3.one, 
                    "time", 0.5f, 
                    "easetype", iTween.EaseType.easeOutBounce, 
                    "oncompletetarget", gameObject,
                    "oncomplete", nameof(OnComplete));
                iTween.ScaleTo(countDown.gameObject, hash);

                lastSecond = i;
            }

        }
    }
    void OnComplete()
    {
        print("ㄱㄱㄱㄱㄱ");
    }
}
