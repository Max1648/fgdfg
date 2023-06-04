using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "PlayerData", menuName = "Assets/Survival/PlayerData")]


public class PlayerData : ScriptableObject 
{
    [field: SerializeField] public List<Gun> AllGunData {get;private set;} = new List<Gun>();

    [field: SerializeField] public List<Gun> UnlockableGunData {get;private set;} = new List<Gun>();


    public bool GetIsEmpty()
    {
        return AllGunData.Count <= 0 && UnlockableGunData.Count <= 0;
    }

    public void SetData(List<Gun> allGunData, List<Gun> unlockableGunData)
    {
        AllGunData = allGunData;
        UnlockableGunData = unlockableGunData;
    }

    public void CLearData()
    {
        AllGunData.Clear();
        UnlockableGunData.Clear();
    }
}
 
