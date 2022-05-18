using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DynamicDistanceWorldText : MonoBehaviour
{
    // parameters:
    public float scalingRatio = 0.05f;

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
        transform.LookAt(PlayerReferenceTracker.Instance.globalPlayerReference);
        transform.Rotate(transform.up, 180.0f);
        transform.Rotate(0, 0, -transform.rotation.eulerAngles.z);
    }

    void ComputeDistance()
    {
        distance = Vector3.Distance(this.transform.position, PlayerReferenceTracker.Instance.globalPlayerReference.position);
    }

    void UpdateText()
    {
        if (distance < 1000)
        {
            text.text = string.Format("{0:F1}", distance) + " m";
        }
        else if (distance > 1000)
        {
            text.text = string.Format("{0:F1}", distance / 1000) + " Km";
        }
        else if (distance > 1000000)
        {
            text.text = string.Format("{0:F1}", distance / 1000000) + " Mm";
        }
        else if (distance > 1000000000)
        {
            text.text = string.Format("{0:F1}", distance / 1000000000) + " Gm";
        }
    }

    void ResizeText()
    {
        double newSize = distance * scalingRatio;
        text.fontSize = (int)newSize;
    }
}
