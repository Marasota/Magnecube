using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothing = 3f;
    [SerializeField] private Vector3 _rotationOffset;

    protected void Move(float deltaTime)
    {
        var nextPos = Vector3.Lerp(transform.position, _targetTransform.position + _offset, deltaTime * _smoothing);
        transform.position = nextPos;

        var targetRotation = Quaternion.LookRotation(_targetTransform.position - transform.position) * Quaternion.Euler(_rotationOffset);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, deltaTime * _smoothing);
    }
}
