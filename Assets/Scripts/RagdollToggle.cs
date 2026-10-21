using UnityEngine;
public class RagdollToggle : MonoBehaviour
{
    private Rigidbody[] rigidbodies;
    private Rigidbody rootRigidbody;
    private Collider[] ragdollColliders;
    private CapsuleCollider rootCollider;
    private Animator animator;

    public bool isRagdolling;
    void Awake()
    {
        rootCollider = GetComponentInParent<CapsuleCollider>();
        rootRigidbody = GetComponentInParent<Rigidbody>();

        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        animator = GetComponent<Animator>();

        DisableRagdoll();
        isRagdolling = false;
    }


   public void DisableRagdoll()
    {
        foreach (var ragdollCollider in ragdollColliders)
            ragdollCollider.enabled = false;

        foreach (var rigidBody in rigidbodies)
            rigidBody.isKinematic = true;
        
        rootRigidbody.isKinematic = false;
        rootCollider.enabled = true;
        animator.enabled = true;
        isRagdolling = false;
    }

    void FixedUpdate()
    {
        if(isRagdolling)
            EnableRagdoll();

        if(!isRagdolling)
            DisableRagdoll();
    }
    public void EnableRagdoll()
    {
        rootCollider.enabled = false;
        animator.enabled = false;
        isRagdolling = true;
        rootRigidbody.isKinematic = true;

        foreach (var ragdollCollider in ragdollColliders)
            ragdollCollider.enabled = true;

        foreach (var rigidBody in rigidbodies)
            rigidBody.isKinematic = false;    
    }
}
