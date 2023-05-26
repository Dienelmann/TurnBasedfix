using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    
    private GameController gamecontroller;
    public Animator animator;

    public void Attacking()
    {
        animator.SetBool("Attack", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Hurt", false);
        
    }

    public void Hurting()
    {
        animator.SetBool("Hurt", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Attack", false);
        
    }

    public void Idleing()
    {
        animator.SetBool("Hurt", false);
        animator.SetBool("Idle", true);
        animator.SetBool("Attack", false);
    }
    
    
    
    
}
