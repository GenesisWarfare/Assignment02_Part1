using UnityEngine;
using UnityEngine.InputSystem;

public class VisibilityToggle : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private bool includeChildren = false;   // also hide children
    [SerializeField] private bool alsoAffectColliders = false; // also hide colliders

    private Controls controls;          
    private Renderer[] renderers;
    private Collider[] colliders;
    private bool isVisible = true;

    void Awake()
    {
        // get renderers (also children if needed)
        renderers = includeChildren
            ? GetComponentsInChildren<Renderer>(true)
            : new Renderer[] { GetComponent<Renderer>() };

        // get colliders if enabled
        if (alsoAffectColliders)
            colliders = includeChildren
                ? GetComponentsInChildren<Collider>(true)
                : new Collider[] { GetComponent<Collider>() };

        // setup input
        controls = new Controls();
        controls.Player.ToggleVisibility.performed += _ => SetVisible(!isVisible);
    }

    void OnEnable()  => controls.Player.Enable();
    void OnDisable() => controls.Player.Disable();

    private void SetVisible(bool v)
    {
        isVisible = v;
        foreach (var r in renderers) if (r) r.enabled = v;
        if (alsoAffectColliders && colliders != null)
            foreach (var c in colliders) if (c) c.enabled = v;
    }
}

