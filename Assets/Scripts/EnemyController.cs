using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
