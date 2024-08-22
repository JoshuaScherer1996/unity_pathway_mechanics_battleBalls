using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    private const float RotationSpeed = 65.0f;
    
    // Update is called once per frame.
    private void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }
}
