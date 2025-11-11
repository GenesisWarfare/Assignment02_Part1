using UnityEngine;
public class Scaler : MonoBehaviour
{
    [Header("Amplitude (scale variation)")]
    [SerializeField] private float scaleAmplitude = 0.3f;
    [Header("Frequency (beats per second)")]
    [SerializeField] private float frequency = 1f;
    private Vector3 baseScale;
    void Awake()
    {
        baseScale = transform.localScale;
    }
    void Update()
    {
        float scaleFactor = 1f + scaleAmplitude * Mathf.Sin(2f * Mathf.PI * frequency * Time.time);
        transform.localScale = baseScale * scaleFactor;
    }
}
