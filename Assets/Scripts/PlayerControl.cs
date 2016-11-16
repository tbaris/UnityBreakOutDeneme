using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float playerSpeed;


    private Vector3 playerPos = new Vector3(0, -14f, 0);

	
	// Update is called once per frame
	void FixedUpdate ()
    {

        float xPos = transform.position.x + (Input.GetAxis("Mouse X") * playerSpeed);
        playerPos = new Vector3 (Mathf.Clamp(xPos, -7.5f, 7.5f), -12f, 0f);
        if (Input.GetButton("Fire1"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 60);
        }
         else if (Input.GetButton("Fire2"))
            {
                transform.rotation = Quaternion.Euler(0, 0, 120);
            }
        else transform.rotation = Quaternion.Euler(0, 0, 90);


        transform.position = playerPos;
 
	
	}
}
