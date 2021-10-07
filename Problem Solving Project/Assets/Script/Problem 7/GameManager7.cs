using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager7 : MonoBehaviour
{

    //ini untuk membuat singleton
    private static GameManager7 instance = null;
    public static GameManager7 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager7>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "GameManager";
                    instance = go.AddComponent<GameManager7>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }
    public int score { get; private set; }
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("Score : {0}", score);
    }

    public void addScore()
    {
        score++;
    }

}
