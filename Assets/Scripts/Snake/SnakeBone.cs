using System;
using UnityEngine;

public class SnakeBone : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private HingeJoint _joint;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _joint = GetComponent<HingeJoint>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void DisableMeshRenderer()
    {
        _meshRenderer.enabled = false;
    }
    public void EnabledMeshRenderer()
    {
        _meshRenderer.enabled = true;
    }

    public void HookUpJoint(Rigidbody to)
    {
        _joint.connectedBody = to;
    }
}