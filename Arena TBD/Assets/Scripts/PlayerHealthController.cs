using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;


public class PlayerHealthController : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthbar;
    private NetworkStartPosition[] spawnPoints;

    [SyncVar]
    public bool isActive = true;

    void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
        //gameObject.tag = "Player";
    }

    [Command]
    public void CmdAppearVisible(bool active)
    {
        isActive = active;
    }


    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Debug.Log("Going through");
            //gameObject.tag = "Dead";
            //CmdAppearVisible(false);
            currentHealth = maxHealth;
            RpcRespawn();
        }
    }

    void Update()
    {
        //activeComponents();
    }

    void activeComponents()
    {
        GetComponent<Renderer>().enabled = isActive;
        transform.GetChild(0).gameObject.SetActive(isActive);
        gameObject.GetComponent<Movement>().enabled = isActive;
        gameObject.GetComponent<DealDamage>().enabled = isActive;
    }

    void OnChangeHealth(int health)
    {
        healthbar.sizeDelta = new Vector2(health * 2, healthbar.sizeDelta.y);
        currentHealth = health;
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;

            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            transform.position = spawnPoint;

            gameObject.tag = "Player";
        }
    }
}
