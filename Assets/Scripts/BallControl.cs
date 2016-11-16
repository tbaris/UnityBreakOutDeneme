using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

    public float ballInitialVelocity;

    private Rigidbody rb;
    private bool ballInPlay;

	// Use this for initialization
	void Awake () {

        rb = GetComponent<Rigidbody>();


	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetButtonDown("Fire3") && ballInPlay == false)
        {

            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));

        }

	}
}
