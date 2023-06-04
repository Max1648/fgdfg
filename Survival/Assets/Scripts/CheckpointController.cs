using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointController : MonoBehaviour
{
    public string cpName;     


    // Start is called before the first frame update
     void Start()
     {       

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_cp"))
        {
            if (PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_cp") == cpName)
            {
                PlayerController.Instance.transform.position = transform.position;
                Physics.SyncTransforms();
                Debug.Log("Player starting at " + cpName);
                GameManager.Instance.SaveLoadData.LoadData();
                GameManager.Instance.SaveLoadData.SaveData();
                // GameManager.Instance.DestroyObjects();
                // Debug.Log("Hit Player at " + transform.position);
            }
            else
            {
                GameManager.Instance.SaveLoadData.SaveData();
            }
        }
        else
        {
            GameManager.Instance.SaveLoadData.SaveData();
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.L))
        {
             PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp", "");
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp", cpName);
            Debug.Log("Player hit " + cpName);
            GameManager.Instance.SaveLoadData.SaveData();
            AudioManager.Instance.PlaySFX(1);
           // DestroyObjectsOnReturn();
        }
    }

    
}
