using UnityEngine;
using UnityEngine.UI;

public class UIControlPanel : MonoBehaviour
{
    [SerializeField] private RagdollToggle ragdollToggle;
    [SerializeField] private Toggle isRagdolToggle;

    void Start()
    {
        ragdollToggle.isRagdolling = isRagdolToggle.isOn;
    }

    public void ToggleRagdoll(bool value) => ragdollToggle.isRagdolling = value;
    

    public void ResetRagdollPosition() => ragdollToggle.rootTransform.position = ragdollToggle.rootTransform.position = ragdollToggle.startPosition;
    
}
