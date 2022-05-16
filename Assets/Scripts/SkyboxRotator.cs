using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    [Range(0.5f, 3.0f)] public float rotationSpeed;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
