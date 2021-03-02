using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color hoverErrorColor;
    public Vector3 positionOffest;
    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.materials[1].color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffest;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (turret != null)
        {
            rend.materials[1].color = hoverErrorColor;
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
                {
                    return;
                }
        BuildTurret(buildManager.getTurretToBuild());
    }

    void BuildTurret(TurretBluePrint blueprint)
    {
         if (GameSystem.money < blueprint.Cost)
        {
            Debug.Log("Not ENough money");
            return;
        }

        GameSystem.money -= blueprint.Cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = blueprint;
        GameObject bEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(bEffect, 5f);

        Debug.Log("Turret Build");
    }

    public void UpgradeTurret()
    {
        if (GameSystem.money <turretBluePrint.upgradeCost)
        {
            Debug.Log("Not ENough money to upgrade");
            return;
        }

        GameSystem.money -= turretBluePrint.upgradeCost;

        //destroying old turret
        Destroy(turret);

        //build upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject bEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(bEffect, 5f);
        isUpgraded = true;
        Debug.Log("Turret Upgraded");
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (GameSystem.money != 0){
            rend.materials[1].color = hoverColor;
        }else
        {
            rend.materials[1].color = hoverErrorColor;
        }
        

    }

    void OnMouseExit()
    {
        rend.materials[1].color = startColor; 
    }
}
