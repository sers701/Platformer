using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationKnightController
{
    public static class States
    {
        public const string IsWalking = "IsWalking";
        public const string CoinCollected = "CoinCollected";
    }
}

public class KnightAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void SwitchCharacterMoving(float horizontalDirection)
    {
        if (horizontalDirection > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool(AnimationKnightController.States.IsWalking, true);
        }
        else if (horizontalDirection < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool(AnimationKnightController.States.IsWalking, true);
        }
        else
        {
            _animator.SetBool(AnimationKnightController.States.IsWalking, false);
        }
    }

    public void CoinCollected()
    {
        _animator.SetTrigger(AnimationKnightController.States.CoinCollected);
    }
}