using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DealDamage : NetworkBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for client
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CmdDoDamage();
        }
    }
    [Command]
    void CmdDoDamage()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30.0f;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 3f);

        // hurt self
        //gameObject.GetComponent<PlayerHealthController>().TakeDamage(5);
    }
}
