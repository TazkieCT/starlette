using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 1;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;
    private Animator animator;
    private Vector2 lastDirection;
    private bool isMoving; 

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        velocity = new Vector2(speed, speed);
        characterBody = GetComponent<Rigidbody2D>();
        lastDirection = Vector2.down;
        isMoving = false; 
    }

    void Update()
    {
        inputMovement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        isMoving = inputMovement != Vector2.zero;
        animator.SetBool("isMoving", isMoving); 

        if (isMoving)
        {
            lastDirection = inputMovement.normalized;
            animator.SetFloat("x", inputMovement.x);
            animator.SetFloat("y", inputMovement.y);
        }

        animator.SetFloat("lastX", lastDirection.x);
        animator.SetFloat("lastY", lastDirection.y);
    }

    private void FixedUpdate()
    {
        Vector2 delta = inputMovement * velocity * Time.deltaTime;
        characterBody.MovePosition(characterBody.position + delta);
    }
}