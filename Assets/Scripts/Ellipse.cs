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
        CreatePoint();
    }

    private void CreatePoint()
    {
        if (_currentPoint == pointCount)
        {
            if (!_fociCalculated)
            {
                CreateFoci();
            }

            return;
        }

        var angle = (float) _currentPoint / pointCount * 360 * Mathf.Deg2Rad;
        var x = Mathf.Sin(angle) * height;
        var y = transform.position.y;
        var z = Mathf.Cos(angle) * width;

        var target = new Vector3(x, y, z);

        _currentPoint++;
        Instantiate(pointPrefab, target + transform.position, Quaternion.identity);
    }

    private void CreateFoci()
    {
        // TODO: make foci points property on ellipse object
        var fociDistance = Mathf.Sqrt(Mathf.Abs(width * width - height * height));
        var transformPosition = transform.position;
        var firstFociPosition =
            new Vector3(transformPosition.x, transformPosition.y, transformPosition.z + fociDistance);
        Instantiate(pointPrefab, firstFociPosition, Quaternion.identity);
        var secondFociPosition =
            new Vector3(transformPosition.x, transformPosition.y, transformPosition.z - fociDistance);
        Instantiate(pointPrefab, secondFociPosition, Quaternion.identity);
        _fociCalculated = true;
    }
}