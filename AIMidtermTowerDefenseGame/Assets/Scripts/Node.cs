using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color hoverErrorColor;
    public Vector3 positionOffest;
    public GameObject turret;

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
        buildManager.BuildTurretOn(this);
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
