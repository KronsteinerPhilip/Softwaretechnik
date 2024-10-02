using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform target;        // Das Zielobjekt, um das sich die Kamera drehen soll
    public float distance = 7.0f;   // Distanz zur Kamera
    public float xSpeed = 240.0f;   // Geschwindigkeit der Rotation um die X-Achse
    public float ySpeed = 240.0f;   // Geschwindigkeit der Rotation um die Y-Achse
    public float yMinLimit = 0f;    // Minimaler y-Winkel
    public float yMaxLimit = 40f;   // Maximaler y-Winkel

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        // Überprüfe, ob das Ziel gesetzt ist
        if (target == null)
        {
            Debug.LogError("Das Zielobjekt ist nicht gesetzt!");
            return;
        }

        //Drehung mit aktuellem Winkel
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        UpdateCameraPosition();
    }

    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

        // Begrenze den y-Winkel
        y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        // Berechne die neue Rotation
        Quaternion rotation = Quaternion.Euler(y, x, 0);

        // Berechne die neue Position der Kamera basierend auf der Distanz und der Rotation
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

        // Setze die Position und Rotation der Kamera
        transform.rotation = rotation;
        transform.position = position;
    }
}