using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySc : MonoBehaviour
{
    [SerializeField] public Slider enemyhaelth = null;

    private void Dead()
    {
        if (enemyhaelth.value == 0)
        {
            
        }
    }
}
