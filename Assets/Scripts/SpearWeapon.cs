using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject equipedSpear;

    bool hasSpear = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        equipedSpear.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        while (hasSpear)
        {
            equipedSpear.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            hasSpear = true;
            
        }
    }
}
