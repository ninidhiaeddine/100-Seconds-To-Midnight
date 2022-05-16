using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DynamicDistanceWorldText : MonoBehaviour
{
    // parameters:
    public float scalingRatio = 0.05f;
    public Transform target;

    private double distance;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        RotateTowardsTarget();
        ComputeDistance();
        UpdateText();
        ResizeText();
    }

    void RotateTowardsTarget()
    {
        transform.LookAt(target);
        transform.Rotate(transform.up, 180.0f);
    }

    void ComputeDistance()
    {
        distance = Vector3.Distance(this.transform.position, target.position);
    }

    void UpdateText()
    {
        text.text = string.Format("{0:F1}", distance) + " Gm";
    }

    void ResizeText()
    {
        double newSize = distance * scalingRatio;
        text.fontSize = (int)newSize;
    }
}
