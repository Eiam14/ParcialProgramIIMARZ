using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjeController : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public int damage = 1;

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Este se encarga de verificar que si ha colisionado con un asteroide
        if (other.CompareTag("Asteroide"))
        {
            // Obtiene informacion de la salud del asteroide
            Health asteroidHealth = other.GetComponent<Health>();

            // Verificar si encontró el componente de salud
            if (asteroidHealth != null)
            {
                // Le hace daño al asteroide
                asteroidHealth.TakeDamage(damage);
            }

            // Se destrutye el proyectil al golpear al asteroide
            Destroy(gameObject);
        }
    }
}
