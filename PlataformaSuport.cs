using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class PlataformaSuport
{
    public static List<Vector2> PosicoesPlataformas = new List<Vector2>();

    private const int Min = 2;
    private const int Max = 3;
    public static int PositionY { get; private set; }

    public static void GerarPosicao()
    {
        if (PosicoesPlataformas.Count <= 0)
            PosicoesPlataformas.Add(new Vector2(0, 1));

        PositionY = Random.Range(UltimaPosicao() + Min, UltimaPosicao() + Min + Max);
    }

    public static int UltimaPosicao()
    {
        return (int)PosicoesPlataformas.Last().y;
    }

}
