using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaring and initializing the constants and variables.
    private Rigidbody _playerRb;
    private GameObject _focalPoint;
    private const float Speed = 5.0f;
    public bool hasPowerUp;
    
    // Start is called before the first frame update.
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame.
    private void Update()
    {
        var forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalPoint.transform.forward * (forwardInput * Speed));
    }

    // Takes the tags of the collided objects and implements the destruction logic.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }

    // Checks the tags od the collided objects and implements physics logic.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log($"Collided with {collision.gameObject.name} with the power up set to {hasPowerUp}");
        }
    }
}
