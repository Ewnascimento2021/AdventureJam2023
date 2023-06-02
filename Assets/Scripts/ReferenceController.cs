using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceController : MonoBehaviour
{

    static ReferenceController instance;
    public static ReferenceController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<ReferenceController>();
            return instance;
        }
    }

    public bool isAttack;
    public bool triggerAttack;
    public bool damageAttack;

    private void Update()
    {
        Debug.Log(triggerAttack);

        if (isAttack && triggerAttack)
        {
            Debug.Log("AI!");
        }
    }

   

}
