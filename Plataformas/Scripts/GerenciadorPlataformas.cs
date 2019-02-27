using System.Collections;
using UnityEngine;

public class GerenciadorPlataformas : MonoBehaviour
{
    public Plataformas plataforma1;
    public Plataformas plataforma2;
    public static int NumTagPlataforma { get; private set; }
    float tempoRestreamento = 0;

    void Start()
    {
        StartCoroutine(IntanciarPlataformas());
    }
    void Update()
    {
        //-- A cada quanto tempo deve  executar o metodo  RastrearPlataformasEDestruir() --/
        tempoRestreamento += Time.deltaTime;
        if (tempoRestreamento >= 10)
        {
            RastrearPlataformasEDestruir();
            tempoRestreamento = 0f;
        }
    }

    //-- Instancia as platafomas de forma que nao fiquem em uma seguencia unica --//
    IEnumerator IntanciarPlataformas()
    {
        for (int i = 0; i < 10; i++)
        {
         int tipoDaPlatafoma = Random.Range(1, 3);

            if (tipoDaPlatafoma == 1)
            {
                Instantiate(plataforma1, new Vector3(-10, 10, 0), Quaternion.identity);
                NumTagPlataforma = 1;
            }
            if (tipoDaPlatafoma == 2)
            {
                Instantiate(plataforma2, new Vector3(-10, 10, 0), Quaternion.identity);
                NumTagPlataforma = 2;
            }

           yield return new  WaitForSeconds(1f);
        }
    }
    //-- Rastreia plataformas pelos objetos na cena que contem a tag especifica e destroi --//
    public void RastrearPlataformasEDestruir()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Plataforma"))
        {
            var t = item.GetComponent<Plataformas>();
            if (t.Destruir)
                Destroy(item,10f);
        }
    } 
}
