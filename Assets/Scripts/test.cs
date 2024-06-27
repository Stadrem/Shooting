using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{
    bool canMove = true;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(canMove == true)
        {
            transform.Translate(transform.right * 5 * Time.deltaTime, Space.World);

            distance += 5 * Time.deltaTime;

            if (distance > 5)
            {
                transform.position -= transform.right * (distance - 5);

                canMove = false;
            }
        }
        else
        {
        }
    }
}
