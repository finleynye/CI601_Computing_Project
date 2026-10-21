using UnityEngine;
public class BoneRenderToggle : MonoBehaviour
{
    private LineRenderer[] lines;

    void Awake()
    {
        lines = GetComponentsInChildren<LineRenderer>(true);

        
        foreach (var line in lines)
        {
            line.useWorldSpace = true;
            line.positionCount = line.transform.childCount * 2;
        }
    }

    void LateUpdate()
    {
        foreach (var line in lines)
        {
            Transform bone = line.transform;
            for (int i = 0; i < bone.childCount; i++)
            {
                line.SetPosition(i * 2, bone.position);
                line.SetPosition(i * 2 + 1, bone.GetChild(i).position);
            }
        }
    }
}
