using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdol : MonoBehaviour
{
  void Start()
  {
    RagdolRigidbodiesClose(true);
    RagdollCollidersClose(false);
  }
  private void RagdolRigidbodiesClose(bool isActive)
  {
    Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
    foreach (var physicsOfChildObjects in rigidbodies)
    {
      physicsOfChildObjects.isKinematic = isActive;
    }
  }

  private void RagdollCollidersClose(bool isActive)
  {
    CapsuleCollider[] capsuleColliders = GetComponentsInChildren<CapsuleCollider>();
    foreach (var colliderOfChildObjects in capsuleColliders)
    {
      colliderOfChildObjects.enabled = isActive;
    }
  }

  public void ActivateOrDeactivateRagdoll(bool isRigiActive, bool isCollActive)
  {
    RagdolRigidbodiesClose(isRigiActive);
    RagdollCollidersClose(isCollActive);
  }
  
}
