using UnityEngine;

public class Trajectory2D : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int resolution = 30;
    public float gravity = -9.81f;
    public float timeStep = 0.1f;

    public void DrawTrajectory(Vector3 startPosition, Vector3 startVelocity)
    {
        Vector3[] points = new Vector3[resolution];
        float time = 0f;

        for (int i = 0; i < resolution; i++)
        {
            float x = startPosition.x + (startVelocity.x * time);
            float y = startPosition.y + (startVelocity.y * time) + (0.5f * gravity * time * time);

            points[i] = new Vector3(x, y, startPosition.z); 

            time += timeStep;
        }

        lineRenderer.positionCount = resolution;
        lineRenderer.SetPositions(points);
    }
}