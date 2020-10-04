using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ball;

    private void Update()
    {
        if (!Input.GetMouseButtonUp(1)) return;

        Instantiate(ball, new Vector3(0, 1, 0), Quaternion.identity);
    }
}