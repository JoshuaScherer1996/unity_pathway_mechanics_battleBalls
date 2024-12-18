using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Declaring the variables.
    public float speed;
    private Rigidbody _enemyRb;
    private GameObject _player;
    
    // Start is called before the first frame update.
    private void Start()
    {
        // Assigning the components an objects.
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame.
    private void Update()
    {
        var lookDirection = (_player.transform.position - _enemyRb.transform.position).normalized;
        
        // The applied force is the vector pointing towards the player with normalized magnitude of one.
        _enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
