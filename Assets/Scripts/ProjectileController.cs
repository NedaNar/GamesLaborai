using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private Transform barrel;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private GameObject muzzlePrefab;

    [SerializeField]
    private UnityEvent onFire;

    private bool hasAmmo;

    // Update is called once per frame
    void Update()
    {
        if (IsFire())
        {
            Debug.Log("Fire");
            Fire();
        }
    }

    public void UpdateAmmo(int value)
    {
        Debug.Log(value);
        hasAmmo = value > 0;
        Debug.Log("ammo " + hasAmmo);
    }

    private bool IsFire()
    {
        return hasAmmo && Input.GetButtonDown("Fire1");
    }

    private void Fire()
    {

        CreateProjectile();
       // CreateMuzzleEffect();

        onFire.Invoke();
    }

    private void CreateMuzzleEffect()
    {
        Instantiate(muzzlePrefab, barrel.position, barrel.rotation);
    }

    private void CreateProjectile()
    {
        Instantiate(projectilePrefab, barrel.position, barrel.rotation);
    }
}
