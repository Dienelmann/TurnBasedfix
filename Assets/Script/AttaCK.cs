using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttaCK: MonoBehaviour
{
    [SerializeField]  Button _AttaCK;
    public int EnemyHp = 10;
    public int PlayerHp = 10;
    
    void Start()
    {
        _AttaCK.onClick.AddListener(StartAttaCK);
        
        
    }

    public void StartAttaCK()
    {
        if (PlayerHp <= EnemyHp)
        {
            EnemyHp--;
            print(EnemyHp -1f);
            
        }
        else
        {
            PlayerHp --;
            print(PlayerHp -1f);
        }
    }
}