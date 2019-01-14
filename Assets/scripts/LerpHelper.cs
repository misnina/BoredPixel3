using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper : MonoBehaviour
{
    private bool shouldLerp = false;

    public float timeStartedLerping;
    public float lerpTime;

    public Vector2 endPosition;
    public Vector2 startPosition;

    public void StartLerping()
    {
        timeStartedLerping = Time.time;
        shouldLerp = true;
    }

    private void Update()
    {
        if (shouldLerp)
        {
            transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);
        }
        
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 2)
    {
        float timeSinceStart = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStart / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
