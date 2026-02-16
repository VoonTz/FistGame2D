using UnityEngine;
using UnityEngine.Rendering.Universal; // Importante para usar Light2D

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriterRenderer;
    [SerializeField] private Animator animator;

    private float xPosLastFrame;

    [Header("Wall")]
    public Transform wallCheck;
    public float wallCheckDistance = 0.2f;
    public LayerMask groundLayer;

    public float wallSlideSpeed = 2f;
    public float wallJumpForceX = 8f;
    public float wallJumpForceY = 7f;

    private bool isTouchingWall;
    private bool isWallSliding;


    [Header("Movimentação")]
    public float speed = 5f;
    public float jumpForce = 7f;

    [Header("Dash")]
    public float dashForce = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool isDashing = false;
    private bool canDash = true;

    [Header("Luz do jogador")]
    public Light2D playerLight;        // Referência à luz
    public float normalIntensity = 0.5f; // Intensidade padrão
    public float dashIntensity = 3f;   // Intensidade durante o dash

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Se o jogador tiver uma luz como filho, tenta achar automaticamente
        if (playerLight == null)
            playerLight = GetComponentInChildren<Light2D>();
    }

    void Update()
    {
        FlipCharacterX();
        Movement();
        JumpAnimation();
        CheckWall();
    }

    private void JumpAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetBool("IsJumping", true);
        else
            animator.SetBool("IsJumping", false);
    }

    private void FlipCharacterX()
    {
        if (transform.position.x > xPosLastFrame)
        {
            spriterRenderer.flipX = false;
        }
        else if (transform.position.x < xPosLastFrame)
        {
            spriterRenderer.flipX = true;
        }

        xPosLastFrame = transform.position.x;
    }
    private void Movement()
    {
        if (isDashing) return;

        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if(move != 0) 
            animator.SetBool("IsRunning", true);
        else
            animator.SetBool("IsRunning", false);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                isGrounded = false;
            }
            else if (isWallSliding)
            {
                float direction = spriterRenderer.flipX ? 1 : -1;
                rb.linearVelocity = new Vector2(direction * wallJumpForceX, wallJumpForceY);
                isWallSliding = false;
            }
        }


        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && move != 0)
        {
            StartCoroutine(Dash(move));
        }
    }

    private System.Collections.IEnumerator Dash(float direction)
    {
        canDash = false;
        isDashing = true;

        // Guarda a gravidade original
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(direction * dashForce, 0);

        //  Aumenta intensidade da luz
        if (playerLight != null)
            playerLight.intensity = dashIntensity;

        yield return new WaitForSeconds(dashDuration);

        // Volta a gravidade e a luz
        rb.gravityScale = originalGravity;
        isDashing = false;

        if (playerLight != null)
            playerLight.intensity = normalIntensity;

        // Espera cooldown
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
            isGrounded = true;
    }

    // Wall

    private void CheckWall()
    {
        isTouchingWall = Physics2D.Raycast(
            wallCheck.position,
            spriterRenderer.flipX ? Vector2.left : Vector2.right,
            wallCheckDistance,
            groundLayer
        );

        // Wall Slide
        if (isTouchingWall && !isGrounded && rb.linearVelocity.y < 0)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed);
        }
        else
        {
            isWallSliding = false;
        }
    }

}
