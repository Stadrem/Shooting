using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{
    //나를 담을 변수
    public static ScoreManage instance;

    // 현재 점수
    public int currentScore = 0;

    //현재 점수UI
    public Text scoreText;

    //최고 점수
    public int bestScore;

    //최고 점수 UI
    public Text bestScoreText;

    int number;

    public int Number
    {
        get { 
            return number; 
        }
        set { 
            number = value;
        }
    }

    public int CrurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            AddScore(value);
        }
    }

    public int BestScore
    {
        get
        {
            return bestScore;
        }
        set
        {
            bestScore = value;
            bestScoreText.text = "최고 점수 : " + bestScore;
        }
    }

    public int GetNumber()
    {
        return number;
    }
    public void SetNumber(int value)
    {
        number = value;
    }

    private void Awake()
    {
        //만약에 instance 값이 없다면
        if(instance == null)
        {
            //나를 instance 변수에 담자
            instance = this;
        }
        //그렇지 않으면
        else
        {
            //나의 게임 오브젝트 파괴
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        //저장되어 있는 최고 점수를 bestScore에 세팅
        bestScore = PlayerPrefs.GetInt("Best_Score", 0);

        //최고 점수 UI를 갱신
        bestScoreText.text = "최고 점수 : " + bestScore;
        */

        BestScore = PlayerPrefs.GetInt("Best_Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddScore(int addValue)
    {
        currentScore += addValue;

        //현재 점수 UI를 갱신
        scoreText.text = "현재 점수 : " + currentScore;

        //만약에 현재 점수가 최고 점수를 넘었는가
        if(currentScore > bestScore)
        {
            /*
            //최고 점수를 현재 점수로 세팅
            bestScore = currentScore;

            //최고 점수 UI를 갱신
            bestScoreText.text = "최고 점수 : " + bestScore;
            */

            BestScore = currentScore;

            //최고 점수를 저장
            PlayerPrefs.SetInt("Best_Score", bestScore);
            PlayerPrefs.DeleteAll();
        }
    }
}
