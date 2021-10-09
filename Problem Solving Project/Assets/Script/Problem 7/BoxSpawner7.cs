using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner7 : MonoBehaviour
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] int maxNumberOfBox;
    [SerializeField] float areaWidth, areaHeight, objectSizeMax;
    float areaOffset;
    int numberOfBox;
    // Start is called before the first frame update
    void Start()
    {

        numberOfBox = Random.Range(1, maxNumberOfBox + 1);
        areaOffset = 0.5f;
        //menyimpan posisi instantiate
        float x,y;
        GameObject box;
        
        for(int i = 0; i < numberOfBox; i++)
        {
            
            x = Random.RandomRange(-areaWidth + areaOffset , areaWidth - areaOffset);
            y = Random.RandomRange(-areaHeight + areaOffset, areaHeight - areaOffset);
            box = Instantiate(boxPrefab, new Vector2 (x,y), Quaternion.identity);
            box.transform.localScale = new Vector2 (Random.Range(0, objectSizeMax) + 0.5f , Random.Range(0, objectSizeMax) + 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
