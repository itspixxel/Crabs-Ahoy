using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damageAmount;
    public Transform LevelStartPos;

    private HealthController healthController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<HealthController>() != null)
            {
                // Take damage
                collision.gameObject.GetComponent<HealthController>().TakeDamage(damageAmount);

                // Reset player to start
                collision.gameObject.transform.position = LevelStartPos.position;

                collision.gameObject.GetComponent<HorizontalController>().isGrounded = true;
            }
        }
    }
}
