using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        // Restart Level on pressing R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1.0f;
        }

        // Quit the game on pressing Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

        
}
