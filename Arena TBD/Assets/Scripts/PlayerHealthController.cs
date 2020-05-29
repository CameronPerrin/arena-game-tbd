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

    public void Start()
    {
        if(isLocalPlayer)
        {
            gameObject.tag = "Host Player";
        }
        else
        {
            gameObject.tag = "Connected Player";
        }
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
            currentHealth = maxHealth;
            RpcRespawn();
        }
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
            transform.position = Vector3.zero;
        }
    }
}
