using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode right;
    [SerializeField]
    KeyCode down;
    [SerializeField]
    KeyCode e;
    [SerializeField]
    KeyCode q;
    [SerializeField]
    KeyCode r;
    [SerializeField]
    KeyCode t;

    [SerializeField]
    float jumpForce;
    [SerializeField]
    float speed;
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    bool doubleJumpActive;
    [SerializeField]
    bool dashActive;
    [SerializeField]
    bool chargeJumpActive;

    float xSpawn;
    float ySpawn;
    public bool direction;
    int deaths;

    public float timeHeld;
    bool isOnGround;
    bool doubleJump;
    int isDashing;
    int dashTimer;
    public int dashCool;
    int i = 0;
    Color dashColor;
    TrailRenderer myTrail;

    // Start is called before the first frame update
    void Start()
    {
        myTrail = gameObject.GetComponent<TrailRenderer>();
        direction = true;
        xSpawn = 0;
        ySpawn = 0;
        isOnGround = false;
        doubleJump = false;
        isDashing = 0;
        timeHeld = 0;
        dashTimer = 0;
        dashCool = 100;
        deaths = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
        }
        if (Input.GetKey(r))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (transform.position.y < -20)
        {
            transform.position = new Vector2(xSpawn, ySpawn);
            deaths++;
        }
        if (isDashing == 0)
        {
            if (chargeJumpActive)
            {
                if (Input.GetKey(up) && isOnGround)
                    timeHeld += Time.deltaTime;
            }
            
            if (Input.GetKeyUp(up) && (isOnGround))
            {
                if (timeHeld > 0.9)
                    timeHeld = 0.9f;
                if (timeHeld < 0.5)
                    timeHeld = 0.5f;
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce * timeHeld, ForceMode2D.Impulse);
                timeHeld = 0;
            }
            else if (!isOnGround)
            {
                timeHeld = 0;
            }
            if (Input.GetKeyDown(up) && (doubleJump))
            {
                GetComponent<Rigidbody2D>().velocity *= 0.1f;
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce * 0.6f, ForceMode2D.Impulse);
                doubleJump = false;
            }
            if (dashActive)
            {
                if (Input.GetKeyDown(e))
                {
                    isDashing = 2;
                }
                if (Input.GetKeyDown(q))
                {
                    isDashing = 1;
                }
            }
        }
        if (isDashing != 0)
        {
            dashColor = new Color(100, 100, 0);
            myTrail.startColor = dashColor;
        }
        else
        {
            dashColor = new Color(255, 255, 255);
            myTrail.startColor = dashColor;
        }
    }

    private void FixedUpdate()
    {
        if (dashActive)
        {
            dashCool++;
            if (dashCool < 100)
            {
                isDashing = 0;
            }
            if (dashCool > 100)
            {
                dashCool = 100;
            }
        }
            if (isDashing == 0)
            {
                if (Input.GetKey(left))
                {
                    direction = false;
                    transform.Translate(Vector2.left * speed);
                }
                if (Input.GetKey(right))
                {
                    direction = true;
                    transform.Translate(Vector2.right * speed);
                }
            }
            else if (isDashing == 1)
            {
                dashTimer++;

                transform.Translate(Vector2.left * dashSpeed);
                if (dashTimer > 8)
                {
                    isDashing = 0;
                    dashTimer = 0;
                    dashCool = 0;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
            else
            {
                dashTimer++;
                transform.Translate(Vector2.right * dashSpeed);
                if (dashTimer > 8)
                {
                    isDashing = 0;
                    dashTimer = 0;
                    dashCool = 0;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
        if (collision.gameObject.CompareTag("Killzone"))
        {
            transform.position = new Vector2(xSpawn, ySpawn);
            deaths++;
        }
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            isOnGround = false;
            xSpawn = collision.transform.position.x;
            ySpawn = collision.transform.position.y + 10;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            if (doubleJumpActive)
                doubleJump = true;
        }
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            isOnGround = false;
            if (doubleJumpActive)
                doubleJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Slowzone"))
        {
            speed *= 0.5f;
        }
        if (collide.gameObject.CompareTag("Speedzone"))
        {
            speed *= 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Slowzone"))
        {
            speed *= 2;
        }
        if (collide.gameObject.CompareTag("Speedzone"))
        {
            speed *= 0.5f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = false;
        }
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            isOnGround = true;
            doubleJump = false;
        }
    }
}
