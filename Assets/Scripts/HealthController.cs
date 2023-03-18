using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;
    private Animator anim;

    [SerializeField] private Image[] hearts;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth)
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
        playerHealth -= damage;
        UpdateHealth();
        if (!isAlive())
        {
            SceneManager.LoadScene(0);
            //anim.SetBool("isAlive", false);
            //// Disable player movement or any other scripts that shouldn't run during death animation
            //StartCoroutine(LoadSceneAfterAnimation());
        }
    }

    //IEnumerator LoadSceneAfterAnimation()
    //{
    //    // Wait for the death animation to finish playing
    //    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

    //    // Load the scene with build index 0
    //    SceneManager.LoadScene(0);
    //}
}
