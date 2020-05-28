using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;


public class PlayerHealthController : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")] public int currentHealth = maxHealth;
    public RectTransform healthbar;


    public void TakeDamage(int amount)
    {
        Debug.Log("Entered code!");
        if (!isServer)
        {
            return;
        }
        Debug.Log("Passed server test!");
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead");
        }
        Debug.Log("Took Damage!");
    }

    void OnChangeHealth(int health)
    {
        Debug.Log("HEALTH CHANGING");
        healthbar.sizeDelta = new Vector2(health * 2, healthbar.sizeDelta.y);
        currentHealth = health;
    }
}
