using UnityEngine;

public class SpaceRotation : MonoBehaviour
{
    public float speed = 0.2f;

    void Update()
    {
        transform.Rotate(
            Vector3.up *
            speed *
            Time.deltaTime
        );
    }
}