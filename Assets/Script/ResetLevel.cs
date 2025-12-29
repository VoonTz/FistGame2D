using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    IEnumerator DelayComParametro(float tempo, int valor)
    {
        yield return new WaitForSeconds(tempo);
        Debug.Log("Valor recebido: " + valor);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(DelayComParametro(10f, 1000));
        if (other.CompareTag("Player"))
        {
            // Recarrega a cena atual
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}

