using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public Transform endPos;
    public Transform startPos;

    private void Update()
    {
        // Move the cloud sprite to the left
        transform.position += Vector3.left * moveSpeed;

        // If the cloud has moved off the screen to the left, move it back to the right
        if (transform.position.x < endPos.position.x)
        {
            transform.position = new Vector3(startPos.position.x, transform.position.y, transform.position.z);
        }
    }
}
