using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Rigidbody Rigidbody;
    [SerializeField] 
    private PowerBar powerBar;
    [SerializeField]
    private PauseScript pauseScript;
    [SerializeField]
    private int distanceUntilReset;
    [SerializeField]
    private float shootCooldown;
    private float timeBetweenShots;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScript.togglePause();
        }

        if (Vector3.Distance(transform.position, new Vector3(0,0,0)) >= distanceUntilReset)
        {
            Rigidbody.velocity = Vector3.zero;
            Player.transform.position = new Vector3(0,0,0);
        }


        timeBetweenShots -= Time.deltaTime;

        Vector3 directionToCamera = (transform.position - cameraTransform.position);

        directionToCamera.y = 0;
        directionToCamera = directionToCamera.normalized;

        if (Input.GetKeyUp(KeyCode.Mouse0) && timeBetweenShots <= 0 && !pauseScript.isPaused())
        {
            Rigidbody.AddForce(directionToCamera * speed * powerBar.GetCurrentPower());

            Debug.Log(powerBar.GetCurrentPower());

            timeBetweenShots = shootCooldown;
            GameManager.instance.TakeShot();
        }
    }
}
