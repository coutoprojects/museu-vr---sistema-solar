using UnityEngine;

public class OrbitLua : MonoBehaviour
{
    public Transform centro;

    public float velocidade = 25f;

    void Update()
    {
        transform.RotateAround(
            centro.position,
            Vector3.up,
            velocidade * Time.deltaTime
        );
    }
}