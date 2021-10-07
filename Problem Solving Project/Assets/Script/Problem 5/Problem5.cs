using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem5 : MonoBehaviour
{
    public float speed;
    //rigidbody untuk object
    Rigidbody2D rb;
    //referensi ke camera utama
    Camera cam;
    Vector2 point;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        point = cam.ScreenToWorldPoint(Input.mousePosition);

        
    }

    private void FixedUpdate()
    {
        Move(point);
    }

    public void Move(Vector2 pointPosition)
    {

        //memakai move toward ke point yang ada di cursor mouse
        rb.position = Vector3.MoveTowards(transform.position, pointPosition, speed * Time.deltaTime);
    }
}
