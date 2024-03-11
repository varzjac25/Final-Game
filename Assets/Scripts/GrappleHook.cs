using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [SerializeField]
    KeyCode grapple;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode right;
    [SerializeField]
    GameObject player;
    [SerializeField]
    float grappleForce;
    public bool grappleActive;
    public GameObject Player;
    bool frozen;
    Vector2 frozenPos;
    public bool grapplerStick;
    public bool grapplerEnabled;
    int grapplerDirection;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, -100);
        grapplerStick = false;
        grappleActive = false;
        frozen = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        grapplerEnabled = false;
        grapplerDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (grapplerDirection == 1)
        {
            transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y);
        }
        else if (grapplerDirection == 2)
        {
            transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y);
        }
        if (transform.position.y - 0.5 < Player.transform.position.y && grapplerStick)
        {
            grappleActive = false;
            grapplerStick = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            grapplerDirection = 0;
        }
        if (frozen)
            transform.position = frozenPos;
        if (Input.GetKeyUp(grapple) && grapplerEnabled)
        {
            grappleActive = !grappleActive;
            frozen = false;
            if (grappleActive)
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                gameObject.GetComponent<Renderer>().enabled = true;
                transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.5f);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * grappleForce, ForceMode2D.Impulse);
                if (Input.GetKey(right))
                {
                    Debug.Log("right");
                    grapplerDirection = 1;
                }
                if (Input.GetKey(left))
                {
                    Debug.Log("left");
                    grapplerDirection = 2;
                }
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                grapplerStick = false;
            }
        }
        if (GetComponent<Rigidbody2D>().velocity.y < 0 && !frozen)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            grappleActive = false;
            grapplerStick = false;
            grapplerDirection = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            frozenPos = transform.position;
            frozen = true;
            grapplerStick = true;
            grapplerDirection = 0;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            grappleActive = false;
            grapplerStick = false;
        }
    }
}
