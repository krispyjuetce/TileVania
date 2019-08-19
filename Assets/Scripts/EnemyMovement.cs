using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    //config variables
    [SerializeField] float moveSpeed = 1f;

    //Cached component references
    Rigidbody2D myRigidBody;

    // Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
	}

    private void EnemyMove()
    {
        Vector2 enemyVelocity;
        if (IsFacingRight())
        {
            enemyVelocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        }
        else
        {
            enemyVelocity = new Vector2(-moveSpeed, myRigidBody.velocity.y);
        }
        myRigidBody.velocity = enemyVelocity;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidBody.velocity.x), 1f);
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x>0;
    }
}
