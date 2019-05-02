using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyModifier : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 massCenter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass -= massCenter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
