using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private KnightAnimationController _knightAnimationController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _knightAnimationController.CoinCollected();
            Destroy(coin.gameObject);
        }
    }
}
