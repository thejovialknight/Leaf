using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorSpectrum : MonoBehaviour
{
    public Color newColor;
    public Color oldColor;

    new Renderer renderer;

    void Awake() {
        renderer = GetComponent<Renderer>();
    }

    void Start() {
        float randomColor = Random.Range(0f, 1f);
        renderer.material.color = Color.Lerp(oldColor, newColor, randomColor);
    }
}
