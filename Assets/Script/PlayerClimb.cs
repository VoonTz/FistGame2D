using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    public float climbSpeed = 3f;

    private bool isNearLadder = false;
    private bool isClimbing = false;

    private Rigidbody2D rb;
    private float verticalInput;

    [Header("TECLA E")]

    public GameObject TeclaE;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        if (isNearLadder && Input.GetKeyDown(KeyCode.E))
        {
            isClimbing = !isClimbing;

            if (isClimbing)
            {
                rb.gravityScale = 0;
                rb.linearVelocity = Vector2.zero;
            }
            else
            {
                rb.gravityScale = 1;
            }
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.linearVelocity = new Vector2(0, verticalInput * climbSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isNearLadder = true;
            TeclaE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isNearLadder = false;
            isClimbing = false;
            rb.gravityScale = 1;
            TeclaE.SetActive(false);
        }
    }
}