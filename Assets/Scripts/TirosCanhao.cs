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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject bullet = Instantiate(balaCanhao, barrel.position, barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = barrel.right * -1 * force  * Time.deltaTime;
        }
    }
}
