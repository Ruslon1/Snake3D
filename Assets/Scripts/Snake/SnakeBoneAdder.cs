using UnityEngine;
using UnityEngine.Events;

public class SnakeBoneAdder : MonoBehaviour
{
    [SerializeField] private SnakeHead _head;
    [SerializeField] private SnakeBone _boneTemplate;

    public void AddSnakeBone()
    {
        SnakeBone bone = Instantiate(_boneTemplate, GetLastBonePostion() - Vector3.forward, Quaternion.identity, transform);
        bone.HookUpJoint(GetLastBoneRigidbody());
        _head.AddBonesToArray(bone);
    }

    private Rigidbody GetLastBoneRigidbody()
    {
        return _head.Bones[_head.Bones.Count - 1].Rigidbody;
    }

    private Vector3 GetLastBonePostion()
    {
        return _head.Bones[_head.Bones.Count - 1].transform.position;
    }
}