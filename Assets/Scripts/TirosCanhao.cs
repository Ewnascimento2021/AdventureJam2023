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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject bullet = Instantiate(balaCanhao, barrel.position, barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = barrel.right * -1 * force  * Time.deltaTime;
        }
    }
}
