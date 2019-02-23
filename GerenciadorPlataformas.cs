using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPlataformas : MonoBehaviour
{
    public Plataformas plataforma1;
    public Plataformas plataforma2;

    float tempoRestreamento = 0;

    void Start()
    {
        StartCoroutine(IntanciarPlataformas());
    }
    void Update()
    {
        tempoRestreamento += Time.deltaTime;
        if (tempoRestreamento >= 10)
        {
            RastrearPlataformas();
            tempoRestreamento = 0f;
        }
    }

    IEnumerator IntanciarPlataformas()
    {
        for (int i = 0; i < 10; i++)
        {
           Instantiate(plataforma1, new Vector3(-10,10,0),Quaternion.identity);
           Instantiate(plataforma2, new Vector3(-10, 10, 0), Quaternion.identity);
           yield return new  WaitForSeconds(1f);
        }
    } 
    //Rastrear plataformas e destroyr
    public void RastrearPlataformas()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Plataforma"))
        {
            var t = item.GetComponent<Plataformas>();
            if (t.Destruir)
                Destroy(item,10f);
        }
    }  
}
