using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UpKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    // public float leftX;
    // public float rightX;
    // public float speed;
    // bool isRight;

    // Rigidbody2D ri;
    public Transform[] path;
    Vector3[] way = new Vector3[2];
    void Awake() {
        way[0] = path[0].position;
        way[1] = path[1].position;
    }
    void Start()
    {
        transform.DOPath(way, 0.9f, PathType.Linear, PathMode.Full3D, 10, null).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
        // isRight = true;
        // ri = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // void Update()
    // {   
    //     CheckTurn();
    //     if(isRight){
            
    //     }
    // }
    //  void CheckTurn() {
    //     if(transform.localPosition.x > 1.5f) {
    //         isRight = false;
    //     }
    //     if(transform.localPosition.x < -1.5f){
    //         isRight = true;
    //     }
    // }
}
