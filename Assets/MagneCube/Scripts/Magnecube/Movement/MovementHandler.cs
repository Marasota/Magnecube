using UnityEngine;

public class MovementHandler {
    private Rigidbody _rb;
    private bool _isMoving;
    public bool IsMoving => _isMoving;
    private Vector3 _direction;
  
    public MovementHandler(Rigidbody rb) { 
        _rb = rb;
        _isMoving = false;
    }
    public void Move() { 
        if (_isMoving)
            _rb.velocity = _direction * GameConstants.PLAYER_SPEED;
    }
    public void SetDirection(Vector3 direction) { 
       // _direction = _rb.transform.TransformDirection(direction);
       _direction = direction;
        StartMoving();
    }
    public void StartMoving() {
        _isMoving = true;
        _rb.velocity = _direction * GameConstants.PLAYER_SPEED; 
    }
    public void StopMoving()
    {
        _isMoving = false;
    }
}
