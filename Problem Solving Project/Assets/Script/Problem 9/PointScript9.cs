using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript9 : MonoBehaviour
{
    private Vector2 scale;
    private Collider2D box, circle;
    private SpriteRenderer spriteRenderer;
    
    private void OnEnable()
    {

        setRandomImage();
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
        //
        int i = 0;
        float interval = Random.RandomRange(0.04f, 0.05f);
        while (transform.localScale.x >= 0.05f)
        {
            //int i berguna untuk memaksa death animation keluar apalabila terjadi kesalahan
            i++;
            if(i >20)
            {
                break;
            }
            //ntah knp kadang nge bug pake lerp
            //transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, interval);
            transform.localScale =  transform.localScale - new Vector3(interval, interval);

            yield return null;
        }
        BoxSpawner9.Instance.ReturnToPool(gameObject);
    }

    private void enableCollider(bool boolean)
    {
        box = GetComponent<BoxCollider2D>();
        circle = GetComponent<CircleCollider2D>();
        box.enabled = boolean;
        circle.enabled = boolean;
    }

    private void setRandomImage()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = PlanetInfo.Instance.planetImage[Random.Range(0, PlanetInfo.Instance.planetImage.Count)];
        
    }

}
