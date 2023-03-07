using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnerEnemies spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        print("Scène rechargée");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        spawnTimer.spawnTimer = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
