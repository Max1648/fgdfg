using System.Collections;
using System.Collections.Generic;
using SaveLoadData;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{

    public int currentHealth = 5;

    public EnemyController theEC;   

    [SerializeField] private EnemyData _enemyData;

    public EnemyData GetEnemyData()
    {

        return _enemyData;
    }     

    void Awake()
    {
        // _enemyData.SetEnemy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (theEC != null)
        {
            theEC.GetShot();
        }

        if (currentHealth <= 0)
        {
           // GameManager.Instance.AddObjectToDestroy(gameObject);
           // Destroy(gameObject);
            gameObject.SetActive(false);
            _enemyData.SetIsDied(true);

            AudioManager.Instance.PlaySFX(2);
        }
    }
}
