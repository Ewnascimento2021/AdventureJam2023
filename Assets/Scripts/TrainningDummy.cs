using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TrainningDummy : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private Transform collect;
    [SerializeField]
    private GameObject piece;
    [SerializeField]
    private float timeDelet;

    private Rigidbody enemyRb;
    private Animator animator;

    private bool swordToutch;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (swordToutch && ReferenceController.Instance.take)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        animator.SetBool("isHurt", true);
        GameObject d20 = Instantiate(piece, collect.position, collect.rotation);
        gameObject.GetComponent<Collider>().enabled = false;
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

