using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mensagem : MonoBehaviour
{
    public TextMeshProUGUI texto;
    private GameObject jogador;
    [Range(1f, 10f)] public float distancia;

    private void Start()
    {
        texto.enabled = false;
        jogador = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, jogador.transform.position) < distancia)
        {
            texto.enabled = true;
        }
        else
        {
            texto.enabled = false;
        }
    }


}
