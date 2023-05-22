using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private Slider playerhealth = null;
    [SerializeField] private Slider enemyhealth = null;
    [SerializeField] private Button AttackBtn = null;
    [SerializeField] private Button HealBtn = null;
    [SerializeField] private Slider expbar = null;
    [SerializeField] private EnemySpawner enemySpawner;
    int randomattack = 0;
    int randomheal = 0;
    public int Exp = 50;
    public Text levelText;
    public int minattack = 10;
    public int maxattack = 21;
    public int minheal = 5;
    public int maxheal = 16;
    private int eminattack = 5;
    private int emaxattack = 16;
    private int eminheal = 5;
    private int emaxheal = 11;
    private int currentmaxHp = 100;

    private bool isPlayerTurn = true;

    private void Attack(GameObject target, float damage)
    {
        if (target == enemy)
        {
            enemyhealth.value -= damage;
        }
        else
        {
            playerhealth.value -= damage;
        }
        
        ChangeTurn();
    }

    private void Heal(GameObject target, float amount)
    {
        if (target == enemy)
        {
            enemyhealth.value += amount;
        }
        else
        {
            playerhealth.value += amount;
        }
        
        ChangeTurn();
    }

    

    public void BtnAttack()
    {
        Attack(enemy, 10);
    }

    public void BtnHeal()
    {
        Heal(player, 5);
    }

    private void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        if (!isPlayerTurn)
        {
            AttackBtn.interactable = false;
            HealBtn.interactable = false;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            
            StartCoroutine(PlayerTurn());
            if (enemyhealth.value <= 0)
            {
                expbar.value += Exp;
                if (expbar.value >= expbar.maxValue)
                {
                    expbar.value = 0;
                    LevelUp();
                    SetLevelNumber(LevelNumber: +1);
                    expbar.maxValue *= 1.5f;
                }
                if (enemySpawner.enemys.Count > 0)
                {
                    Destroy(enemySpawner.enemys[0]); 
                }
                print("You won the Fight");
                enemyhealth.value = currentmaxHp;
                

                
                enemySpawner.RefillSpawn();
                

                
                
            }
            
        }
    }

    private void LevelUp()
    {
        refillhealth();
        minattack += 5;
        maxattack *= 2;
        minheal += 5;
        maxheal *= 2;
        playerhealth.maxValue += 50;
        
    }

    private void refillhealth()
    {
        
        playerhealth.value = currentmaxHp;
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1);

        int random = 0;
        random = Random.Range(1, 5);
        randomattack = Random.Range(eminattack, emaxattack);
        randomheal = Random.Range(eminheal, emaxheal);

        if (random <= 2)
        {
           Attack(player, randomattack); 
        }
        else
        {
            Heal(enemy, randomheal);
        }

    }

    private IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(1);

        int random = 0;
        random = Random.Range(1, 5);
        randomattack = Random.Range(minattack, maxattack);
        randomheal = Random.Range(minheal, maxheal);

        if (random <= 2)
        {
            Attack(enemy, randomattack);
        }
        else
        {
            Heal(player, randomheal);
        }
        
    }
    
    private void SetLevelNumber(int LevelNumber)
    {
        levelText.text = "LEVEL: " + (LevelNumber ++);
    }
}
