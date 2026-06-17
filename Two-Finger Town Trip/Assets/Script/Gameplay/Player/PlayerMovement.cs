using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    
    private Rigidbody2D rb;


    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (groundCheckPoint != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundRadius, groundLayer);
        }
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocityY > 0.01 || rb.linearVelocityY < 0.01)
        {
            rb.linearVelocityX = 0f;
        }
        
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!isGrounded) return;
        if (ctx.performed)
        {
            rb.linearVelocity = new Vector2(0, jumpForce);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(groundCheckPoint.position, groundRadius);
        }
    }
}
