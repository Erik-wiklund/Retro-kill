using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody enemyRigidbody;

    // The point that the enemy should move towards
    private Vector3 targetPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        
        // Enemy will now never look up or down, only side to side
        targetPoint.y = transform.position.y;

        transform.LookAt(targetPoint);

        // Move the enemy (rigidbody) towards where the player is
        enemyRigidbody.velocity = transform.forward * moveSpeed;
    }
}
