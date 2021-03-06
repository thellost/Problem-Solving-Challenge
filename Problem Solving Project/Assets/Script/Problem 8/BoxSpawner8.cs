using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner8 : MonoBehaviour
{
    //singletone structure
    private static BoxSpawner8 instance = null;
    public static BoxSpawner8 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BoxSpawner8>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = " BoxSpawner";
                    instance = go.AddComponent<BoxSpawner8>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }
    [SerializeField] GameObject boxPrefab;
    [SerializeField] int maxNumberOfBox;
    [SerializeField] float areaWidth, areaHeight, objectSizeMax, respawnInterval;
    // pool list
    private Dictionary<string, List<GameObject>> pool;
    private List<GameObject> boxList;
    float areaOffset;
    int numberOfBox;
    // Start is called before the first frame update
    void Start()
    {
        numberOfBox = Random.Range(1, maxNumberOfBox + 1);
        areaOffset = 0.5f;
        spawnBox();
    }

   private void spawnBox()
    {
        // init pool
        pool = new Dictionary<string, List<GameObject>>();

        
        GameObject box;

        for (int i = 0; i < numberOfBox; i++)
        {
            box = GenerateFromPool(boxPrefab);
            float randomScale = Random.Range(0, objectSizeMax) + 0.25f;
            box.transform.localScale = new Vector2(randomScale, randomScale);
        }
    }
    private GameObject GenerateFromPool(GameObject item)
    {
       //generate random position that doesnt collide with avatar
        Vector2 position = generateRandomPosition();

        if (pool.ContainsKey(item.name))
        {
            // if item available in pool
            if (pool[item.name].Count > 0)
            {
                GameObject newItemFromPool = pool[item.name][0];
                pool[item.name].Remove(newItemFromPool);
                newItemFromPool.SetActive(true);
                newItemFromPool.transform.position = position;
                return newItemFromPool;
            }
        }
        else
        {
            // if item list not defined, create new one
            pool.Add(item.name, new List<GameObject>());
        }

       
        // create new one if no item available in pool
        GameObject newItem = Instantiate(item, position, Quaternion.identity);
        newItem.name = item.name;
        return newItem;
    }

    public void ReturnToPool(GameObject item)
    {
        if (!pool.ContainsKey(item.name))
        {
            Debug.LogError("INVALID POOL ITEM!!");
        }
        pool[item.name].Add(item);
        item.SetActive(false);
        StartCoroutine("spawn");
        
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(respawnInterval);
        GenerateFromPool(boxPrefab);
    }
    // Update is called once per frame
    private bool checkInsideSphere(Vector2 position)
    {
        GameObject avatar = GameObject.Find("Avatar");
        float distance = Vector2.Distance(position, avatar.transform.position);
        if(distance < 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Vector2 generateRandomPosition()
    { 
        //menyimpan posisi instantiate
        float x, y;
        Vector2 position;
        do
        {
            x = Random.RandomRange(-areaWidth + areaOffset, areaWidth - areaOffset);
            y = Random.RandomRange(-areaHeight + areaOffset, areaHeight - areaOffset);
            position = new Vector2(x, y);
        } while (checkInsideSphere(position));
        return position;
        
    }
}
