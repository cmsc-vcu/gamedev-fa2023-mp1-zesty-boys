using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private int lemons = 0;

    [SerializeField] private Text lemonsText;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.CompareTag("Lemon"))
        {
            Destroy(other.gameObject);
            lemons++;
            lemonsText.text = "Lemons: " + lemons;
        }
    }
}
