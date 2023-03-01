using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot2 : MonoBehaviour
{
    public Bullet       bulletScript;
    public GameObject   bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.ShootBullet(-transform.up);
        }
    }
}
