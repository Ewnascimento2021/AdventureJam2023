using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    private Animator animator;
    private Transform player;
    private NavMeshAgent enemyNMA;

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private float enemySpeed;

    private int currentHealth;
   

    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyNMA = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        currentHealth = maxHealth;
        animator.SetBool("Walking", true);
    }
    private void Update()
    {
        enemyNMA.SetDestination(player.position);
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // play hurt animation;

        if (currentHealth <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        // die Animation;

        // exclude this Enemy;
    }
}
