using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirosCanhao : MonoBehaviour
{
    [SerializeField]
    private GameObject balaCanhao;
    [SerializeField]
    private Transform barrel;
    [SerializeField]
    private float force;
    [SerializeField]
    private float attackRate;

    private float nextAttackTime = 0f;
    void Update()
    {
        if (Time.time >= nextAttackTime && !ReferenceController.Instance.isDead) 
        {
            Attack();
            nextAttackTime = Time.time +1f / attackRate;
        }
    }
    private void Attack()
    {
        GameObject bullet = Instantiate(balaCanhao, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody>().velocity = barrel.right * -1 * force * Time.deltaTime;
    }
}
