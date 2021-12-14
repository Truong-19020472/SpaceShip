using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;   
public class MapController : MonoBehaviour
{
    public static int[,] map = new int[12,8]
    {   //x
        {0, 0, 0, 0, 0, 0, 0, 0},//y
        {0, 10, 2, 3, 1, 2, 3, 0},
        {0, 1, 8, 5, 6, 4, 10, 0},
        {0, 3, 7, 4, 5, 2, 4, 0},
        {0, 4, 6, 7, 9, 8, 2, 0},
        {0, 3, 10, 5, 8, 5, 9, 0},
        {0, 4, 3, 2, 8, 6, 7, 0},
        {0, 2, 4, 1, 6, 5, 8, 0},
        {0, 6, 7, 9, 3, 9, 1, 0},
        {0, 2, 1, 7, 8, 10, 2, 0},
        {0, 1, 3, 7, 3, 6, 5, 0},
        {0, 0, 0, 0, 0, 0, 0, 0}
    };
    //public GameObject prefabImage;
   // public GameObject CanvasUI;
    public static GameObject[,] pika = new GameObject[12,8];
    public List<GameObject> listImage = new List<GameObject>();
    
    void Awake() {
      SuperviseMap();
    }
   
    //float every_image = 35.0f;
    public GameObject parentInCanvas;
    void SuperviseMap() {
          for(int i = 0 ; i < 12 ; i++) 
        {
            for(int j = 0; j < 8; j++) 
            {
                pika[i,j] =  Instantiate(listImage[map[i,j]]) as GameObject;
                pika[i,j].transform.SetParent(parentInCanvas.transform, false);
            
                pika[i,j].transform.localPosition = new Vector3(i*45.0f, j*45.0f, 0);
                pika[i,j].GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            }
        }
    }
    
    
}
