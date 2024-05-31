using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform targetObj;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float avoidanceDistance = 2.0f;

    void Update()
    {
        Vector3 targetDirection = targetObj.position - transform.position;
        Vector3 newPosition = transform.position + (targetDirection.normalized * movementSpeed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, targetDirection, out hit, avoidanceDistance))
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, hit.normal, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            transform.position = newPosition;
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}
