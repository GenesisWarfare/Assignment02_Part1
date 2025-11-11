// using UnityEngine;

// public class Oscillator : MonoBehaviour
// {
//     [Header("Amplitude (maximum distance from start)")]
//     [SerializeField] private Vector3 amplitude = new Vector3(6f, 0f, 0f);

//     [Header("Frequency (num of oscillations per second)")]
//     [SerializeField] private Vector3 frequency = new Vector3(0.15f, 0f, 0f);

//     [Header("Phase Offset")]
//     [SerializeField] private float phase = 0f;

//     private Vector3 startPosition;

//     void Awake()
//     {
//         // Save the starting position as the center of movement
//         startPosition = transform.position;
//     }

//     void Update()
//     {
//         float t = Time.time + phase;

//         // Trigo (sinus) oscillation
//         Vector3 offset = new Vector3(
//             amplitude.x * Mathf.Sin(2f * Mathf.PI * frequency.x * t),
//             amplitude.y * Mathf.Sin(2f * Mathf.PI * frequency.y * t),
//             amplitude.z * Mathf.Sin(2f * Mathf.PI * frequency.z * t)
//         );

//         transform.position = startPosition + offset;
//     }
// }


using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] float length = 3f;        
    [SerializeField] float maxAngle = 45f;     
    [SerializeField] float frequency = 0.5f;   
    [SerializeField] Vector3 axis = Vector3.forward;  

    Vector3 pivotPos;
    Vector3 upDir;

    void Awake()
    {
        upDir = Quaternion.FromToRotation(Vector3.forward, axis.normalized) * Vector3.up;
        pivotPos = transform.position + upDir * length;
    }

    void Update()
    {
        float angle = maxAngle * Mathf.Sin(2f * Mathf.PI * frequency * Time.time);
        Vector3 radial = Quaternion.AngleAxis(angle, axis) * (-upDir * length);
        transform.position = pivotPos + radial;
    }
}
