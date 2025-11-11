using UnityEngine;
using UnityEngine.InputSystem;
public class VisibilityToggle : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private bool includeChildren = false;
    [SerializeField] private bool alsoAffectColliders = false;
    private Controls controls;          
    private Renderer[] renderers;
    private Collider[] colliders;
    private bool isVisible = true;
    void Awake()
    {
        renderers = includeChildren
            ? GetComponentsInChildren<Renderer>(true)
            : new Renderer[] { GetComponent<Renderer>() };
        if (alsoAffectColliders)
            colliders = includeChildren
                ? GetComponentsInChildren<Collider>(true)
                : new Collider[] { GetComponent<Collider>() };
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
