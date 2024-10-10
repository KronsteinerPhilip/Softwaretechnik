using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    private Transform targetToRotateAround;
    private float distanceToTarget = 7.0f;
    private float xRotationSpeed = 240.0f;
    private float yRotationSpeed = 240.0f;
    private float yMinAngle = 0f;
    private float yMaxAngle = 40f;   

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        if (targetToRotateAround == null)
        {
            Debug.LogError("Das Zielobjekt ist nicht gesetzt!");
            return;
        }
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        UpdateCameraPosition();
    }

    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X") * xRotationSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * yRotationSpeed * Time.deltaTime;

        // Begrenzt den y-Winkel
        y = Mathf.Clamp(y, yMinAngle, yMaxAngle);

        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(y, x, 0);

        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distanceToTarget) + targetToRotateAround.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}