using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private Vector3 destino;
    [SerializeField] private float velocidade = 2f;

    [Header("Luz")]
    [SerializeField] private GameObject luzObjeto; // arraste aqui sua luz

    private bool mover = false;

    public void AtivarMovimento()
    {
        mover = true;

        //  Liga a luz quando começar a mover
        if (luzObjeto != null)
            luzObjeto.SetActive(true);
    }

    private void Update()
    {
        if (!mover) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            destino,
            velocidade * Time.deltaTime
        );

        //  Se chegou no destino
        if (Vector3.Distance(transform.position, destino) < 0.01f)
        {
            mover = false;

            //  Desliga a luz quando parar
            if (luzObjeto != null)
                luzObjeto.SetActive(false);
        }
    }
}
