using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform character;
    public float offset;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = character.position.x - transform.position.x;
        if(Mathf.Abs(x) > offset)
        {
            transform.position = new Vector3(character.position.x - Mathf.Sign(x) * (offset), transform.position.y, transform.position.z);
        }
        
    }
}
