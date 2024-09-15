using UnityEngine;

public class MovementHandler {
    private Transform _transform;
    private bool _isMoving = false;
    private Vector3 _direction;
    public bool IsMoving { get { return _isMoving; } }
    private Collider _hitCollider;

    public MovementHandler(Transform transform) { 
        _transform = transform;
    }
    public void Move() {
        if (_isMoving) {
            if (!CheckCollision())
            {
                _transform.Translate(_direction * GameConstants.PLAYER_SPEED * Time.deltaTime);
            }
            else EndMoving();
        }
    }
    public void StartMoving(Vector3 direction) {
        if (!_isMoving) {
            _direction = direction;
            _isMoving = true;
            Debug.Log($"CHARACTER MUST MOVE IN {direction}");
        }
    }
    public void EndMoving()
    {
        _isMoving = false;
    }
    bool CheckCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(_transform.position, _direction, out hit, GameConstants.RAY_DISTANCE))
        {
            if (hit.collider.CompareTag("Finish"))
            {
                Debug.Log($"WINNER-WINNER, CHICKEN DINNER!");
            }
            _hitCollider = hit.collider;
            return true;
        }
        return false;
    }
}
