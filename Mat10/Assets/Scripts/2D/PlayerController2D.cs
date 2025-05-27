using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    public Transform bowTransform; 
    public Transform shootPoint;   

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z; 

        Vector3 direction = (mousePos - shootPoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        bowTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}