using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class speedmeter2 : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 0.0f; // The maximum speed of the target ** IN KM/H **

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]
    public Text speedLabel; // The label that displays the speed;
    public RectTransform arrow; // The arrow in the speedometer

    private float speed = 0.0f;
    private float treshold = -10f;      // adjust this 
    private bool falling = false;
    private void Update()
    {
        // check if we are falling
        falling = (target.velocity.y < treshold);

        // update the speedometer if we are not falling
        // should we reset speedometer?
        if (!falling)
        {
            // 3.6f to convert in kilometers
            // ** The speed must be clamped by the car controller **
            speed = target.velocity.magnitude * 3.6f;

            Debug.Log("x = " + target.velocity.x);
            Debug.Log("y = " + target.velocity.y);
            Debug.Log("z = " + target.velocity.z);
            Debug.Log("magnitude = " + target.velocity.magnitude);

            if (speedLabel != null)
                speedLabel.text = ((int)speed) + " km/h";
            if (arrow != null)
                arrow.localEulerAngles =
                    new Vector3(5, 5, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
        }

    }
}
