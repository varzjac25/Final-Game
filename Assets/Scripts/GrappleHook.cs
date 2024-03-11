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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, -100);
        grapplerStick = false;
        grappleActive = false;
        frozen = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        grapplerEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!grapplerStick)
        {
            transform.position = new Vector2(Player.transform.position.x, transform.position.y);
        }
        if (transform.position.y - 0.5 < Player.transform.position.y && grapplerStick)
        {
            grappleActive = false;
            grapplerStick = false;
            gameObject.GetComponent<Renderer>().enabled = false;
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
