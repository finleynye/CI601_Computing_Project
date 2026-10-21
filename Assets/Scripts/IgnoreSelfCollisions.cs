using System;
using UnityEngine;

public class IgnoreSelfCollisions : MonoBehaviour
{
    [SerializeField] private Collider thisCollider;

    [SerializeField] private Collider[] collidersToIgnore;
    void Start()
    {
        foreach(Collider otherCollider in collidersToIgnore)
        {
            Physics.IgnoreCollision(thisCollider, otherCollider, true);
        }   
    }
}
