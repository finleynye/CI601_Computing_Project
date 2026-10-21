using UnityEngine;

public class SyncPhysicsObjects : MonoBehaviour
{
    ConfigurableJoint joint;
    [SerializeField] private Rigidbody animatedRigidbody;

    public bool syncAnimation;

    //this code remember rest pose so animation rotate in joint space
    Quaternion startLocalRotation;
    Transform animationRoot;

    void Awake()
    {
        joint = GetComponent<ConfigurableJoint>();
        var animator = animatedRigidbody != null ? animatedRigidbody.GetComponentInParent<Animator>() : null;
        animationRoot = animator != null ? animator.transform : null;
        startLocalRotation = transform.localRotation;
    }

    void FixedUpdate()
    {
        UpdateJointFromAnimation();
    }

    public void UpdateJointFromAnimation()
    {
        if(!syncAnimation)
            return;
            
        ConfigurableJointExtensions.SetTargetRotationLocal(joint, animatedRigidbody.transform.localRotation, startLocalRotation);
    }
}
