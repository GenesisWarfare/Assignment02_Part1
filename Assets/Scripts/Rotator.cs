
using UnityEngine;public class Rotator : MonoBehaviour{[Header("Rotation speed (degrees per second)")][SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);[Header("Rotation space")][SerializeField] private Space rotationSpace = Space.Self;void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpace);
    }
}
