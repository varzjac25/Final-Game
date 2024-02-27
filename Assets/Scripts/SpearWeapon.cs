    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    KeyCode y;

    bool hasSpear = false;
    public int spearDuration = 50;

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
            
            if (Input.GetKeyDown(y))
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
            hasSpear = true;
            StartCoroutine(SpearCooldown());
            gameObject.SetActive(false);
            
        }
    }

    IEnumerator SpearCooldown()
    {
        yield return new WaitForSeconds(spearDuration);
        hasSpear = false;
    }
}
