using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float tankSpeed = 5f;
    [SerializeField] public float rotationSpeed = 200f;
    private float moveInput;
    private float turnInput;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        Vector2 moveDirection = transform.up * moveInput * tankSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
        float rotationAmount = -turnInput * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation + rotationAmount);
    }


}
