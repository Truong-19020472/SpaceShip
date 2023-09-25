using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] private HealBar healthBar;
    void Start()
    {
        healthBar.InitHealthBar(300);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthBar.ChangeLife(-30);
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            healthBar.ChangeLife(45);
            return;
        }
    }
}
