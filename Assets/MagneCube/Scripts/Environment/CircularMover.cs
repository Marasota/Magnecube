using UnityEngine;

public class CircularMover : MonoBehaviour, IMovable
{
    [SerializeField] private Vector3 _center;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _speed = 3f;

    private float angle = 0f;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        angle += _speed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * _radius;
        transform.position = _center + offset;
    }
}

