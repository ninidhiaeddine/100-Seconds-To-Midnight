using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairMovement : MonoBehaviour
{
    public Image outerCircle;
    public Image innerCircle;
    public float outerCircleRotationSpeed = 30f;
    public float innerCircleRotationSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        outerCircle.transform.Rotate(Vector3.forward, outerCircleRotationSpeed * Time.deltaTime);
        innerCircle.transform.Rotate(Vector3.forward, innerCircleRotationSpeed * Time.deltaTime);
    }
}
