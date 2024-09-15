using UnityEngine;

public class MovementHandler {
    private Rigidbody _rb;
    private bool _isMoving;
    public bool IsMoving { get { return _isMoving; } }
    private Vector3 _direction;
  
    public MovementHandler(Rigidbody rb) { 
        _rb = rb;
        _isMoving = false;
    }
    public void Move() {      
        _rb.velocity = _direction * GameConstants.PLAYER_SPEED;
    }
    public void SetDirection(Vector3 direction) {
        if (!_isMoving){
            _direction = _rb.transform.TransformDirection(direction);
        }
    }
    public void StartMoving() {
        _isMoving = true;
    }
    public void StopMoving()
    {
        _isMoving = false;
    }
}
