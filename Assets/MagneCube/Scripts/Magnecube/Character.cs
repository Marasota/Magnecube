using UnityEngine;
using Zenject;

public class Character : MonoBehaviour, IControllable
{

    private MovementHandler _movementHandler;

    #region PUBLIC METHODS
    public void Move(Vector3 direction)
    {
        _movementHandler.StartMoving(direction);
    }

    #endregion

    #region MONO
    private void Awake()
    {
        _movementHandler = new MovementHandler(transform);
    }

    private void Update()
    {
        _movementHandler.Move();
    }

    #endregion



}
