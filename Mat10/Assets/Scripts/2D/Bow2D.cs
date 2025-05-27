using UnityEngine;
using UnityEngine.InputSystem;

public class Bow2D : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 15f;
    public Trajectory2D trajectory;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = transform.position.z;

        Vector3 direction = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        trajectory.DrawTrajectory(shootPoint.position, direction * shootForce);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.right * shootForce, ForceMode.Impulse);
    }
}