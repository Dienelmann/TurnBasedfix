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

    private void Exp(GameObject target, float amount)
    {
        expbar.value += amount;
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
        }
    }

    public void Win()
    {
        if (enemyhealth.value == 0)
        {
            Exp(player, 5);
        }
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1);

        int random = 0;
        random = Random.Range(1, 3);
        int randomattack = 0;
        randomattack = Random.Range(5, 16);
        int randomheal = 0;
        randomheal = Random.Range(3, 11);

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
        random = Random.Range(1, 3);
        int randomattack = 0;
        randomattack = Random.Range(10, 21);
        int randomheal = 0;
        randomheal = Random.Range(5, 16);

        if (random <= 2)
        {
            Attack(enemy, randomattack);
        }
        else
        {
            Heal(player, randomheal);
        }
        
    }
}
