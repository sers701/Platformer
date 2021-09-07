using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private BoxCollider2D _objectCollider;
    [SerializeField] private LayerMask _groundLayerMask;

    public bool IsGrounded()
    {
            return RaycastFromCollider(-_objectCollider.bounds.extents.x) || RaycastFromCollider(_objectCollider.bounds.extents.x);      
    }

    private RaycastHit2D RaycastFromCollider(float horizontalOffset)
    {
        return Physics2D.Raycast(_objectCollider.bounds.center + horizontalOffset * Vector3.right, Vector2.down, _objectCollider.bounds.extents.y + _raycastDistance, _groundLayerMask);
    }
}
