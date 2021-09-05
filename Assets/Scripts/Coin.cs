using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<KnightAnimationController>(out KnightAnimationController knightAnimationController))
        {
            knightAnimationController.CoinCollected();
            Destroy(gameObject);
        }
    }
}
