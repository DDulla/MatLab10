using UnityEngine;
using UnityEngine.InputSystem;

public class Bow2D : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float shootForce = 20f;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.AddForce(shootPoint.right * shootForce, ForceMode.Impulse);
        }
    }
}