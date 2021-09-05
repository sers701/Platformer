using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<KnightAnimationController>(out KnightAnimationController knightAnimationController))
        {
            knightAnimationController.CoinCollected();
            Destroy(gameObject);
        }
    }
}
