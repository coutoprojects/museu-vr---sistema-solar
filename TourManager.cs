using System.Collections;
using UnityEngine;

public class TourManager : MonoBehaviour
{
    public Camera cam;

    public PlanetData[] planetas;

    public AudioSource narracao;

    // Rotação suave
    public float velocidadeRotacao = 1.0f;

    // Quanto MAIOR aqui, mais lenta a viagem
    public float suavidadeMovimento = 2.5f;

    private Vector3 velocidadeAtual;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        StartCoroutine(Tour());
    }

    IEnumerator Tour()
    {
        foreach (PlanetData planeta in planetas)
        {
            if (planeta == null)
                continue;

            if (planeta.pontoVisita == null)
                continue;

            Transform destino = planeta.pontoVisita;

            bool audioIniciado = false;

            // Movimento até o planeta
            while (
                Vector3.Distance(
                    cam.transform.position,
                    destino.position
                ) > 0.5f
            )
            {
                // Movimento cinematográfico suave
                cam.transform.position =
                    Vector3.SmoothDamp(
                        cam.transform.position,
                        destino.position,
                        ref velocidadeAtual,
                        suavidadeMovimento
                    );

                // Rotação suave olhando pro planeta
                Quaternion rotacaoDesejada =
                    Quaternion.LookRotation(
                        planeta.transform.position -
                        cam.transform.position
                    );

                cam.transform.rotation =
                    Quaternion.Slerp(
                        cam.transform.rotation,
                        rotacaoDesejada,
                        velocidadeRotacao * Time.deltaTime
                    );

                // Distância até o planeta
                float distancia =
                    Vector3.Distance(
                        cam.transform.position,
                        destino.position
                    );

                // Inicia áudio antes de chegar
                if (
                    distancia < 8f &&
                    !audioIniciado &&
                    planeta.audioNarracao != null
                )
                {
                    narracao.clip =
                        planeta.audioNarracao;

                    narracao.Play();

                    audioIniciado = true;
                }

                yield return null;
            }

            // Espera terminar o áudio
            if (planeta.audioNarracao != null)
            {
                yield return new WaitForSeconds(
                    planeta.audioNarracao.length -2
                );
            }
            else
            {
                yield return new WaitForSeconds(5f);
            }

            // Pequena pausa
            yield return new WaitForSeconds(0.5f);
        }
    }
}