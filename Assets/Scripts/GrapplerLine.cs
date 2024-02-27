using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplerLine : MonoBehaviour
{
    public GameObject Player;
    public GameObject grappler;
    public GrappleHook GrappleHook;
    public LineRenderer GrappleLine;
    bool grapplerStick;
    bool grappleActive;

    // Start is called before the first frame update
    void Start()
    {
        GrappleHook = grappler.GetComponent<GrappleHook>();
    }

    // Update is called once per frame
    void Update()
    {
        this.grapplerStick = GrappleHook.grapplerStick;
        this.grappleActive = GrappleHook.grappleActive;
        if (grapplerStick)
        {
            GrappleLine.SetPosition(0, new Vector3(Player.transform.position.x, Player.transform.position.y));
            GrappleLine.SetPosition(1, new Vector3(grappler.transform.position.x - 0.5f, grappler.transform.position.y + 0.5f));
        }   
        if (grapplerStick || grappleActive)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
