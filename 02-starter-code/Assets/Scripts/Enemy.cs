using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed = 5;
    public Transform[] waypoints;
    private int currentWaypointIndex;
    private Vector3 lastPosition;
    [SerializeField] private GameObject body;


    private void Awake()
    {
        lastPosition = transform.position;
    }
    private void Update()
    {

        if (currentWaypointIndex >= waypoints.Length)
        {
            // Enemy has reached the end, decrease health
            GameManager.Instance.DecreaseHealth(1);
            Destroy(gameObject);
            return;
        }

        Transform toWaypoint = waypoints[currentWaypointIndex];
        // MoveTowards is a really useful inbuilt Unity function for doing this kind of thing.
        Vector2 moveVector = Vector2.MoveTowards(transform.position, toWaypoint.position, MoveSpeed * Time.deltaTime);
        transform.position = (Vector3)moveVector;

        if (Vector2.Distance(transform.position, toWaypoint.position) <= float.Epsilon)
        {
            // We reached our target waystation.
            currentWaypointIndex++;
        }

        RotateIntoMoveDirection();
        lastPosition = transform.position;
    }

    private void RotateIntoMoveDirection()
    {
        Vector2 newDirection = (transform.position - lastPosition);
        body.transform.right = newDirection;
    }
}
