using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Vector3 newCamPos;
    public Vector3 newPlayerPos;

    CameraController cameraControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraControl = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraControl.minPos += newCamPos;
            cameraControl.maxPos += newCamPos;

            collision.transform.position += newPlayerPos;
            collision.GetComponent<Player>().ScreenTransition();
        }
    }
}
