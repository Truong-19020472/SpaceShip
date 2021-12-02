using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{

    Rigidbody2D riplayer;
    SpriteRenderer sprite;
    public float velocity;
    public float leftX;
    public float rightX;
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
            // riplayer.velocity = new Vector2 (6, 0);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x + velocity*Time.deltaTime, leftX, rightX), transform.position.y, 0);
            transform.DOJump(new Vector3(transform.position.x + 4, -3.16f, 0), 1, 2, 1).SetEase(Ease.Linear);
            sprite.flipX = false;
            return;
        }
        if(Input.GetKey("left")) 
        {
            // riplayer.velocity = new Vector2 (-6, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - velocity*Time.deltaTime, leftX, rightX), transform.position.y, 0);
            sprite.flipX = true;
            return;
        }
        if(Input.GetKey("up")) 
        {
            if(CanJump()) {
                Jump();
            }
        }
    }
    void Jump() {
        isGround = false;
        transform.DOMoveY(1f, 0.2f).SetEase(Ease.OutExpo).SetLoops(2, LoopType.Yoyo).OnComplete(SetGround);
    }
    bool isGround = true;
    bool CanJump() {
        return isGround;
    }
    void SetGround() {
        isGround = true;
    }
}
