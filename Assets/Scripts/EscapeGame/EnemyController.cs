using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float maxPos = 2.0f;
    [SerializeField] private float minPos = -1.0f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float enemyMoveDir = Mathf.Sign(player.transform.position.x - transform.position.x);

        if ((transform.position.x > maxPos && enemyMoveDir > 0) ||
            (transform.position.x < minPos && enemyMoveDir < 0))
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(enemyMoveDir * moveSpeed, 0);
        }
    }
}
