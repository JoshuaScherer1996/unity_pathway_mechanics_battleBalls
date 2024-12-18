using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    // Declaring and initializing the constant.
    private const float RotationSpeed = 65.0f;
    
    // Update is called once per frame.
    private void Update()
    {
        // Executing the rotation around the y-axis.
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }
}
