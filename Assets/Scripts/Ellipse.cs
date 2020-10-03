using UnityEngine;

public class Ellipse : MonoBehaviour
{
    [Range(36, 3600)] public int pointCount = 360;

    public float height = 3;
    public float width = 5;
    public GameObject pointPrefab;

    private int _currentPoint;
    private bool _fociCalculated;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CreatePoint();
        }

        CreatePoint();
    }

    private void CreatePoint()
    {
        var angle = (float) _currentPoint / pointCount * 360 * Mathf.Deg2Rad;
        var x = Mathf.Sin(angle) * height;
        var y = transform.position.y;
        var z = Mathf.Cos(angle) * width;

        var target = new Vector3(x, y, z);

        if (_currentPoint == pointCount && !_fociCalculated)
        {
            CreateFoci();
            return;
        }

        _currentPoint++;
        Instantiate(pointPrefab, target + transform.position, Quaternion.identity);
    }

    private void CreateFoci()
    {
        // TODO: make foci points property on ellipse object
        var fociDistance = Mathf.Sqrt(Mathf.Abs(width * width - height * height));
        var transformPosition = transform.position;
        var firstFociPosition = new Vector3(transformPosition.x, transformPosition.y, transformPosition.z + fociDistance);
        Instantiate(pointPrefab, firstFociPosition, Quaternion.identity);
        var secondFociPosition = new Vector3(transformPosition.x, transformPosition.y, transformPosition.z -fociDistance);
        Instantiate(pointPrefab, secondFociPosition, Quaternion.identity);
        _fociCalculated = true;
    }
}