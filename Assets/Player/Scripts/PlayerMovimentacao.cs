using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimentacao : MonoBehaviour
{
    public DirecoesStatus direcoes;
    public Status status;
   
    public PlayerMovimentacao()
    {
        
        direcoes = DirecoesStatus.parado;
        status = Status.noChao;
    }

    public Vector3 Direcao(float velocidade) => (Vector2.right * velocidade * Time.deltaTime);
    public bool EstaNoChao(Transform player,Transform sapatos)
    {
        int layer = LayerMask.NameToLayer("Chao") * 32;
        bool estaNoChao = Physics2D.Linecast(player.position, sapatos.position, layer);

        if (estaNoChao)
            status = Status.noChao;
        else
            status = Status.pulando;     
        return estaNoChao;
    }
}
