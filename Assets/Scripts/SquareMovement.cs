using System.Collections;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{

    public float horForce = 100;
    public float jumpForce = 0.3f;
    public float maxHorSpeed = 10;

    private float horIn;
    private float tempVelocityX;

    // [SerializeField] private float dashCooldown = 2;
    // [SerializeField] private float nextDashTime = 0;
    // [SerializeField] private float dashSpeed = 1;
    // [SerializeField] private float maxDashSpeed = 30;


    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private LayerMask platformLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horIn = Input.GetAxisRaw("Horizontal");
        tempVelocityX = rb.velocity.x;
    }

    void FixedUpdate() 
    {
        // jump mechanic 
        if (isGrounded() && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            SoundManager.PlaySound("jumpland");
        }

        // if (Time.time > nextDashTime)
        // {
        //     if (Input.GetKey(KeyCode.LeftShift))
        //     {
        //         rb.AddForce(new Vector2(Mathf.Sign(tempVelocity.x) * dashSpeed, 0), ForceMode2D.Impulse);
        //         // rb.AddForce(new Vector2(horizontalSpeed * dashSpeed, 0));
        //         if (Mathf.Abs(tempVelocity.x) > maxDashSpeed)
        //         {
        //             rb.velocity = (new Vector2(tempVelocity.x * 0.5f, tempVelocity.y));
        //         }
        //         nextDashTime = Time.time + dashCooldown;
        //     }
        // }
 

        // NEW hor movement
        if (Mathf.Abs(horIn) > 0)
        {
            rb.AddForce(new Vector2(horIn * horForce, 0));
            if (Mathf.Abs(rb.velocity.x) > maxHorSpeed)
            {
                rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxHorSpeed, maxHorSpeed), rb.velocity.y);
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 0f)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private bool isGrounded()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + extraHeightText), Vector2.right * (bc.bounds.extents.x + extraHeightText), rayColor);
        return raycastHit.collider != null;
    }
}
