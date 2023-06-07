using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainningDummy : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

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
