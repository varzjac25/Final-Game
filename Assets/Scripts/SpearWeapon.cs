using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject player;


    bool hasSpear = false;
    public int spearDuration = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        while (hasSpear)
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("Spear Weapon Active");
                gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpearCooldown());
            gameObject.SetActive(false);
            hasSpear = true;
            
        }
    }

    IEnumerator SpearCooldown()
    {
        yield return new WaitForSeconds(spearDuration);
        hasSpear = false;
    }
}
