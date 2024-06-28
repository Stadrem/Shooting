using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundMove : MonoBehaviour
{
    Material mat;

    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();

        mat = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
