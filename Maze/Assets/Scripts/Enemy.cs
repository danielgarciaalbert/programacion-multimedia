using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    Vector3 nextPosition;
    private float movementVelocity = 1f;
    private int numberNextPos = 0;
    private float changeDistance = 0.5f;

    void Start()
    {
        nextPosition = wayPoints[0].position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, nextPosition, movementVelocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPosition) < changeDistance)
        {
            numberNextPos++;
            if (numberNextPos >= wayPoints.Length)
                numberNextPos = 0;
            nextPosition = wayPoints[numberNextPos].position;
        }
    }
}
