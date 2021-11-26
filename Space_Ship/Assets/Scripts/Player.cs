using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D riplayer;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        riplayer = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("right"))
        {
            riplayer.velocity = new Vector2 (6, 0);
            //riplayer.AddForce(new Vector2(3,0));
            sprite.flipX = false;
            return;
        }
        if(Input.GetKey("left")) 
        {
            // riplayer.AddForce(new Vector2(-3,0));
            riplayer.velocity = new Vector2 (-6, 0);
            sprite.flipX = true;
            return;
        }
        if(Input.GetKey("up")) 
        {
            // if(transform.position.y  < 3.0f)
            // {
            //     riplayer.velocity = new Vector2(0, 3);
            //     return;
            // }
            StartCoroutine(Jump());
        }
    }
    // void OnCollisionEnter2D(Collision2D other) {

    // }
    IEnumerator Jump() {
        riplayer.velocity = new Vector2(0, 3);
        yield return new WaitForSeconds(2f);

    }
}
