using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObliquely : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explode;
    // int toadoX;
    void Start()
    {
        
        // toadoX = Random.Range(-3,-1); 
    }

    // Update is called once per frame
    void Update()
    {
        // transform.localPosition += new Vector3(-2.5f, -2, 0)*Time.deltaTime;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-3.5f,-2.5f,0);
        transform.localEulerAngles += new Vector3(0,0, 30)*Time.deltaTime;

    }
    void OnCollisionEnter2D(Collision2D other) {
        GameObject boom = Instantiate(explode, transform.position, Quaternion.identity) as GameObject;
        Destroy(boom, 0.5f);
        Destroy(this.gameObject);
    }
}
