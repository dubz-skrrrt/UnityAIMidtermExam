using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    private Node target;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        UI.SetActive(true);
    }


    public void HideUI()
    {
        UI.SetActive(false);
    }
}
