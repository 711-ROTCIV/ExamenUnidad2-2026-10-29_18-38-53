using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoFisicas : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 movimientoInput;
    private Vector2 direccionActual = Vector2.zero; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    public void OnMovimiento(InputValue value)
    {
        movimientoInput = value.Get<Vector2>();

        
        Debug.Log("Tecla presionada: " + movimientoInput);
    }

    void Update()
    {
        
        if (movimientoInput.x != 0)
        {
            direccionActual = new Vector2(Mathf.Sign(movimientoInput.x), 0);
        }
        else if (movimientoInput.y != 0)
        {
            direccionActual = new Vector2(0, Mathf.Sign(movimientoInput.y));
        }

        
        if (direccionActual != Vector2.zero)
        {
            float angulo = Mathf.Atan2(direccionActual.y, direccionActual.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = direccionActual * velocidad;
    }
}