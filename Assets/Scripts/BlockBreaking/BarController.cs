using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BarController : MonoBehaviour
{
    [SerializeField] float minX = -1.8f;
    [SerializeField] float maxX = 1.8f;
    float posY;

    void Start()
    {
        posY = transform.position.y;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.x = Mathf.Clamp(worldPos.x, minX, maxX);
        worldPos.y = posY;
        worldPos.z = 0f;

        transform.position = worldPos;
    }
}
