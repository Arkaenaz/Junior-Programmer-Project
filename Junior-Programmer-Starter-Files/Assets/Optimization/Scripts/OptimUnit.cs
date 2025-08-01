using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Profiling;
using Random = UnityEngine.Random;

public class OptimUnit : MonoBehaviour
{
    private Vector3 currentVelocity;
    private float timeToVelocityChange;
    private float currentAngularVelocity;
    private float timeToAngularVelocityChange;

    private Vector3 areaSize;

    public void SetAreaSize(Vector3 size)
    {
        areaSize = size;
    }

    private void Start()
    {
        PickNewVelocity();
        PickNewVelocityChangeTime();
        PickNewAngularVelocity();
        PickNewAngularVelocityChangeTime();
    }

    // Update is called once per frame
    void Update()
    {
        Profiler.BeginSample("Handling Time");
        HandleTime();
        Profiler.EndSample();

        Profiler.BeginSample("Rotating");
        var t = transform;
        float xRotation = currentAngularVelocity * Time.deltaTime;
        float zRotation = currentAngularVelocity * Time.deltaTime;

        if (transform.position.x > 0)
            xRotation *= -1;

        if (transform.position.z < 0)
            zRotation *= -1;

        transform.Rotate(xRotation, 0, zRotation);
        Profiler.EndSample();

        Profiler.BeginSample("Moving");

        Move();

        Profiler.EndSample();

        Profiler.BeginSample("Boundary Check");

        //check if we are moving away from the zone and invert velocity if this is the case
        if ((transform.position.x > areaSize.x && currentVelocity.x > 0)
            || (transform.position.x < -areaSize.x && currentVelocity.x < 0))
        {
            currentVelocity.x *= -1;
            PickNewVelocityChangeTime(); //we pick a new change time as we changed velocity
        }

        if ((transform.position.z > areaSize.z && currentVelocity.z > 0)
            || (transform.position.z < -areaSize.z && currentVelocity.z < 0))
        {
            currentVelocity.z *= -1;
            PickNewVelocityChangeTime(); //we pick a new change time as we changed velocity
        }
        
        Profiler.EndSample();
    }


    private void PickNewVelocity()
    {
        currentVelocity = Random.insideUnitSphere;
        currentVelocity.y = 0;
        currentVelocity *= 10.0f;
    }

    private void PickNewAngularVelocity()
    {
        currentAngularVelocity = Random.Range(-180.0f, 180.0f);
    }

    private void PickNewVelocityChangeTime()
    {
        timeToVelocityChange = Random.Range(2.0f, 5.0f);
    }

    private void PickNewAngularVelocityChangeTime()
    {
        timeToAngularVelocityChange = Random.Range(2.0f, 5.0f);
    }

    void Move()
    {
        transform.position = transform.position + currentVelocity * Time.deltaTime;
    }

    private void HandleTime()
    {
        timeToVelocityChange -= Time.deltaTime;
        if (timeToVelocityChange < 0)
        {
            PickNewVelocity();
            PickNewVelocityChangeTime();
        }

        timeToAngularVelocityChange -= Time.deltaTime;
        if (timeToAngularVelocityChange < 0)
        {
            PickNewAngularVelocity();
            PickNewAngularVelocityChangeTime();
        }
    }
}
