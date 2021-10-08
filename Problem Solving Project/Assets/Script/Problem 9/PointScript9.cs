using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript9 : MonoBehaviour
{
    private Vector2 scale;
    private Collider2D box, circle;
    private void OnEnable()
    {

        StartCoroutine("spawnAnimation");
    }

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        circle = GetComponent<CircleCollider2D>();
        scale = transform.localScale;
        StartCoroutine("spawnAnimation");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Avatar")
        {
            GameManager9.Instance.addScore();
            StartCoroutine("deathAnimation");
        }
    }

    IEnumerator spawnAnimation()
    {
        enableCollider(true);
        transform.localScale = Vector2.zero;
        float interval = Random.RandomRange(0.05f, 0.25f);
        while ( transform.localScale.x <= (scale.x-0.1f) && transform.localScale.y <= (scale.y-0.1f))
        {
            transform.localScale = Vector2.Lerp(transform.localScale, scale, interval + Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator deathAnimation()
    {
        enableCollider(false);
        float interval = Random.RandomRange(0.05f, 0.25f);

        while (transform.localScale.x >= (0.1f) && transform.localScale.y >= (0.1f))
        {
            transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, interval + Time.deltaTime);
            yield return null;
        }

        BoxSpawner9.Instance.ReturnToPool(gameObject);
    }

    private void enableCollider(bool boolean)
    {
        box.enabled = boolean;
        circle.enabled = boolean;
    }

}
