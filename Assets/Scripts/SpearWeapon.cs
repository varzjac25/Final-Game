    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    bool hasSpear = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasSpear)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
