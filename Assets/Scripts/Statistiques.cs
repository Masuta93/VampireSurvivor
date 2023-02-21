using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistiques : MonoBehaviour
{
    [SerializeField] private IntVariable stats;

    private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        maxHealth = stats.maxHealth;
        currentHealth = stats.currentHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
