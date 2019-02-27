using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Player : MonoBehaviour
{
    /// <summary>
    /// Clase que da suport ao Player com metodos de movimentacao,
    /// como Direcao, verifica se o player esta no chao e Rotacoes e Gravidade
    /// </summary>
    private PlayerMovimentacao playerMovimentacao;

    private Rigidbody2D Rb { get; set; }
    public Transform sapatos;

    //Variaveis referentes a movimentacao e pulo
    public float velocidade;
    public float forcaJump;

    //Variavel referente a gravidade
    public float gravidadeControle;

    void Start()
    {
        playerMovimentacao = new PlayerMovimentacao();
        Rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerMovimentacao.SetarAnimacoes(GetComponent<Animator>());
        Girar180();
        PlayerGravidade();
        Jump();
    }
    void FixedUpdate()
    {      
        Direcoes();             
    }

    void Direcoes()
    {        
        if (JoyDirecoes.ValorInput > 0 || Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(playerMovimentacao.Direcao(velocidade), Space.World);
            playerMovimentacao.direcoes = DirecoesStatus.direita;
        }
        else if (JoyDirecoes.ValorInput < 0 || Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(-playerMovimentacao.Direcao(velocidade),Space.World);
            playerMovimentacao.direcoes = DirecoesStatus.esquerda;
        }else
            playerMovimentacao.direcoes = DirecoesStatus.parado;
    }

    void Jump()
    {
        if ((JoyBotoes.ValorJump || Input.GetKeyDown(KeyCode.W )) && playerMovimentacao.EstaNoChao(transform,sapatos))
        {
            Rb.AddForce(Vector2.up * forcaJump, ForceMode2D.Force);
            playerMovimentacao.status = Status.pulando;
        }    
    }

    void Girar180()
    {
        transform.rotation = playerMovimentacao.Rotacacao();
    }

    void PlayerGravidade() => Rb.gravityScale = playerMovimentacao.Gravidade(gravidadeControle, transform, sapatos);      
}
