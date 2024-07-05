using System.Collections;
using UnityEngine;

public class DisparoController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;  // Aqui se ajusta la velocidad de disparo
    public KeyCode shootKey = KeyCode.Space; // Tecla de disparo


    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // El proyectil debe de tener el script ProjeController adjunto
        ProjeController projectileController = projectile.GetComponent<ProjeController>();
        if (projectileController != null)
        {
            // Se le da la velocidad al proyectil
            projectileController.projectileSpeed = 10f; // Ajustes de velocidad
        }
    }
}
