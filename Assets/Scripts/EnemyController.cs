using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private float attackRate;

    [Range(1f, 10f)] public float distancia;

    private Rigidbody enemyRb;

    private Animator animator;
    private GameObject jogador;

    private bool acordei;
    private float nextAttackTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        jogador = GameObject.FindWithTag("Player");
        enemyRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, jogador.transform.position) < distancia)
        {
            acordei = true;
            animator.SetBool("Acordei", true);
        }

        if (acordei)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                //animator.SetBool("Attack", false);
                //animator.SetBool("Acordei", true);
            }
        }
    }
        private void Attack()
        {
            animator.SetBool("Acordei", false);
            animator.SetBool("Attack", true);
        }



        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Sword")
            {
                ReferenceController.Instance.triggerAttack = false;
            }
        }
    }
