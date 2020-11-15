using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public double Chrono;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    public void Win(double chrono) {
        Chrono = chrono;
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
        Debug.Log("Game won with chrono : " + Chrono);
    }
}
