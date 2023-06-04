using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveLoadData;

public class WeaponPickup : MonoBehaviour
{

    public string theGun;
    [SerializeField] private EnemyData enemyData;
    private bool collected;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player" && !collected)
        {
            PlayerController.Instance.AddGun(theGun);

           // Destroy(gameObject);

            collected = true;

            AudioManager.Instance.PlaySFX(4);

            enemyData.SetIsDied(true);
            gameObject.SetActive(false);
        }
    }
}
