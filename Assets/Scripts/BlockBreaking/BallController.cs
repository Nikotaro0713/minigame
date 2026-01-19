using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float firstForce = 100.0f;
    [SerializeField] GameManager gameManager;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.AddForce(Vector2.one * firstForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            gameManager.UnregisterBlock();
        }
        else if(collision.collider.CompareTag("Bottom"))
        {
            gameManager.GameOver();
        }
    }
}
