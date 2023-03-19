using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject GameWonUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                GameObject.Find("Character").GetComponent<HorizontalController>().enabled = false;
                GameObject.Find("Character").GetComponent<Rigidbody2D>().velocity.Set(0.0f, 0.0f);
                Time.timeScale = 0f;
                GameWonUI.SetActive(true);
            }
        }
    }
}
