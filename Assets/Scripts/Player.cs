using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public BoxCollider2D boxCollider;

    public bool canMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            body.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        }
    }

    public void StopMoving()
    {
        body.linearVelocity = new Vector2(0, 0);
    }
}
