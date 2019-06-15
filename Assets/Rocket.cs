using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField]
    private float thrustSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRemoteInput();


    }

    private void ProcessRemoteInput()
    {
        // Thrust if space is down
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
        }
        
        // Can only rotate one way at a time.
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Time.deltaTime * thrustSpeed * Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Time.deltaTime * thrustSpeed * Vector3.back);
        }
        
        


    }
}
