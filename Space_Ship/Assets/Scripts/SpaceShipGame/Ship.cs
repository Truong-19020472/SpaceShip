using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject explode;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right")){
            transform.position += new Vector3(speed, 0, 0)*Time.deltaTime;
            return;
        }
        if(Input.GetKey("left")) {
            transform.position += new Vector3(-speed, 0, 0)*Time.deltaTime;
            return;
        }
        if(Input.GetKey("up")) {
            transform.position += new Vector3(0, speed, 0)*Time.deltaTime;
            return;
        }
        if(Input.GetKey("down")) {
            transform.position += new Vector3(0, -speed, 0)*Time.deltaTime;
            return;
        }
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        GameObject boom = Instantiate(explode, transform.position, Quaternion.identity) as GameObject;
        Destroy(boom, 0.5f);
        Destroy(this.gameObject);
    }
}
