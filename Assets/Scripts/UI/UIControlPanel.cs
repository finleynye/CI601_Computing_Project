using UnityEngine;
using UnityEngine.UI;

public class UIControlPanel : MonoBehaviour
{
    [SerializeField] private RagdollToggle ragdollToggle;
    [SerializeField] private Toggle isRagdolToggle;
    [SerializeField] private IKController iKController;

    void Start()
    {
        ragdollToggle.isRagdolling = isRagdolToggle.isOn;
    }

    public void ToggleRagdoll(bool value) => ragdollToggle.isRagdolling = value;
    
    public void ResetRagdollPosition() => ragdollToggle.rootTransform.position = ragdollToggle.rootTransform.position = ragdollToggle.startPosition;
    
    public void RotateHips(float amount) => iKController.RotateHips(amount);

    public void RotateHipsYaw(float amount) => iKController.RotateHipsYaw(amount);

    public void RotateHipsPitch(float amount) => iKController.RotateHipsPitch(amount);
    
}
