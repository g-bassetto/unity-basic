using System;
using UnityEngine;

public class Clock : MonoBehaviour{

    const float hoursToDegrees = -30f;
    const float minutesToDegrees = -6f;
    const float secondsToDegrees = -6f;
    
    [SerializeField]
    Transform hoursPivot;

    [SerializeField]
    Transform minutesPivot;

    [SerializeField]
    Transform secondsPivot;

    void Update() {
        Debug.Log(DateTime.Now.Hour);
        var time = DateTime.Now;
        hoursPivot.localRotation =
            Quaternion.Euler(0f, 0f, hoursToDegrees * time.Hour);
        minutesPivot.localRotation =
             Quaternion.Euler(0f, 0f, minutesToDegrees * time.Minute);
        secondsPivot.localRotation =
             Quaternion.Euler(0f, 0f, secondsToDegrees * time.Second);
    }
}
