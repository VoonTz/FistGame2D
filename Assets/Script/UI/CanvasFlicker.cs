using UnityEngine;
using System.Collections;

public class CanvasFlicker : MonoBehaviour
{
    [Header("Referência")]
    [SerializeField] private Canvas targetCanvas;

    [Header("Tempo entre falhas")]
    [SerializeField] private float minInterval = 2f;
    [SerializeField] private float maxInterval = 5f;

    [Header("Configuração da piscada")]
    [SerializeField] private int minFlickers = 1;
    [SerializeField] private int maxFlickers = 3;
    [SerializeField] private float flickerOffTime = 0.05f;
    [SerializeField] private float flickerOnTime = 0.05f;

    private void Start()
    {
        if (targetCanvas == null)
            targetCanvas = GetComponent<Canvas>();

        StartCoroutine(FlickerRoutine());
    }

    private IEnumerator FlickerRoutine()
    {
        while (true)
        {
            // Espera um tempo aleatório antes de falhar
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            // Quantidade de piscadas
            int flickerCount = Random.Range(minFlickers, maxFlickers + 1);

            for (int i = 0; i < flickerCount; i++)
            {
                targetCanvas.enabled = false;
                yield return new WaitForSeconds(flickerOffTime);

                targetCanvas.enabled = true;
                yield return new WaitForSeconds(flickerOnTime);
            }
        }
    }
}
