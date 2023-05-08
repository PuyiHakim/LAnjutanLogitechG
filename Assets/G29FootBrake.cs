using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class G29FootBrake : MonoBehaviour
{
    // the Logitech G29 steering wheel
    LogitechGSDK.LogiControllerPropertiesData properties;

    // the axis for the foot brake
    public int footBrakeAxis = 2;

    // the current value of the foot brake
    private float footBrakeValue = 0.0f;

    // Use this for initialization
    void Start()
    {
        // initialize the Logitech G29 steering wheel
        LogitechGSDK.LogiSteeringInitialize(false);

        // get the properties of the Logitech G29 steering wheel
        properties = new LogitechGSDK.LogiControllerPropertiesData();
        LogitechGSDK.LogiGetControllerProperties(0, ref properties);
    }

    // Update is called once per frame
    void Update()
    {
        // get the value of the foot brake
        footBrakeValue = LogitechGSDK.LogiControllerGetAxisValue(0, footBrakeAxis);

        // check if the foot brake is pressed
        if (footBrakeValue > 0.0f)
        {
            // apply the brake to the car
            // ...
        }
        else
        {
            // release the brake from the car
            // ...
        }
    }

    // Called when the application is quitting
    void OnApplicationQuit()
    {
        // shutdown the Logitech G29 steering wheel
        LogitechGSDK.LogiSteeringShutdown();
    }
}
