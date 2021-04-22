using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerOneMovement : MonoBehaviour
{

    // Start is called before the first frame update
    public HealthPlayerTwo healthPlayerTwo;
    Rigidbody2D rb;
    public GameObject gamePausedUI;
    Animator anim;
    float attackRate = 2f;
    float nextAttackTime = 0f;
    int movementSpeed = 5, jumpSpeed = 20;
    float attackRange = 0.6f;
    public LayerMask playerTwo;
    bool moveLeft, moveRight, moveUp, onGround, doAttack,isGamePaused = true;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform attackPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        doAttack = false;
       
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveUp = true;
            
        }
       
         if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {

                
                gamePausedUI.SetActive(true);
                isGamePaused = false;
            }
            else
            {
                
                gamePausedUI.SetActive(false);
                isGamePaused = true;
            }
        }     

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                doAttack = true;
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }


    void FixedUpdate()
    {

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform"))
            || Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Floating Platform")))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

    
        if (moveLeft && onGround)
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            anim.SetInteger("AnimState", 2);
            anim.SetBool("Grounded", true);
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;

        }
        if (moveRight && onGround)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            anim.SetInteger("AnimState", 2);
            anim.SetBool("Grounded", true);
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }
        if (!moveLeft && !moveRight)
        {
            anim.SetInteger("AnimState", 0);
            anim.SetBool("Grounded", true);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (doAttack)
        {
            //Debug.Log("Did attack");
            anim.SetTrigger("Attack");
            //collects all the things this circle overlaps with
            Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
            if (hit.Length >= 2)
            {

                healthPlayerTwo.TakeDamage(20);
            }


        }
        if (moveUp && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            anim.SetFloat("AirSpeed", -1);
            anim.SetBool("Grounded", false);
        
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
