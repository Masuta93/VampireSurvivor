using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField] float m_speed = 30f;

    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
      //  _rigidbody.velocity = transform.forward * m_speed;

        Destroy(gameObject, 3);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    private Rigidbody _rigidbody;

    #endregion
}
