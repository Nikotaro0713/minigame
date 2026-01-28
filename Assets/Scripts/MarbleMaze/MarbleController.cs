using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hole"))
        {
            gameManager.GameOver();

        }

        if(collision.CompareTag("Goal"))
        {
            gameManager.GameClear();
        }
    }
}
