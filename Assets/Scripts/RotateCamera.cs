using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Declaring the variable.
    public float rotationSpeed;

    // Update is called once per frame.
    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
