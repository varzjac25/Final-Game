    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    bool hasSpear = false;
    bool goUp = false;
    LineRenderer spearLine;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        spearLine = GetComponent<LineRenderer>();
        spearLine.material.SetColor("_Color", Color.white);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.y >= -2.50)
        {
            goUp = false;
        }
        else if (gameObject.transform.position.y <= -3.0f)
        {
            goUp = true;
        }

        if (goUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.015f);
        }
        else if (!goUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.015f);
        }
        



        if (hasSpear)
        {
            Debug.Log("Spear Weapon Initiated");
            transform.position = new Vector2(player.transform.position.x + 1.1f, player.transform.position.y + 0.05f);
            transform.Rotate(0, 0, 0);
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasSpear = true;
            transform.position = new Vector2(0, -1000);
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
