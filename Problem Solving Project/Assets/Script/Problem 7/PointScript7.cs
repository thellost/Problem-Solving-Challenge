using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript7 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Avatar")
        {
            GameManager7.Instance.addScore();
            Destroy(gameObject);
        }
    }
}
