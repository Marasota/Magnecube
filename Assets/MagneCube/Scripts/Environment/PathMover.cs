using UnityEngine;

public class PathMover : MonoBehaviour, IMovable
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    private int currentWaypointIndex = 0;

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (waypoints.Length == 0) return;
        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}

