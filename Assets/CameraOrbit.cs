using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float xSpeed = 2.5f;
    public float ySpeed = 10f;
    public float lerpSpeed = 5f;
    public float desiredY;

    Vector3 targetOffset;
    
    void Start() {
        desiredY = transform.position.y;
        targetOffset = transform.position - target.position;
    }

    void Update(){
        transform.position = target.position + targetOffset;

        transform.LookAt(target);
        transform.Translate(Vector3.right * xSpeed * Time.deltaTime);

        desiredY += Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;

        float newY = Mathf.Lerp(transform.position.y, desiredY, lerpSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        targetOffset = transform.position - target.position;
    }
}
