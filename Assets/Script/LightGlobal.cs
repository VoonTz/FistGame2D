using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightGlobal : MonoBehaviour
{
    public Light2D luz;
    public float ligar;

    void Start()
    {
        if (luz == null)
        {
            luz = GetComponent<Light2D>();
        } 
    }

    private void Update()
    {
        if(ligar == 0)
        {
            luz.intensity = 0.4f;
        }
        else
        {
            luz.intensity = 0;
        }
    }
}
