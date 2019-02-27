using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class PlataformaSuport
{
    public static List<Vector2> listPlataformas = new List<Vector2>();
    private static int nPlataforma;

    private const float distanciEntreAsPlataforma = 1.3f;

    public static float PositionY { get; private set; }
    public static float PositionX { get; private set; }


    public static void GerarPosicao(Transform l1, Transform l2, Transform transform)
    {
        if (listPlataformas.Count <= 0)
            listPlataformas.Add(new Vector2(0, 0));
        
        PositionY = UltimaPosicao() + distanciEntreAsPlataforma;
        PositionX = Random.Range(l1.position.x + (transform.localScale.x / 2), l2.position.x - (transform.localScale.x / 2));
    }

    public static float UltimaPosicao()
    {
        return listPlataformas.Last().y;
    }

    public static int NPlataforma
    {
        get => nPlataforma++;
    }
}
