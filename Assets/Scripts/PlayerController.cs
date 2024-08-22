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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }
}
