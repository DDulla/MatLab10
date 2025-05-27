using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -10f;  
    public float maxX = 10f;   
    private Vector2 moveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        float moveAmount = moveInput.x * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(moveAmount, 0, 0);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
}