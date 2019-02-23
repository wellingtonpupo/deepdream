using System;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    private bool posicaoGeradaComSuscesso = false;
    private bool podeGerarPosicao = true;

    public bool Destruir { get; private set; } = false;

    private Transform l1;
    private Transform l2;

    public void Start()
    {
        Debug.Log(transform.localScale.x);
        l1 = GameObject.Find("L1").transform;
        l2 = GameObject.Find("L2").transform;

        if (l1 == null || l2 == null)
            Debug.Log("Adicionar l1 e l2 Por favor!");

    }
    void Update()
    {
        if (podeGerarPosicao == true)
            PlataformaSuport.GerarPosicao();

        if (posicaoGeradaComSuscesso == false)         
            GeradarPlataforma();

      //  Debug.Log(transform.position);
      //  Debug.Log("pOY" + PlataformaSuport.PositionY);
    }

    public void GeradarPlataforma()
    {
        transform.position = new Vector2(PosicaoX(), PlataformaSuport.PositionY);
        
        podeGerarPosicao = false;
        posicaoGeradaComSuscesso = true;
        PlataformaSuport.PosicoesPlataformas.Add(new Vector2(0, PlataformaSuport.PositionY));
    }
    public float PosicaoX()
    {
        return UnityEngine.Random.Range(l1.position.x + (transform.localScale.x /2), l2.position.x - (transform.localScale.x/2));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destruir = true;
            Debug.Log("Destruir:" + Destruir);
        }
    }
}
