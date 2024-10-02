using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private Rigidbody Rigidbody;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float shootCooldown;
    private float timeBetweenShots;

    [SerializeField]
    private Transform cameraTransform;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timeBetweenShots -= Time.deltaTime;

        //Schussrichtung berechnen
        Vector3 directionToCamera = (transform.position - cameraTransform.position);

        //Ignoriert ob die Kamera nach unten Schaut
        directionToCamera.y = 0;
        directionToCamera = directionToCamera.normalized;

        if (Input.GetKeyDown(KeyCode.W) && timeBetweenShots <= 0)
        {
            Rigidbody.AddForce(directionToCamera * speed);
            timeBetweenShots = shootCooldown;
        }
    }

}
