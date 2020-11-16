using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    // Public members
    public Vector3 velocity;
    public float windSpeedAverage = 1.5f;
    public float windSpeedMargin = 1.25f;
    public float timeBetweenGustsAverage = 4f;
    public float timeBetweenGustsMargin = 2f;
    public float gustLengthAverage = 4f;
    public float gustLengthMargin = 2f;
    public float gustVolatilityAverage = 0.5f;
    public float gustVolatilityMargin = 0.5f;
    public float velocityLerpSpeed = 2f;

    // Private members
    public List<Gust> gusts = new List<Gust>();
    float timeTillNextGust;
    Vector3 desiredVelocity;
    int gustIndex = 0;

    // Singleton instance
    public static Wind instance;

    // Public methods

    // Private methods
    void Awake() {
        instance = this;
    }

    void Update()
    {
        // Count the timers
        timeTillNextGust -= Time.deltaTime;

        // Start the next gust if the time remaining reaches 0;
        if(timeTillNextGust <= 0f) {
            AddGust();
        }

        // Calculate speed and direction
        desiredVelocity = Vector3.zero;
        Gust gustToRemove = null;
        foreach(Gust gust in gusts) {
            gust.Tick();
            desiredVelocity += gust.direction * gust.speed;
            if(gust.isFinished) {
                gustToRemove = gust;
            }
        }

        if(gustToRemove != null) {
            gusts.Remove(gustToRemove);
        }

        // Lerp towards the desired wind speed
        velocity = Vector3.Lerp(velocity, desiredVelocity, velocityLerpSpeed * Time.deltaTime);
    }

    void AddGust() {
        timeTillNextGust = Randomizer.Float(timeBetweenGustsAverage, timeBetweenGustsMargin);

        Vector3 gustDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        float gustSpeed = Randomizer.Float(windSpeedAverage, windSpeedMargin);
        float gustLength = Randomizer.Float(gustLengthAverage, gustLengthMargin);
        float gustVolatility = Randomizer.Float(gustVolatilityAverage, gustVolatilityMargin);

        gusts.Add(new Gust(gustIndex, gustDirection, gustSpeed, gustLength, gustVolatility));
        gustIndex++;
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, transform.position + velocity);
    }
}

public class Randomizer {
    // Returns a given average value plus or minus a given margin
    public static float Float(float average, float margin) {
        return average + Random.Range(-margin, margin);
    }
}