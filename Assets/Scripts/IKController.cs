using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKController : MonoBehaviour
{
    public Transform hipRotationTarget;
    public MultiRotationConstraint hipRotationConstraint;
    private float hipYaw;
    private float hipPitch;

    void Awake()
    {
        hipRotationConstraint = GetComponentInChildren<MultiRotationConstraint>();
    }
    public void RotateHips(float amount) => RotateHipsYaw(amount);

    public void RotateHipsYaw(float amount)
    {
        hipYaw = amount;
        ApplyHipRotation();
    }

    public void RotateHipsPitch(float amount)
    {
        hipPitch = amount;
        ApplyHipRotation();
    }

    private void ApplyHipRotation() => hipRotationTarget.localRotation = Quaternion.Euler(hipPitch, hipYaw, 0f);
    
}
