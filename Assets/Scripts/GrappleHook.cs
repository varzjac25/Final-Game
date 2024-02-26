using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [SerializeField]
    KeyCode grapple;
    [SerializeField]
    GameObject player;
    [SerializeField]
    float grappleForce;
    bool grappleActive;
    

    // Start is called before the first frame update
    void Start()
    {
        grappleActive = false;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(grapple))
        {
            grappleActive = !grappleActive;
            if (grappleActive)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                gameObject.GetComponent<Renderer>().enabled = true;
                transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.5f);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * grappleForce, ForceMode2D.Impulse);
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {

        }
    }
}
