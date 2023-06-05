using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private Rigidbody enemyRb;
    private Animator animator;
    private Transform player;
    private NavMeshAgent enemyNMA;

    private bool swordToutch;
    private int currentHealth;
   

    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyNMA = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        currentHealth = maxHealth;
        animator.SetBool("isWalking", true);
    }
    private void Update()
    {
        enemyNMA.SetDestination(player.position);

        if (swordToutch && ReferenceController.Instance.take)
        {
            TakeDamage();
        }
    }
    private void TakeDamage()
    {
        currentHealth -= ReferenceController.Instance.damageAttack;

       animator.SetBool("isHurt", true);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
    private void Die()
    {
        animator.SetBool("isDead", true);
        // exclude this Enemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            swordToutch = true;
            ReferenceController.Instance.triggerAttack = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sword")
        {
            swordToutch = false;
            ReferenceController.Instance.triggerAttack = false;
        }
    }
}
