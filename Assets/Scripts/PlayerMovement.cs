using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("GroundCheck")]
    public float playerHeight;
    bool grounded;
    public float stepHeight = 0.4f;
    public float stepSmooth = 10f;
    public LayerMask whatIsGround;

    public float radius = 0.5f;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    //Хотел добавить кратность гравитации
    //public float landingGravityMultiplier = 35;

    Vector3 moveDirection;
    public Transform feetPoint;
    Rigidbody rb;
    void StepClimb()
    {
        Vector3 origin = feetPoint.position + Vector3.up * 0.1f;

        Vector3 forward = orientation.forward;
        Vector3 right = orientation.right;

        Vector3[] dirs =
        {
        forward,
        -forward,
        right,
        -right,
        (forward + right).normalized,
        (forward - right).normalized,
        (-forward + right).normalized,
        (-forward - right).normalized
    };

        for (int i = 0; i < dirs.Length; i++)
        {
            Vector3 dir = dirs[i];
            dir.y = 0;
            dir.Normalize();

            float dist =
                (i < 2) ? 0.5f :
                (i < 4) ? 0.5f :
                            0.5f;

            RaycastHit lowerHit;
            RaycastHit upperHit;

            bool lower = Physics.Raycast(origin, dir, out lowerHit, dist);
            bool upper = Physics.Raycast(origin + Vector3.up * stepHeight, dir, out upperHit, dist);

            Debug.DrawRay(origin, dir * dist, Color.red);
            Debug.DrawRay(origin + Vector3.up * stepHeight, dir * dist, Color.green);

            if (lower && (!upper || upperHit.distance > dist * 0.8f))
            {
                rb.MovePosition(rb.position + Vector3.up * stepSmooth * Time.fixedDeltaTime);
                break;
            }
        }
    }

    private void Start()
    {
       readyToJump = true;
       rb = GetComponent<Rigidbody>();
       rb.freezeRotation = true;
    }
    private void Update()
    {
        //старая проверка grounded
        //grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        grounded = Physics.CheckCapsule(transform.position, transform.position - new Vector3(0, (playerHeight * 0.25f + 0.2f), 0), radius, whatIsGround);
        //Делаем трассировку луча видимой
        //Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f), Color.red);
        MyInput();
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }
    private void FixedUpdate()
    {
        StepClimb();
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
        // Здесь кратность гравитации сокращала бы время падения
        // rb.AddForce(Vector3.down * landingGravityMultiplier);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}