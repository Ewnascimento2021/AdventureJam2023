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
    public int damageAttack = 1;
    public bool take;
    public bool isDead;
    public bool startCanhao;
    


    private void Update()
    {
        if (isAttack && triggerAttack)
        {
            take = true;
        }
        else
        {
            take = false;
        }
    }

   

}
