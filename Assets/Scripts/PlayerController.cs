using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaring and initializing the constants and variables.
    private Rigidbody _playerRb;
    private GameObject _focalPoint;
    private const float Speed = 5.0f;
    private const float PowerUpStrength = 15.0f;
    public bool hasPowerUp;
    public GameObject powerUpIndicator;
    
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
        powerUpIndicator.transform.position = transform.position;
    }

    // Takes the tags of the collided objects and implements the destruction logic. Also starts the coroutine.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    // Coroutine that deactivates the power up after a delay.
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    
    // Checks the tags od the collided objects and implements physics logic.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            var enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = collision.gameObject.transform.position - transform.position;
            
            Debug.Log($"Collided with {collision.gameObject.name} with the power up set to {hasPowerUp}");
            enemyRb.AddForce(awayFromPlayer * PowerUpStrength, ForceMode.Impulse);
        }
    }
}
