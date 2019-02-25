using System;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    private bool posicaoGeradaComSuscesso = false;
    private bool podeGerarPosicao = true;

    public bool Destruir { get; private set; } = false;

    public string NumeroPlatafoma => $"Plataforma{PlataformaSuport.NPlataforma.ToString()}";
    public string TagPlataforma => $"P{GerenciadorPlataformas.NumTagPlataforma}";

    private Transform l1;
    private Transform l2;

    public void Start()
    {
        l1 = GameObject.Find("L1").transform;
        l2 = GameObject.Find("L2").transform;

        if (l1 == null || l2 == null)
            Debug.Log("Adicionar l1 e l2 Por favor!");

        Debug.Log(NumeroPlatafoma);
        Debug.Log(TagPlataforma);
    }
    void Update()
    {
        if (podeGerarPosicao == true)
            PlataformaSuport.GerarPosicao(l1,l2,transform);

        if (posicaoGeradaComSuscesso == false)         
            GeradarPlataforma();
    }

    public void GeradarPlataforma()
    {
        transform.position = new Vector2(PlataformaSuport.PositionX, PlataformaSuport.PositionY);
        
        podeGerarPosicao = false;
        posicaoGeradaComSuscesso = true;

        PlataformaSuport.listPlataformas.Add(new Vector2(PlataformaSuport.PositionX, PlataformaSuport.PositionY));
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target")
            Destruir = true;
    }
}
