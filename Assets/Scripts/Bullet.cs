using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public event Action onTargetHitted = () => { };
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            MeshRenderer _meshRenderer = other.gameObject.GetComponent<MeshRenderer>();
            if (_meshRenderer.material.color == Color.green)
            {

                onTargetHitted?.Invoke();

                Destroy(other.gameObject);
            }            
            if (_meshRenderer.material.color == Color.red)
            {
                _meshRenderer.material.color = Color.green;
            }

        Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
