using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    private static PlanetInfo instance = null;
    public static PlanetInfo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlanetInfo>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "GameManager";
                    instance = go.AddComponent<PlanetInfo>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }
    public List<Sprite> planetImage;
}
