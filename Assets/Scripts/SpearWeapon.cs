    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    bool hasSpear = false;
    bool goUp = false;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.y >= -2.80)
        {
            goUp = false;
        }
        else if (gameObject.transform.position.y <= -3.25)
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
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Spear Weapon Active");

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasSpear = true;
            transform.position = new Vector2(0, -1000);
            Destroy(gameObject);
        }
    }
}
