using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//         if (collision.gameObject.name == "Player") {
//             SceneManager.LoadScene("GameOver");
//         }
//    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }    
}
