using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] public Transform attackPoint;
    [SerializeField] public float attackRange = 0.5f;
    [SerializeField] public LayerMask enemyLayers;

    public float attackRate = 2f;
    float nextAttackTime = 0;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        GetComponent<PlayerMovement>().SetIsAttacking(true);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }

        StartCoroutine(ResetAttackState());
    }

    IEnumerator ResetAttackState()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        GetComponent<PlayerMovement>().SetIsAttacking(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
