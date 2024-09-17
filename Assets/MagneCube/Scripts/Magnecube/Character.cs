using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour, IControllable
{
    private MovementHandler _movementHandler;
    private Rigidbody _rb;

    [SerializeField] private float _checkDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private BoxCollider _boxUp, _boxDown, _boxLeft, _boxRight;

    public event Action StartMoving;

    private Dictionary<string, BoxCollider> _checkers;
    private bool _canMove = true;

    public void Move(Vector3 direction)
    {
        if (_canMove && _rb.velocity == Vector3.zero && CanMoveInDirection(direction)) {
            StartMoving?.Invoke();
            DettachFromPlatform();
            ChangeDirection(direction);
        }
    }
    public bool CanMoveInDirection(Vector3 direction)
    {
        if (direction == Vector3.up)
        {
            return MovementChecker.CanMove(_checkers[GameConstants.UP_BOX], _layerMask);
        }
        else if (direction == Vector3.down)
        {
            return MovementChecker.CanMove(_checkers[GameConstants.DOWN_BOX], _layerMask);
        }
        else if (direction == Vector3.left)
        {
            return MovementChecker.CanMove(_checkers[GameConstants.LEFT_BOX], _layerMask);
        }
        else if (direction == Vector3.right)
        {
            return MovementChecker.CanMove(_checkers[GameConstants.RIGHT_BOX], _layerMask);
        }

        return true;
    }

    public void AllowMovement() {
        _canMove = true;
    }

    public void DisallowMovement() {
        _canMove = false;
    }

    public void ChangeDirection(Vector3 direction) {
        _movementHandler.SetDirection(direction);
    }

    private void AttachToPlatform(Transform trans)
    {
        transform.SetParent(trans);
    }

    private void DettachFromPlatform()
    {
        transform.SetParent(null);
    }

    public void AlignCheckers(int angle) {
        Debug.Log($"Before rotating: Up = {_checkers[GameConstants.UP_BOX].name}, Left = {_checkers[GameConstants.LEFT_BOX]}, Down = {_checkers[GameConstants.DOWN_BOX]}, Right = {_checkers[GameConstants.RIGHT_BOX]}");
        RectangularRotator<BoxCollider>.Rotate(_checkers, angle);
        Debug.Log($"After rotating: Up = {_checkers[GameConstants.UP_BOX].name}, Left = {_checkers[GameConstants.LEFT_BOX]}, Down = {_checkers[GameConstants.DOWN_BOX]}, Right = {_checkers[GameConstants.RIGHT_BOX]}");
    }

    private void InitCheckers() {
        _checkers = new Dictionary<string, BoxCollider>();
        _checkers.Add(GameConstants.UP_BOX, _boxUp);
        _checkers.Add(GameConstants.DOWN_BOX, _boxDown);
        _checkers.Add(GameConstants.LEFT_BOX, _boxLeft);
        _checkers.Add(GameConstants.RIGHT_BOX, _boxRight);
    }

    #region MONO

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _movementHandler = new MovementHandler(_rb);
        InitCheckers();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($"velocity = {_rb.velocity}");
        }
    }

    private void FixedUpdate()
    {
       // _movementHandler.Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        _movementHandler.StopMoving();
        AttachToPlatform(collision.transform);
    }
    #endregion
}
