using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public BoxCollider2D boxCollider;

    public bool canMove;
    public SpriteRenderer textIndicator;

    public Animator anim;

    public int checker;

    public bool creepyGuy = false;
    public bool keyGet = false;

    public GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim.GetComponent<Animator>();
        canMove = true;
        textIndicator.enabled = false;
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
            anim.SetInteger("react", 0);
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            body.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);

            //Flip Sprite
            if (horizontalInput > 0.01f)
            {
                transform.localScale = Vector3.one;
            }

            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            anim.SetBool("move", horizontalInput != 0 || verticalInput != 0);
        }
        else
        {
            textIndicator.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interact")
        {
            textIndicator.enabled = true;
        }

        if (collision.gameObject.tag == "Nothing" && checker == 0)
        {
            manager.NothingEnding();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textIndicator.enabled = false;
    }

    public void StopMoving(int react)
    {
        body.linearVelocity = new Vector2(0, 0);
        anim.SetInteger("react", react);
    }

    public void ScreenTransition()
    {
        body.linearVelocity = new Vector2(0, 0);
        canMove = false;
        anim.SetBool("move", false);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        canMove = true;
    }
}
