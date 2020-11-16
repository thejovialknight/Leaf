using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafStateTransformer : MonoBehaviour
{
    public Vector3 fallingWindMultiplier;
    public GameObject featherFaller;
    public bool bangFall = false;

    ConfigurableJoint branchJoint;
    ForceFromWind windCatcher;

    void Awake() {
        branchJoint = GetComponent<ConfigurableJoint>();
        windCatcher = GetComponent<ForceFromWind>();
    }

    void Update()
    {
        if(bangFall == true) {
            bangFall = false;
            DetachLeaf();
        }
    }

    void DetachLeaf() {
        windCatcher.windMultiplier = fallingWindMultiplier;
        Destroy(branchJoint);
        featherFaller.SetActive(true);
    }
}
