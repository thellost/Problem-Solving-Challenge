using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem4 : MonoBehaviour
{
    public float speed;
    Vector2 movement;
    Rigidbody2D rb;
    float h, v;
    // Start is called before the first frame update
    void Start()
    {
        h = 0;
        v = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        
    }

    private void FixedUpdate()
    {
        Move(h, v);
    }
    public void Move(float h, float v)
    {

        //Set nilai x dan y
        movement.Set(h, v);

        //Menormalisasi nilai vector agar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime;
        //Move to position
        //playerRigidbody.MovePosition(transform.position + movement);
        //mencoba menggunakan force saja ketimbang kecepatan tetap , dikarenakan movement terasa terlalu static untuk selera saya
        rb.velocity = movement * speed;
    }
}
