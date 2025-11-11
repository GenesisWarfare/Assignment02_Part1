
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
