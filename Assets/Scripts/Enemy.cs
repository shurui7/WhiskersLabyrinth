using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Animator anim;
    public int MaxHealth = 100;
    private int CurrentHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        anim.SetBool("IsDead", false);

    }

    public void TakeDamage (int damage) 
    {
        anim.SetBool("IsHurt", true);
        anim.SetTrigger("Hurt");
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) 
        {
            Die();
        }
    }
    void Die ()
    {
        anim.SetBool("IsDead", true);
        Debug.Log("Enemy Died");
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

}
