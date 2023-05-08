using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftFootBraking : MonoBehaviour
{
    private G29Wheel g29Wheel;
    private G29Pedals g29Pedals;

    void Start()
    {
        // Membuat instance G29Wheel dan G29Pedals
        g29Wheel = new G29Wheel();
        g29Pedals = new G29Pedals();
    }

    void Update()
    {
        // Mendapatkan input pedal brake
        float brakeInput = g29Pedals.GetBrake();

        // Mendapatkan input pedal throttle
        float throttleInput = g29Pedals.GetThrottle();

        // Jika brakeInput > 0 dan throttleInput > 0, berarti left-foot braking
        if (brakeInput > 0 && throttleInput > 0)
        {
            // Mengatur nilai throttleInput menjadi 0
            g29Pedals.SetThrottle(0);

            // Mengirimkan sinyal ke game bahwa player melakukan left-foot braking
            // misalnya dengan menampilkan pesan di layar
            Debug.Log("Left-foot braking!");
        }
    }
}
