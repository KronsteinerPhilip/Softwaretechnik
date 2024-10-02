using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Text text;

    private int holeCount = 0;

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

    public void BallHoled()
    {
        holeCount++;
        text.text = "Points scored: " + holeCount;
    }

    public int GetHoleCount()
    {
        return holeCount;
    }
}
