using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardsManager : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private KillCount killCount;
    [SerializeField] private GameObject rewards;
    [SerializeField] private int palierReward = 10;
    [SerializeField] private GameObject enemy;

    public UnityEvent afterDeath;
    public UnityEvent multipleShot;
    private bool pause;
    private int countValue;
    private void Awake()
    {
        countValue = killCount._value;
    }
    // Start is called before the first frame update
    void Start()
    {
        Button1();
    }

    // Update is called once per frame
    void Update()
    {
        countValue = killCount._value;
        if (countValue == palierReward && pause == false)
        {
            Pause();
            rewards.SetActive(true);
        }
        else if (countValue == palierReward+1)
        {
            pause = false;
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pause = true;
        Debug.Log("pause");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Debug.Log("resume");
        rewards.SetActive(false);
    }

    public void Button1()
    {
        afterDeath.AddListener(randomShotFromDeadEnemy);
    }
    public void randomShotFromDeadEnemy()
    {
        Vector3 enemyPos = enemy.transform.position;

        Vector3 direction = Vector3.zero;
        int rand = Random.Range(0, 3);
        if (rand == 0) direction = transform.forward;
        else if (rand == 1) direction = -transform.forward;
        else if (rand == 2) direction = -transform.right;
        else if (rand == 3) direction = transform.right;

        // Instancier le projectile et lui ajouter une force dans la direction calculée
        GameObject projectiles = Instantiate(projectile, new Vector3(transform.position.x, 1, transform.position.z), transform.rotation);
        Rigidbody rb = projectiles.GetComponent<Rigidbody>();
        rb.AddForce(direction * 5, ForceMode.VelocityChange);
     //   Instantiate(projectiles, transform.position, Quaternion.identity);
    }
}
