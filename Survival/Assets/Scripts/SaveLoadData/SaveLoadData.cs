using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveLoadData
{
    public class SaveObject
    {
        public List<bool> EnemyObjects;

        public SaveObject(List<EnemyData> enemyData)
        {
            EnemyObjects = new List<bool>();
            for (int i = 0; i < enemyData.Count; i++)
            {
                EnemyObjects.Add(enemyData[i].IsDied);
            }
        }
    }

    [Serializable]
    public class SaveLoadData : MonoBehaviour
    {
        [field: SerializeField] private List<EnemyData> _enemyObjects;

        [field: SerializeField] private PlayerData _playerData;       

        private void Start()
        {            
            LoadData();
        }

        public void SaveData()
        {
            LocalDataManager.Save(new SaveObject(_enemyObjects));

            LocalDataManager.SavePlayerData(_playerData);
        }

        public void LoadData()
        {
            
            var enemyData = LocalDataManager.Load<SaveObject>();

            if (enemyData.EnemyObjects.Count <= 0 )
            {
                SaveData();
                LoadData();
                return;
            }

            for (int i = 0; i < _enemyObjects.Count; i++)
            {
                _enemyObjects[i].SetIsDied(enemyData.EnemyObjects[i]);
            }
            foreach (var enemy in _enemyObjects) 
            {
                enemy.GetEnemy().SetActive(!enemy.IsDied);
            }       

            LocalDataManager.LoadScritableObject(_playerData);

            //_playerData.SetData(playerData.AllGunData, playerData.UnlockableGunData);                                       
        }
    }
}