using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    Vector3 nextPosition;
    private float movementVelocity = 2f;
    private int numberNextPos = 0;
    private float changeDistance = 1f;
    private float smooth = 2f;
    private Transform target;



    void Start()
    {
        nextPosition = wayPoints[0].position;
        target = wayPoints[0].transform;
    }

    void Update()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);

        transform.position = Vector3.MoveTowards(
            transform.position, nextPosition, movementVelocity * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smooth);

        if (Vector3.Distance(transform.position, nextPosition) < changeDistance)
        {
            numberNextPos++;
            if (numberNextPos >= wayPoints.Length)
                numberNextPos = 0;
            nextPosition = wayPoints[numberNextPos].position;
            target = wayPoints[numberNextPos].transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
