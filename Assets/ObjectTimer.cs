using UnityEngine;

public class ObjectTimer : MonoBehaviour
{
    public float startTime;
    public float duration;
    public bool timerDone;

    //public ObjectTimer() {
    //    this.startTime = Time.time;
    //}

    public float GetSpawnTime() {
        return this.startTime;
    }

    public bool TimerDone
    {
        get { return timerDone; }
    }

    public void StartTimer(float timeToWait)
    {
        startTime = Time.time;
        duration = timeToWait;
        timerDone = false;
    }

    void Update()
    {
        if (!timerDone && Time.time - startTime >= duration)
        {
            timerDone = true;
        }
    }


}
