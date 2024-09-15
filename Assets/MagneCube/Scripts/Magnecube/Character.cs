using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour, IControllable
{
    private MovementHandler _movementHandler;
    private CollisionsHandler _collisionsHandler;
    private Rigidbody _rb;

    public void Move(Vector3 direction)
    {
        _movementHandler.SetDirection(direction);     
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _movementHandler = new MovementHandler(_rb);   
       
    }

    private void FixedUpdate()
    {
        _movementHandler.Move();
    }


    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnColExit");
        _movementHandler.StartMoving();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnColEnter");
        _movementHandler.StopMoving();
    }
 
}
