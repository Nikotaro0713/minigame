using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float gravityPower = 1f;

    private void FixedUpdate()
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.W)) y = 1f;
        if (Input.GetKey(KeyCode.S)) y = -1f;
        if (Input.GetKey(KeyCode.A)) x = -1f;
        if (Input.GetKey(KeyCode.D)) x = 1f;

        Vector2 dir = new Vector2(x, y);
        if (dir.sqrMagnitude > 1f)
        {
            dir = dir.normalized;
        }

        Physics2D.gravity = dir * gravityPower;
    }
}
