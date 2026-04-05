using UnityEngine;

public class UI_Escada : MonoBehaviour
{
    public GameObject TeclaE;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeclaE.SetActive(true);
            
        }
    }
            

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeclaE.SetActive(false);
        }
            
    }

}
