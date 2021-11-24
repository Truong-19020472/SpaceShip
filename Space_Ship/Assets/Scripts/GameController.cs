using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] stone;
    public GameObject ship;
    public Text text;
    // Start is called before the first frame update
    //private int number;
    void Start()
    {
        StartCoroutine(Create());
    }

    // Update is called once per frame
    void Update() {
        if(ship == null) {
            text.enabled = true;
        }
    }
    void CreateStone() {
        Instantiate(stone[Random.Range(0,2)], new Vector3(Random.Range(-8.3f, 8.3f), 6, 0), Quaternion.identity);
    }
    IEnumerator Create() {
        while(true) {
        yield return new WaitForSeconds(Random.Range(1,3));
        CreateStone();
        }
    }
    
}
