using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    private bool collected;
    public int healAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !collected)
        {
            PlayerHealthController.Instance.HealPlayer(healAmount);

            Destroy(gameObject);

            AudioManager.Instance.PlaySFX(5);
        }
    }
}
