using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gust
{
    public int id;
    public Vector3 direction;
    public float speed;
    public bool isFinished = false;

    float length;
    float topSpeed;
    float timeElapsed = 0f;
    float volatility;
    
    public void Tick() {
        // Check if gust is over
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= length) {
            isFinished = true;
        }

        // Slowly raise then lower wind speed over the course of the gust
        float percentageOfGustElapsed = timeElapsed / length;
        if(percentageOfGustElapsed < 0.5f) {
            speed = Mathf.Lerp(0f, topSpeed, percentageOfGustElapsed * 2f);
        }
        else if(percentageOfGustElapsed <= 1f) {
            speed = Mathf.Lerp(topSpeed, 0f, (percentageOfGustElapsed - 0.5f) * 2f);
        }
        else {
            speed = 0f;
        }

        float driftX = Random.Range(-volatility, volatility);
        float driftY = Random.Range(-volatility, volatility);
        float driftZ = Random.Range(-volatility, volatility);
        direction += new Vector3(driftX, driftY, driftZ) * Time.deltaTime;
        direction.Normalize();
    }

    public Gust(int id, Vector3 direction, float speed, float length, float volatility) {
        this.id = id;
        this.direction = direction;
        this.topSpeed = speed;
        this.length = length;
        this.volatility = volatility;
    }
}
