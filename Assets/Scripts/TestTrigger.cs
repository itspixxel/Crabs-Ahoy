using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D coll)
    {
        Debug.Log($"Trigger exit at {Time.time}");
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log($"Trigger enter at {Time.time}");
    }
}
