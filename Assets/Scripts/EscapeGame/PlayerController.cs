using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private float moveSpeed = 4.0f;
    [SerializeField] private float jumpForce = 10.0f;
    private Rigidbody2D rb;
    [SerializeField] private int maxJumpCount = 2;
    private int jumpCount = 0;
    private float moveDir;

    private int keyCount = 0;
    [SerializeField] private int maxKeyCount = 2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDir = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Ú’n–Ê‚ª‚Ù‚Ú^‰º‚Ìê‡‚Ì‚Ý’…’n‚Æ‚Ý‚È‚·
                if (contact.normal.y > 0.5f)
                {
                    jumpCount = 0;
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Key"))
        {
            keyCount++;
            collision.gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Goal") && keyCount >= maxKeyCount)
        {
            gameManager.GameClear();
        }
    }
}
