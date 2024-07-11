using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    float speed = 40;
    float h = 0;
    float v = 0;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 게임 중이 아니라면 함수를 나가자
        if (GameManager.instance.isPlaying == false)
        {
            return;
        }

        #region 좌우 회전 이동
        /*
        //A / D키 입력을 받아서 회전.
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //h값으로 회전
        transform.Rotate(0, h * rootSpeed * Time.deltaTime, 0);

        //만약 w를 눌렀을 때 앞으로 간다
        if (v != 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        */
        #endregion

        #region 기존 이동

        //1.사용자의 입력을 받음(W, A, S, D)
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");


        //2. 입력 받을 값을 이용해서 이동방향을 정함
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.forward * v;
        Vector3 dir = dirH + dirV;

        //dir의 크기를 1로 변경
        dir.Normalize();

        Vector3 pos = transform.position;

        //이동 공식 p = p0 + vt
        pos += dir * speed * Time.deltaTime;

        //화면 밖으로 나가지 못하게 함
        //나의 위치에서 왼쪽 상단
        Vector3 leftTop = Camera.main.WorldToViewportPoint(pos + new Vector3(-0.75f, 0.75f));
        Vector3 rightBottom = Camera.main.WorldToViewportPoint(pos + new Vector3(0.75f, -0.75f));

        //왼쪽, 오른쪽 체크 좌우로 움직이지 못하게 하자
        if(leftTop.x < 0 || rightBottom.x > 1)
        {
            dir.x = 0;
        }

        //위, 아래 체크해서 위아래로 움직이지 못하게 하자
        if(leftTop.y > 1 || rightBottom.y < 0)
        {
            dir.z = 0;
        }

        //dir의 크기를 1로 바꾸기
        dir.Normalize();

        //dir 방향으로 움직임
        transform.position += dir * speed * Time.deltaTime;

        /*
        if (viewPortPoint.x < 0 || viewPortPoint.x > 1 || viewPortPoint.y < 0 || viewPortPoint.y > 1)
        {
            //이동한 만큼 되돌리자
            //transform.position -= dir * speed * Time.deltaTime;
        }
        else
        {
            transform.position = pos;
        }*/
        #endregion
    }

    //이 오브젝트가 파괴되면 호출되는 함수
    private void OnDestroy()
    {
        //게임오버 화면으로 전환
        SceneManager.LoadScene("GameOver");
    }
}
