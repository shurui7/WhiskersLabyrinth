using UnityEngine;

public class SignScript : MonoBehaviour
{
    [SerializeField] public GameObject popUpCanvas; // Drag your canvas object here in the inspector

    void Start()
    {
        // Disable the pop-up initially
        if (popUpCanvas != null)
        {
            popUpCanvas.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the pop-up
            if (popUpCanvas != null)
            {
                popUpCanvas.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the pop-up
            if (popUpCanvas != null)
            {
                popUpCanvas.SetActive(false);
            }
        }
    }
}
