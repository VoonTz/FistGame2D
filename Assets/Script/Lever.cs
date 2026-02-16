using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [Header("Configuração")]
    [SerializeField] private bool precisaInteragir = true;
    [SerializeField] private bool podeUsarUmaVez = true;

    [Header("Sprite")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteDesativado;
    [SerializeField] private Sprite spriteAtivado;

    public GameObject TeclaE;

    [Header("Evento ao Ativar")]
    public UnityEvent OnLeverActivated;

    private bool playerPerto = false;
    private bool ativada = false;

    

    private void Start()
    {
        if (spriteRenderer != null && spriteDesativado != null)
            spriteRenderer.sprite = spriteDesativado;
    }

    private void Update()
    {
        if (precisaInteragir && playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            Ativar();
        }
    }

    public void Ativar()
    {
        if (ativada && podeUsarUmaVez) return;

        ativada = true;

        //  troca o frame aqui
        if (spriteRenderer != null && spriteAtivado != null)
            spriteRenderer.sprite = spriteAtivado;

        OnLeverActivated?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerPerto = true;
            TeclaE.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerPerto = false;
            TeclaE.SetActive(false);
    }
}
