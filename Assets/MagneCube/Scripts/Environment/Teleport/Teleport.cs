using UnityEngine;
using Zenject;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _exitPoint;
    [SerializeField] private Vector3 _exitDirection;

    private void OnTriggerEnter(Collider other)
    {
        TeleportToExitPoint(other);
    }

    private void TeleportToExitPoint(Collider collider) {
        if (collider.TryGetComponent(out Character character)) {
            Debug.Log($"Надо двигаться в сторону {_exitDirection} , это право? {_exitDirection == Vector3.right}");
            character.transform.position = _exitPoint.position;         
            character.ChangeDirection(_exitDirection);
        }
    }
}
