using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void problem1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void problem2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void problem3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
    public void problem4()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
    public void problem5()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }
    public void problem6()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }
    public void problem7()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }
    public void problem8()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(8);
    }
    public void problem9()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(9);
    }
    public void backToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
