using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed = 2f;
    public float waitTime = 1f;

    private Vector3 currentTarget;
    private bool movingToEnd = true;
    private float timer = 0f;

    private void Start()
    {
        currentTarget = endPoint.position;
    }

    private void Update()
    {
        if (transform.position == currentTarget)
        {
            if (timer >= waitTime)
            {
                movingToEnd = !movingToEnd;
                currentTarget = movingToEnd ? endPoint.position : startPoint.position;
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(startPoint.position, 0.1f);
        Gizmos.DrawSphere(endPoint.position, 0.1f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startPoint.position, endPoint.position);
    }
}
