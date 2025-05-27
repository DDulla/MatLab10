using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 10f;
    public UnityEvent onShoot; 

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);

            onShoot?.Invoke(); 
        }
    }
}