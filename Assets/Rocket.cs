using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    [SerializeField]
    private float thrustSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }
    private void Thrust()
    {
        // Thrust if space is down
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * 2.5f);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
    private void Rotate()
    {
        // Disable Unity Physics engine on object before rotation
        rigidBody.freezeRotation = true;
        
        // Can only rotate one way at a time.
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Time.deltaTime * thrustSpeed * Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Time.deltaTime * thrustSpeed * Vector3.back);
        }
        
        // Resume physics calculation on object after rotation.
        rigidBody.freezeRotation = false;
    }
}
