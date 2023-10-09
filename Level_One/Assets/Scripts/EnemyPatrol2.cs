using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol2 : MonoBehaviour
{
  
    public Transform [] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    // Update is called once per frame
    void Update()
    {
        if(patrolDestination == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[2].position) < .2f)
            {
                patrolDestination = 3;
            }
        }
         if(patrolDestination == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[3].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[3].position) < .2f)
            {
                patrolDestination = 2;
            }
    }
    }

}
