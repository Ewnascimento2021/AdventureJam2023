using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanhao : MonoBehaviour
{
    [SerializeField]
    private int myNumber;
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && myNumber == 1)
        {
            ReferenceController.Instance.startCanhao = true;
        }
        if (other.CompareTag ("Trap"))
        {
            Destroy(other.gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && myNumber == 2)
        {
            ReferenceController.Instance.startCanhao = false;
        }
    }


}
