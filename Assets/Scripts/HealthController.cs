using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;
    private Animator anim;
    public AudioSource hitSoundEffect;

    public int maxHealth = 6;

    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private Image[] hearts;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isAlive();
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    private bool isAlive()
    {
        if (playerHealth > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TakeDamage(int damage)
    {
        hitSoundEffect.Play();
        playerHealth -= damage;
        UpdateHealth();
        if (!isAlive())
        {
            GameOverUI.SetActive(true);
            GameObject.Find("Character").GetComponent<HorizontalController>().enabled = false;
            GameObject.Find("Character").GetComponent<Rigidbody2D>().velocity.Set(0.0f, 0.0f);
            GameObject.Find("BG Music").GetComponent<AudioSource>().pitch = 0.5f;
            StartCoroutine(RestartGame());
        }
        else
        {
            GameOverUI.SetActive(false);
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(0);
    }
}
