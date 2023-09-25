using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    //public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(transform.gameObject);
    }
    void MoveObject(GameObject a)
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // riplayer.velocity = new Vector2 (6, 0);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x + velocity*Time.deltaTime, leftX, rightX), transform.position.y, 0);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x + velocity * Time.deltaTime, leftX, rightX), transform.position.y, 0);
            transform.DOMoveX(a.transform.position.x + 2f, 0.5f).SetEase(Ease.Linear);
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // riplayer.velocity = new Vector2 (-6, 0);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x - velocity * Time.deltaTime, leftX, rightX), transform.position.y, 0);
            transform.DOMoveX(a.transform.position.x - 2f, 0.5f).SetEase(Ease.Linear);
            return;
        }
    }
}
