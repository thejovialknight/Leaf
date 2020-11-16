using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFromWind : MonoBehaviour
{
    public Vector3 windMultiplier = new Vector3(1f, 1f, 1f);

    ConstantForce force;

    void Awake() {
        force = GetComponent<ConstantForce>();
    }

    void Update()
    {
        float forceX = Wind.instance.velocity.x * windMultiplier.x;
        float forceY = Wind.instance.velocity.y * windMultiplier.y;
        float forceZ = Wind.instance.velocity.z * windMultiplier.z;
        force.force = new Vector3(forceX, forceY, forceZ);
    }
}
