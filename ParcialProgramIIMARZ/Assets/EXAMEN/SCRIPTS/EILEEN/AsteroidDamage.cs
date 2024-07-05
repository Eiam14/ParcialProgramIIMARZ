using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    public int damage = 10;  // Ajusta el da�o causado por el asteroide al avi�n

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);

                // Puedes agregar efectos adicionales aqu� si lo deseas
            }

            // Aqu� puedes agregar l�gica adicional cuando el asteroide impacta con el avi�n
            Destroy(gameObject);
        }
    }
}