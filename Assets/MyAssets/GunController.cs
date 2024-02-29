using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public InputActionReference shoot;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float secondsBetweenShoot = 0.5f;
    float trackshoot;
    public bool singleShot;

    // Start is called before the first frame update
    void Start()
    {
        shoot.action.started += ShootDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!singleShot)
        {
            if (shoot.action.ReadValue<float>() == 1 && trackshoot <= 0)
            {
                ShootNow();
                trackshoot = secondsBetweenShoot;
            }
            trackshoot -= Time.deltaTime;
        }

    }

    void ShootDown(InputAction.CallbackContext context)
    {
        if (singleShot)
            ShootNow();
    }

    void ShootNow()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
