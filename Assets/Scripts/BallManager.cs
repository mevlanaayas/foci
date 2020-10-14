using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ball;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(1)) return;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return;
        Instantiate(ball, hit.point, Quaternion.identity);
    }
}