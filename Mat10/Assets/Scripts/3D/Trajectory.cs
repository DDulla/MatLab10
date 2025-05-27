using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int resolution = 30;
    public float timeStep = 0.1f;
    public float gravity = -9.81f;

    public Transform shootPoint;
    public float shootForce = 15f;

    void Update()
    {
        Vector3 startVelocity = shootPoint.forward * shootForce;
        DrawTrajectory(shootPoint.position, startVelocity);
    }

    public void DrawTrajectory(Vector3 startPosition, Vector3 startVelocity)
    {
        Vector3[] points = new Vector3[resolution];
        float time = 0f;

        for (int i = 0; i < resolution; i++)
        {
            points[i] = startPosition + (startVelocity * time) + (0.5f * gravity * time * time * Vector3.up);
            time += timeStep;
        }

        lineRenderer.positionCount = resolution;
        lineRenderer.SetPositions(points);
    }
}