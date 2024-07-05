using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideMov : MonoBehaviour
{
    private Transform player;
    public float speed = 5f;

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Ajusta la cantidad de daño según sea necesario
            }
        }
    }

    public void SetPlayer(Transform targetPlayer)
    {
        player = targetPlayer;
    }
}