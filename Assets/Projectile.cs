using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Projectile : MonoBehaviour
{
    public Vector2 direction; // The direction for the projectile to move in
    public float speed = 5f; // The speed at which the projectile moves
    public int damageAmount;

    private Rigidbody2D rb; // The projectile's rigidbody component
    private HealthController healthController;

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 move = direction * speed;
        transform.position = new Vector2(transform.position.x + move.x * Time.deltaTime, transform.position.y + move.y * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "Player")
        {
            // Destroy the projectile gameobject
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Level")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<HealthController>() != null)
            {
                Debug.Log("Slay");
                Destroy(gameObject);
                collision.gameObject.GetComponent<HealthController>().TakeDamage(damageAmount);
            }
        }
    }
}
