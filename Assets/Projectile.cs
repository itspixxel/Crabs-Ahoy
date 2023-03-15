using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Projectile : MonoBehaviour
{
    public Vector2 direction; // The direction for the projectile to move in
    public float speed = 5f; // The speed at which the projectile moves
    public Tilemap groundMask;

    private Rigidbody2D rb; // The projectile's rigidbody component

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a tilemap wall
        if (collision.gameObject.tag != "Projectile")
        {
            // Destroy the projectile gameobject
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Level")
        {
            // Destroy the projectile gameobject
            Destroy(gameObject);
        }
    }
}
