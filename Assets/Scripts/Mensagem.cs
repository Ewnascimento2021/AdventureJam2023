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
    private int falaAtual;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        switch (falaAtual)
        {
            case 0:
                if (Vector3.Distance(transform.position, jogador.transform.position) < distancia)
                {
                    texto.text = "Pressione (T) para conversar com Half";
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        falaAtual = 1;
                    }
                }
                break;
            case 1:
                texto.text = "Olá menina, seja bem vinda ao meu castelo, aqui eu cresci e aprendi tudo sobre magia.";

                break;

        }
    }


}
