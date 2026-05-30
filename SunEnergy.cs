using UnityEngine;

public class SunEnergy : MonoBehaviour
{
    public Material sunMaterial;

    public float minEmission = 1f;
    public float maxEmission = 2f;
    public float speed = 1f;

    void Update()
    {
        float emission = Mathf.Lerp(minEmission, maxEmission, (Mathf.Sin(Time.time * speed) + 1) / 2);

        sunMaterial.SetColor("_EmissionColor", Color.yellow * emission);
    }
}