using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        // Le damos velocidad inicial apenas aparece (Ajustado para Unity 6)
        rb.linearVelocity = transform.right * speed;

        // Destruir la bala tras 3 segundos para limpiar la escena
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // --- FILTRO DE COLISIONES ---
        // Si choca con el jugador o con el suelo, ignoramos el impacto
        if (hitInfo.CompareTag("Player") || hitInfo.name == "Suelo")
        {
            return; // Sale del método sin destruir la bala
        }

        // Si llega aquí, es que chocó con otra cosa (paredes, enemigos, etc.)
        Debug.Log("Impacto contra: " + hitInfo.name);
        Destroy(gameObject);
    }
}