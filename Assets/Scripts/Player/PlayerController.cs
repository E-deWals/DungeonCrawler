using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] Camera cam;
    [SerializeField] private float movementSpeed = 10;

    private float Yrotation;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movementVector)
    {
        transform.forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * movementSpeed * Time.deltaTime;
        characterController.Move(move);
    }
}
