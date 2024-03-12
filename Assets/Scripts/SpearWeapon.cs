    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    KeyCode spearKey;

    bool hasSpear = false;
    bool goUp = false;
    bool floating = true;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (floating) {
            if (gameObject.transform.position.y >= -2.50) {
                goUp = false;
            }
            else if (gameObject.transform.position.y <= -3.0f) {
            goUp = true;
            }
            if (goUp) {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.015f);
            }
            else if (!goUp) {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.015f);
            }
        }
        
        



        if (hasSpear)
        {
            if (Input.GetKey(spearKey))
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                gameObject.GetComponent<Renderer>().enabled = true;
                transform.position = new Vector2(player.transform.position.x + 1.1f, player.transform.position.y + 0.05f);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                //Debug.Log("Spear Weapon Initiated");
                //transform.position = new Vector2(player.transform.position.x + 1.1f, player.transform.position.y + 0.05f);
                //gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasSpear = true;
            transform.position = new Vector2(0, -1000);
            gameObject.GetComponent<Renderer>().enabled = false;
            transform.eulerAngles = new Vector2(0, 0);
            floating = false;
        }
    }
}
