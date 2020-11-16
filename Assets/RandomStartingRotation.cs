using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartingRotation : MonoBehaviour
{
    public float sizeAverage = 1f;
    public float sizeMargin = 0.1f;
    public float xRotationAverage = 0f;
    public float xRotationMargin = 10f;
    public float yRotationAverage = 0f;
    public float yRotationMargin = 25f;
    public float zRotationAverage = 0f;
    public float zRotationMargin = 10f;

    public float minMass = 0.005f;
    public float maxMass = 0.018f;

    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        float size = Randomizer.Float(sizeAverage, sizeMargin);
        float xRotation = Randomizer.Float(xRotationAverage, xRotationMargin);
        float yRotation = Randomizer.Float(yRotationAverage, yRotationMargin);
        float zRotation = Randomizer.Float(zRotationAverage, zRotationMargin);

        transform.localScale = new Vector3(size, size, size);
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation));

        float lerpSize = size / (sizeAverage + sizeMargin);
        rb.mass = Mathf.Lerp(minMass, maxMass, lerpSize);
    }
}
