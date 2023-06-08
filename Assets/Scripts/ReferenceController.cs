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

    // Player esta atacando
    public bool isAttack;

    // Espada esta tocando o Enemy
    public bool triggerAttack;

    // Dado atual de Ataque
    public int damageAttack = 1;

    // Confirmado o dano ao Enemy
    public bool take;

    // Confirmação do status de vivo ou morto do Player
    public bool isDead;

    // Portal collider para iniciar o ataque dos canhoes
    public bool startCanhao;

    // Contados de coletaveis
    public int collectibles;

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
