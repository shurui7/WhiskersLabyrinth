using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Specify the name of the next scene you want to load
    public string nextSceneName;
    public int NeededAmountofKeys;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Update the amountofkeys variable inside OnTriggerEnter2D
            int amountofkeys = KeyScript.amountofkeys;

            if (amountofkeys == NeededAmountofKeys)
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.Log("Less than needed keys");
            }
        }
    }
}
