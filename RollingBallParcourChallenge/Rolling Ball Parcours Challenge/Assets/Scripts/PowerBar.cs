using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    [SerializeField]
    private Slider powerSlider;
    [SerializeField]
    private float maxPower = 100f;
    private float minPower = 1f;
    [SerializeField]
    private float chargeSpeed = 1f;

    private bool isCharging = false; 
    private float currentPower = 1f; 

    void Update()
    {
        if(Input.GetMouseButtonUp(0)) 
        {
            currentPower = minPower;
            powerSlider.value = currentPower / maxPower;
        }

        if (Input.GetMouseButton(0) && isCharging)
        {
            currentPower += chargeSpeed * Time.deltaTime;

            if (currentPower >= maxPower)
            {
                currentPower = maxPower;
                isCharging = !isCharging;
            }

            powerSlider.value = currentPower / maxPower;
        }
        else if(Input.GetMouseButton(0) && !isCharging)
        {
            currentPower -= chargeSpeed * Time.deltaTime;

            if (currentPower <= minPower)
            {
                currentPower = minPower;

                isCharging = !isCharging;
            }

            powerSlider.value = currentPower / maxPower;
        }
    }

    public float GetCurrentPower()
    {
        return currentPower;
    }
}
