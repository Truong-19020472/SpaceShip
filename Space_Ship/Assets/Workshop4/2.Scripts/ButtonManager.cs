using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Image img1;
    [SerializeField] private Image img2;
    public void LoadImage1()
    {
        img1.sprite = Resources.Load<Sprite>("Res1/cherryBomb");
    }
}
