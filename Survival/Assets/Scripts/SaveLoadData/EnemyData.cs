using System;
using UnityEngine;

namespace SaveLoadData
{
    [Serializable]
    public class EnemyData : MonoBehaviour
    {
        [SerializeField] private GameObject _enemy;
        [field: SerializeField] public bool IsDied { get; private set; }

        public void SetIsDied(bool isDied)
        {
            IsDied = isDied;
        }

        public void SetEnemy(GameObject enemy)
        {
            _enemy = enemy;
        }

        public GameObject GetEnemy()
        {
            return _enemy;
        }
    }
}