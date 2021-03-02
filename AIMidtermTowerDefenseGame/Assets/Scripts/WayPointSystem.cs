using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointSystem : MonoBehaviour
{
    public static Transform[] wayPointNodes;

    void Awake()
    {
        wayPointNodes = new Transform[transform.childCount];
        for (int i = 0; i < wayPointNodes.Length; i++)
        {
            wayPointNodes[i] = transform.GetChild(i);
        }
    }
}
