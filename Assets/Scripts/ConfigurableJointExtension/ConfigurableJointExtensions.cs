using UnityEngine;

public static class ConfigurableJointExtensions
{
    public static void SetTargetRotationLocal(this ConfigurableJoint joint,
        Quaternion targetLocalRotation, Quaternion startLocalRotation)
    {
        if (joint.configuredInWorldSpace)
        {
            Debug.LogError("Animation sync needs a joint configured in local space.", joint);
            return;
        }

        //this code build joint space from its two configured axes
        Vector3 forward = Vector3.Cross(joint.axis, joint.secondaryAxis).normalized;
        Vector3 up = Vector3.Cross(forward, joint.axis).normalized;
        Quaternion jointSpace = Quaternion.LookRotation(forward, up);

        //this code turn animation pose backwards into joint space relative to rest pose
        joint.targetRotation = Quaternion.Inverse(jointSpace) *
            Quaternion.Inverse(targetLocalRotation) * startLocalRotation * jointSpace;
    }
}
