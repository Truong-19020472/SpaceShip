using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Menu : MonoBehaviour
{
    Rigidbody2D ri;
    // public GameObject tar1;
    // public GameObject tar2;
    bool isRight = true;
   
    //int dem = 1;
    void Start(){
        
        ri = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.Log("log normal");
        checkTurn();
        if(isRight == true ) {
        ri.velocity = new Vector2(2f,0);
        }
        else {
        ri.velocity = new Vector2(-2f,0);
        }
        

    }
    void checkTurn() {
        if(transform.localPosition.x > 2.4f) {
            isRight = false;
        }
        if(transform.localPosition.x < -2.4f){
            isRight = true;
        }
    }
    // Update is called once per frame
   
}
