using UnityEngine;

public class UI_Escada : MonoBehaviour
{
    public GameObject TeclaE;
    public GameObject TeclaE2;
    public GameObject TeclaE3;

    private bool playerPerto = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerPerto = true;
        TeclaE.SetActive(true);
        TeclaE2.SetActive(true);
        TeclaE3.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerPerto = false;
        TeclaE.SetActive(false);
        TeclaE2.SetActive(false);
        TeclaE3.SetActive(false);
    }

}
