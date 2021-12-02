using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageG : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(football.isGoUp) {
            ball.AddForce(new Vector2(3,3), ForceMode2D.Force);
        }
        else ball.AddForce(new Vector2(-3,-3), ForceMode2D.Force);
    }
}
