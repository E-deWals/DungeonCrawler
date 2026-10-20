using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PlayerController characterController;

    private InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

    }

    private void Update()
    {
        Vector2 movementVector = moveAction.ReadValue<Vector2>();
        characterController.Move(movementVector);
    }


}
