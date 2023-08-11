using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private float _minRotationY;
    [SerializeField] private float _maxRotationY;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float clampRotation = Mathf.Clamp(transform.eulerAngles.y, _minRotationY, _maxRotationY);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, clampRotation,  transform.eulerAngles.z);
        if (transform.position.y < _minPositionY)
        {
            transform.position = new Vector3(transform.position.x, _minPositionY, transform.position.z);
        }
        if (transform.position.y > _maxPositionY)
        {
            transform.position = new Vector3(transform.position.x, _maxPositionY, transform.position.z);
        }
    }
}
