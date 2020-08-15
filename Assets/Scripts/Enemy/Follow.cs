using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [Range(0, 60f)][SerializeField] public float topSpeed = 10;
    [Range(0, 60f)][SerializeField] public float acceleration = 2;


    private Rigidbody2D body;
    private bool facingRight = true;  // For determining which way the player is currently facing.
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (target == null) {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 tPos = target.GetComponent<Transform>().position;
        Vector2 accelerateTo =  acceleration*100*Time.fixedDeltaTime*(tPos - transform.position);

        if (body.velocity.magnitude < topSpeed) {
            body.AddForce(accelerateTo/(body.velocity.sqrMagnitude + 1));
        }
        
        if (body.velocity.x > 0) {
            if (!facingRight) {
                Flip();
            }
        } else {
            if (facingRight) {
                Flip();
            }
        }
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

