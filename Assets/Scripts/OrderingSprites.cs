using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingSprites : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Atualiza a ordem da camada com base na posição Y
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -10);
    }
}
