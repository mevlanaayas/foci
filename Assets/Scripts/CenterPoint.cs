using System;
using UnityEngine;

[Obsolete("Class is deprecated, please use Ellipse instead.")]
public class CenterPoint : MonoBehaviour
{
    public float radius = 1;
    public GameObject point;
    public float targetTime = 1.0f;
    private float _targetTime;
    private int _currentAngle;
    public int maxAngle = 360;

    private void Start()
    {
        _targetTime = targetTime;
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            TimerCallback();
        }
    }

    private void TimerCallback()
    {
        if (_currentAngle == maxAngle)
        {
            return;
        }

        _currentAngle++;

        targetTime = _targetTime;
        transform.Rotate(0f, 1f, 0f);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * radius, Color.white);
        var position = transform.position + transform.TransformDirection(Vector3.forward) * radius;
        Instantiate(point, position, Quaternion.identity);
    }
}