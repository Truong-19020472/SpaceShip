using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explode;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-4,0);
        transform.localEulerAngles += new Vector3(0,0, 30)*Time.deltaTime;

    }
    void OnCollisionEnter2D(Collision2D other) {
        GameObject boom = Instantiate(explode, transform.position, Quaternion.identity) as GameObject;
        Destroy(boom, 0.5f);
        Destroy(this.gameObject);
    }
}
