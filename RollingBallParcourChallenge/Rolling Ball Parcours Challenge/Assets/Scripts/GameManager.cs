using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Text holesText;
    [SerializeField]
    private Text attemptsText;
    private int holeCount = 0;
    private int attemptedShots = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BallsHoled()
    {
        holeCount++;
        holesText.text = "Holes scored: " + holeCount;
    }

    public void TakeShot()
    {
        attemptedShots++;
        attemptsText.text = "Attempts: " + attemptedShots;
    }
}
