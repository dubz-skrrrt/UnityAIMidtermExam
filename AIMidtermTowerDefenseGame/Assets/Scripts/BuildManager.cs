using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one build manager in scene");
            return;
        }
        instance = this;

    }


    public GameObject buildEffect;

    private TurretBluePrint turretToBuild;
    private Node SelectedNodeTurret;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (SelectedNodeTurret == node)
        {
            DeselectNode();
            return;
        }
        SelectedNodeTurret = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);

    }

    public void DeselectNode()
    {
        SelectedNodeTurret = null;
        nodeUI.HideUI();
    }

    public TurretBluePrint getTurretToBuild()
    {
        return turretToBuild;
    }
}
