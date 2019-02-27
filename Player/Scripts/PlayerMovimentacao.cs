using UnityEngine;

public class PlayerMovimentacao : MonoBehaviour
{
    public DirecoesStatus direcoes;
    public Status status;

    //Variaveis referentes a gravidade
    private const float gravidadeOriginal = 1;
    private float gravidadeAtual;
    private readonly float gravidadeMaxima = 2;

    float rotacaoY = 0;

    public PlayerMovimentacao()
    {
        gravidadeAtual = gravidadeOriginal;
        direcoes = DirecoesStatus.parado;
        status = Status.noChao;
    }

    public Vector3 Direcao(float velocidade) => (Vector2.right * velocidade * Time.deltaTime);
    
    public Quaternion Rotacacao()
    {
        float ultimaRocatao;
        if (JoyDirecoes.ValorInput < 0)
            rotacaoY = 180;
        else if (JoyDirecoes.ValorInput > 0)
            rotacaoY = 0;
        else
        {
            ultimaRocatao = rotacaoY;
            rotacaoY = ultimaRocatao;
        }
 
        return Quaternion.Euler(0, rotacaoY, 0);
    }

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

    public float Gravidade(float gravidadeControle, Transform player, Transform sapatos)
    {
        if (!EstaNoChao(player, sapatos))
        {
            if (gravidadeAtual < gravidadeMaxima)
                gravidadeAtual += Time.deltaTime * gravidadeControle;
        }
        else
            gravidadeAtual = gravidadeOriginal;
      
        return gravidadeAtual;
    }

    public void SetarAnimacoes(Animator animePlayer)
    {
        float animeRun;
        bool animeIdl;
        if (JoyDirecoes.ValorInput > 0 || JoyDirecoes.ValorInput < 0)
        {
            animeRun = 1f;
            animeIdl = false;
        }
        else
        {
            animeRun = 0;
            animeIdl = true;
        }
        animePlayer.SetFloat("Run", animeRun);
        animePlayer.SetBool("Idl", animeIdl);
    }
}
