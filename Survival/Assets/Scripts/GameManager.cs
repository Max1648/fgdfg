using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public SaveLoadData.SaveLoadData SaveLoadData;

    public float waitAfterDying = 2f;

    [HideInInspector]
    public bool levelEnding;

    private List<GameObject> objectsToDestroy;

    private void Awake()
    {

      Instance = this;
      if (Instance == null)
                Instance = this;
            if (Instance != this)
            {
                Destroy(this.gameObject);
                
                return;
            } 
          //  DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //objectsToDestroy = new List<GameObject>();

    }   
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PlayerDied()
    {
        StartCoroutine(PlayerDiedCo());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public IEnumerator PlayerDiedCo()
    {
        yield return new WaitForSeconds(waitAfterDying);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseUnpause()
    {
        if (UIController.Instance.pauseScreen.activeInHierarchy)
        {

            UIController.Instance.pauseScreen.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1f;

            PlayerController.Instance.footstepFast.Play();
            PlayerController.Instance.footstepSlow.Play();

        } else
        {
            UIController.Instance.pauseScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;

            PlayerController.Instance.footstepFast.Stop();
            PlayerController.Instance.footstepSlow.Stop();
        }
    }
}
