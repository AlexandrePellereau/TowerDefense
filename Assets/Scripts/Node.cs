using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    
    [Header("Optional")]
    public GameObject turret;
    
    private Color startColor;
    private Renderer rend;
    
    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
        buildManager = BuildManager.instance;
    }
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;
        
        
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }
        
        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!buildManager.CanBuild)
            return;
        
        rend.material.color = buildManager.HasMoney ? hoverColor : notEnoughMoneyColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
