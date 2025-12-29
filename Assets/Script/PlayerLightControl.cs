using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightControl : MonoBehaviour
{
    public Light2D playerLight;
    public Rigidbody2D rb;
    public float lightGrowSpeed = 2f;
    public float maxIntensity = 4f;
    public float minIntensity = 1.5f;

    public float mibombo = 1f;

    private bool isMoving;

    private void Start()
    {
        // Se não foi arrastado no inspector, tenta pegar automaticamente
        if (playerLight == null)
            playerLight = GetComponent<Light2D>();

        if (rb == null)
            rb = GetComponentInParent<Rigidbody2D>(); // assume que o script está em um filho do player

        // Começa apagada
        playerLight.intensity = 0f;
    }

    void Update()
    {
        // Verifica se o player está se movendo
        isMoving = Mathf.Abs(rb.linearVelocity.x) > 0.1f || Mathf.Abs(rb.linearVelocity.y) > 0.1f;

        if (isMoving)
        {
            // Pisca a luz quando o player se move
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            playerLight.intensity = Mathf.Lerp(playerLight.intensity, randomIntensity, Time.deltaTime * lightGrowSpeed);
        }
        else
        {
            // Suavemente desliga a luz quando para
            playerLight.intensity = Mathf.Lerp(playerLight.intensity, 0f, Time.deltaTime * lightGrowSpeed);
        }
    }
}
