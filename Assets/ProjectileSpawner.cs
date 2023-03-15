using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab to spawn
    public float spawnInterval = 3f; // The time between spawns

    private float timeSinceLastSpawn; // The time since the last spawn
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Increment the time since the last spawn
        timeSinceLastSpawn += Time.deltaTime;

        // If the time since the last spawn is greater than or equal to the spawn interval,
        // spawn a new projectile and reset the timer
        if (timeSinceLastSpawn >= spawnInterval)
        {
            anim.SetBool("isFiring", true);
            SpawnProjectile();
            anim.SetBool("isFiring", false);
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnProjectile()
    {
        // Instantiate a new projectile at the spawner's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
