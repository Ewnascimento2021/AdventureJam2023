using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsTest : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            ReferenceController.Instance.triggerAttack = true;
            Debug.Log(ReferenceController.Instance.triggerAttack);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            ReferenceController.Instance.triggerAttack = false;
        }
    }


}
