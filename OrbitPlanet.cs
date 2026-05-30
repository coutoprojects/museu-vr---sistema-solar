using UnityEngine;

public class OrbitPlanet : MonoBehaviour
{
    public float orbitSpeed = 10f;

    public bool podeOrbitar = false;

    void Update()
    {
        if (!podeOrbitar)
            return;

        transform.Rotate(
            Vector3.up,
            orbitSpeed * Time.deltaTime,
            Space.World
        );
    }
}