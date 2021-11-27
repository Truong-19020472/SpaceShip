using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    SpriteRenderer m;
    Rigidbody2D ri;
    // public GameObject tar1;
    // public GameObject tar2;
    bool isRight = true;
    //int dem = 1;
    void Start(){
        m = GetComponent<SpriteRenderer>();
        ri = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.Log("log normal");
        checkTurn();
        if(isRight == true ) {
        ri.velocity = new Vector2(8.5f,0);
        m.flipX = false;
        }
        else {
        ri.velocity = new Vector2(-9f,0);
        m.flipX = true;
        }
        

    }
    void checkTurn() {
        if(transform.localPosition.x > 7.0f) {
            isRight = false;
        }
        if(transform.localPosition.x < 1.8f){
            isRight = true;
        }
    }
}
