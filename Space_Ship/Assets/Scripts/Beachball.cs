using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beachball : MonoBehaviour
{
    Vector2 begin;
    Rigidbody2D riball;
    // Start is called before the first frame update
    void Start()
    {
     begin = transform.position;   
     riball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3,5));
        if(other.gameObject.name == "brick") 
        {
            transform.position = begin;
            riball.velocity = Vector2.zero;
            riball.isKinematic = true;
            StartCoroutine(SleepForNextTurn());
        }
    }
    IEnumerator SleepForNextTurn() {
        yield return new WaitForSeconds(2f);
        riball.isKinematic = false;
    }
}
