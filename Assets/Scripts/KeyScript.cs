using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Make amountofkeys static so it persists across instances of the script
    public static int amountofkeys;

    void Start()
    {
        // You may want to initialize amountofkeys only once when the scene starts
        if (amountofkeys == 0)
        {
            amountofkeys = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            amountofkeys += 1;
            Debug.Log("Key has been taken. Total keys: " + amountofkeys);
        }
    }
}
