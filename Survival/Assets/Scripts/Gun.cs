using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;

    public bool canAutoFire;
    public float fireRate;

    [HideInInspector]
    public float fireCounter;

    public int currentAmmo;
    public int pickupAmount;

    public Transform firepoint;

    public float zoomAmount;

    public string gunName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }

    public void GetAmmo()
    {  
    int maxAmmo = GetMaxAmmo();  

    if (currentAmmo < maxAmmo)
    {
        currentAmmo += pickupAmount;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        UIController.Instance.ammoText.text = "Патрони: " + currentAmmo;
    }   
    }


    private int GetMaxAmmo()
    {    
    if (gunName == "pistol")
    {
        return 60;
    }
    else if (gunName == "repeater")
    {
        return 120;
    }
    else if (gunName == "sniper")
    {
        return 15;
    }
     else if (gunName == "rocket launcher")
    {
        return 5;
    }    
    return 0;
    }   
}
