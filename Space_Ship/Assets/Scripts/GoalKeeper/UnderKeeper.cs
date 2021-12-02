using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    // Rigidbody2D riplayer;
    public float velocity;
    public float leftX;
    public float rightX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           if(Input.GetKey("right"))
        {
            // riplayer.velocity = new Vector2 (6, 0);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x + velocity*Time.deltaTime, leftX, rightX), transform.position.y, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + velocity*Time.deltaTime, leftX, rightX), transform.position.y, 0);
            return;
        }
        if(Input.GetKey("left")) 
        {
            // riplayer.velocity = new Vector2 (-6, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - velocity*Time.deltaTime, leftX, rightX), transform.position.y, 0);
            return;
        }
        if(Input.GetKey("up")) {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + velocity*Time.deltaTime, -3.56f, 2.62f), 0);
            return;
        }
        if(Input.GetKey("down")) {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - velocity*Time.deltaTime, -3.56f, 2.62f), 0);
            return;
        }
    }
}
