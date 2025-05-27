using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    [SerializeField] private CharacterController characterController;
    public Transform cameraTransform; 
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float xRotation = 0f; 

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector3 move = transform.forward * moveInput.y + transform.right * moveInput.x;
        characterController.Move(move * speed * Time.deltaTime);

        transform.Rotate(Vector3.up * lookInput.x * sensitivity);

        xRotation -= lookInput.y * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}