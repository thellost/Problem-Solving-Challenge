using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript8 : MonoBehaviour
{
    private Vector2 scale;
    private void OnEnable()
    {

        StartCoroutine("spawnAnimation");
    }

    private void Start()
    {
        
        scale = transform.localScale;
        StartCoroutine("spawnAnimation");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Avatar")
        {
            GameManager8.Instance.addScore();
            BoxSpawner8.Instance.ReturnToPool(gameObject);
        }
    }

    IEnumerator spawnAnimation()
    {
        transform.localScale = Vector2.zero;
        float interval = Random.RandomRange(0.05f, 0.5f);
        while ( transform.localScale.x <= (scale.x-0.1f) && transform.localScale.y <= (scale.y-0.1f))
        {
            transform.localScale = Vector2.Lerp(transform.localScale, scale, interval + Time.deltaTime);
            yield return null;
        }
    }

}
