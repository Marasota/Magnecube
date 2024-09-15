using UnityEngine;
using Zenject;

public class MobileInputController : MonoBehaviour, IInputController
{
    [Inject]
    private IControllable _controllable;

    private void Awake()
    {
        Debug.Log("USING MOBILE INPUT SYSTEM!");
    }

    public void ReadMovement()
    {
        throw new System.NotImplementedException();
    }
}
