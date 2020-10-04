using UnityEngine;

public class Ball : MonoBehaviour
{
    public float xPush = 10.0f;
    public float zPush = 2.0f;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(xPush, 0.0f, zPush);
    }
}