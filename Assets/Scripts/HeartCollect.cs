using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    private HealthController healthController;
    public AudioSource heartPickupSoundEffect;

    private void Start()
    {
        healthController = GetComponent<HealthController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Health")
        {
            if(healthController.playerHealth < healthController.maxHealth)
            {
                healthController.playerHealth += 1;
                heartPickupSoundEffect.Play();
                Destroy(collision.gameObject);
            }
        }
    }
}
