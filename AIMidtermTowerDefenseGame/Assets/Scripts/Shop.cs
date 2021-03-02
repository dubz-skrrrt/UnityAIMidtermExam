using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint Ballista;
    public TurretBluePrint Cannon;
    public TurretBluePrint LaserBeamer;
    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectTurret_Ballista()
    {
        buildManager.SelectTurretBuild(Ballista);
    }

    public void SelectTurret_Cannon()
    {
        buildManager.SelectTurretBuild(Cannon);
    }
    public void SelectTurret_LaserBeamer()
    {
        buildManager.SelectTurretBuild(LaserBeamer);
    }
}
