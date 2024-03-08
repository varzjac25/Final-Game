using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplerLine : MonoBehaviour
{
    public GameObject Player;
    public GameObject grappler;
    public GrappleHook GrappleHook;
    LineRenderer GrappleLine;
    bool grapplerStick;
    bool grappleActive;

    // Start is called before the first frame update
    void Start()
    {
        GrappleHook = grappler.GetComponent<GrappleHook>();
        GrappleLine = GetComponent<LineRenderer>();
        GrappleLine.material.SetColor("_Color", Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        this.grapplerStick = GrappleHook.grapplerStick;
        this.grappleActive = GrappleHook.grappleActive;
        if (grapplerStick || grappleActive)
        {   
            GrappleLine.SetPosition(0, Player.transform.position);
            GrappleLine.SetPosition(1, grappler.transform.position);
            gameObject.GetComponent<Renderer>().enabled = true;
        }   
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
