using UnityEngine;

public class MovementHandler {
    private Rigidbody _rb;
    private bool _isMoving = false;
    public bool IsMoving { get { return _isMoving; } }
    private Vector3 _direction;
  
    public MovementHandler(Rigidbody rb) { 
        _rb = rb;
    }
    public void Move() {
        if (_isMoving) {
            _rb.velocity = _direction * GameConstants.PLAYER_SPEED;
        }
    }
    public void StartMoving(Vector3 direction) {
        if (!_isMoving) {
            _direction = direction;
            _isMoving = true;
        }
    }
    public void StopMoving()
    {
        _isMoving = false;
    }
}
