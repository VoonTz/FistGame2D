using UnityEngine;

public class LuzControlador : MonoBehaviour
{
    // Referência para a Point Light
    public Light luzPonto;

    // Valores ajustáveis
    public float intensidade = 2f;
    public float alcance = 10f;

    void Start()
    {
        // Se não tiver atribuído no inspector, tenta pegar do mesmo GameObject
        if (luzPonto == null)
            luzPonto = GetComponent<Light>();
    }

    void Update()
    {
        // Controla a intensidade
        luzPonto.intensity = intensidade;

        // Controla o alcance
        luzPonto.range = alcance;
        luzPonto.range = Mathf.PingPong(Time.time * 2f, 100f) + 50f;
    }
}
