using UnityEngine;
using UnityEngine.UI;

public class LookAtPlanet : MonoBehaviour
{
    public Text interactText;

    void Update()
    {
        interactText.gameObject.SetActive(true);
    }
}