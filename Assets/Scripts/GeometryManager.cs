using UnityEngine;

public class GeometryManager : MonoBehaviour
{
    public GameObject particle;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return;
        Instantiate(particle, hit.point, Quaternion.identity);
    }
}