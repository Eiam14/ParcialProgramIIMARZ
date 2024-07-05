using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    public int damage = 10;  // Ajusta el daño causado por el asteroide al avión

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);

                // Puedes agregar efectos adicionales aquí si lo deseas
            }

            // Aquí puedes agregar lógica adicional cuando el asteroide impacta con el avión
            Destroy(gameObject);
        }
    }
}