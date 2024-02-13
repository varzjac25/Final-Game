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

    bool grappleActive;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(grapple))
        {
            grappleActive = !grappleActive;
            if (grappleActive)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
