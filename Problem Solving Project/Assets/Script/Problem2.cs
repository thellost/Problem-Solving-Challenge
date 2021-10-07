using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem2 : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
