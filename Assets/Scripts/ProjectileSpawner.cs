using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab to spawn
    public float spawnInterval = 3f; // The time between spawns
    public Transform spawnPosition;

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
        // start the firing coroutine and reset the timer
        if (timeSinceLastSpawn >= spawnInterval)
        {
            StartCoroutine(FireProjectile());
            timeSinceLastSpawn = 0f;
        }
    }

    IEnumerator FireProjectile()
    {
        // Set isFiring to true
        anim.SetBool("isFiring", true);

        // Wait for the animation to finish
        yield return new WaitForSeconds(0.5f);

        // Set isFiring to false
        anim.SetBool("isFiring", false);

        // Spawn the projectile
        SpawnProjectile();
    }


    void SpawnProjectile()
    {
        // Instantiate a new projectile at the spawner's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition.position, spawnPosition.rotation);
    }
}
