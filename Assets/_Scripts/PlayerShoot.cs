using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;     // Aquí arrastraremos el FirePoint
    public GameObject bulletPrefab; // Aquí arrastraremos el Prefab de la bala

    void Update()
    {
        // Detecta si presionas el clic izquierdo o la tecla configurada como Fire1
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Esta línea "crea" la bala en el lugar y rotación del FirePoint
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}