using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    
    BuildManager buildManager;
    
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
        Debug.Log("Standard Turret Selected!");
    }
    
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
        Debug.Log("Missile Launcher Selected!");
    }
    
    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
        Debug.Log("Laser Beamer Selected!");
    }
}
