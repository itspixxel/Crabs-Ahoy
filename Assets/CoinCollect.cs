using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinsText;
    [SerializeField] private AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            collectSound.Play();
            Destroy(collision.gameObject);
        }
    }
    
}
