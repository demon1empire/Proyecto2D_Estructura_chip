using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;

    [Header("Detección de Suelo")]
    public Transform detectorSuelo;
    public float radioDeteccion = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool tocandoSuelo;
    private float movimientoH;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimientoH = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && tocandoSuelo)
        {
            // Usamos linearVelocity que es lo nuevo de Unity 6
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimientoH * velocidad, rb.linearVelocity.y);
        tocandoSuelo = Physics2D.OverlapCircle(detectorSuelo.position, radioDeteccion, capaSuelo);
    }
}