using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject ballObjectsParent;

    private void OnTriggerEnter(Collider other)
    {
        List<GameObject> allBalls = GetAllBalls(ballObjectsParent);

        foreach (GameObject ball in allBalls)
        {
            if (other.gameObject.Equals(ball))
            {
                other.gameObject.SetActive(false);
                GameManager.instance.BallsHoled();
            }
        }
    }

    public List<GameObject> GetAllBalls(GameObject parentGameObject)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform childTransform in parentGameObject.transform)
        {
            children.Add(childTransform.gameObject);
        }
        return children;
    }
}
