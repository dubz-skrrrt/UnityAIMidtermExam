using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    private Node target;

    public Text upgradeCost;
    public Button upgButton;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
            upgButton.interactable = true;
        }else
        {
            upgradeCost.text = "Maxed Out";
            upgButton.interactable = false;
        }

        UI.SetActive(true);
    }


    public void HideUI()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
