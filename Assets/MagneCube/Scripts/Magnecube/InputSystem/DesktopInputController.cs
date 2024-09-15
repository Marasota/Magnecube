using UnityEngine;
using Zenject;

public class DesktopInputController : MonoBehaviour, IInputController
{
    [Inject]
    private IControllable _controllable;
    private void Awake()
    {
        Debug.Log("USING DESKTOP INPUT SYSTEM!");
    }

    private void Update()
    {
        ReadMovement();
    }

    public void ReadMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            _controllable.Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            _controllable.Move(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _controllable.Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _controllable.Move(Vector3.right);
        }
    }

}
