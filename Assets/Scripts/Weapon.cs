using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform aimtransform;
    // Start is called before the first frame update
    private void Awake()
    {
        aimtransform = transform.Find("Sword");
    }

    private void Update()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimtransform.eulerAngles = new Vector3(0, 0, angle);
    }
}
