using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    float scrollSpeed = 1.5f;
    float Distance = 30.7375f;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, Distance);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
