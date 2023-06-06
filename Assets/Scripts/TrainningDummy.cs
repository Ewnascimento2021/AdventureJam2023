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
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (swordToutch && ReferenceController.Instance.take)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentHealth -= ReferenceController.Instance.damageAttack;

        animator.SetBool("isHurt", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            swordToutch = true;
            ReferenceController.Instance.triggerAttack = true;

            Debug.Log(swordToutch);
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
