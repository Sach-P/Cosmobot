using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    SpriteRenderer sp;

    bool IsGrounded;
    bool doubleJump;

    [SerializeField]
    Transform groundCheck1;
    [SerializeField]
    Transform groundCheck2;
    [SerializeField]
    Transform groundCheck3;

    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float jumpHeight = 3f;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        if(Physics2D.Linecast(transform.position, groundCheck1.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheck3.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            IsGrounded = true;    
        }
        else
        {
            IsGrounded = false;
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigid.velocity = new Vector2(speed, rigid.velocity.y);           
        }

        else if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }

        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigid.velocity = new Vector2(-speed, rigid.velocity.y);           
        }

        else if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
        {      
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }

        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }


    }

    private void Update()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {           
            animator.Play("PlayerMR");

        }
 
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {         
            animator.Play("PlayerML");
        }

        else if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
        {
            animator.Play("PlayerIdleR");    
        }

        else if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
        {
            animator.Play("PlayerIdleL");  
        }
        




        if (Input.GetKeyDown("space"))
        {

            if (IsGrounded)
            {
                doubleJump = true;
                rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
            }
            else if (doubleJump)
            {
                doubleJump = false;
                rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);

            }

        }

    }

}

