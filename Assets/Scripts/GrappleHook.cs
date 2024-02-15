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
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(grapple))
        {
            Debug.Log("entered");
            if (grappleActive)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.6f);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * grappleForce, ForceMode2D.Impulse);
            }
            grappleActive = !grappleActive;
        }
    }
}
