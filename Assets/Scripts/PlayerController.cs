using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedMovement;
    private Gunfire _gunfire;
    // Start is called before the first frame update
    void Start()
    {
        _gunfire = GetComponent<Gunfire>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontRotate = Input.GetAxis("Horizontal");
        float verticalRotate = Input.GetAxis("Vertical");
        Vector3 rotate = new Vector3(0, horizontRotate, 0);
        Vector3 movement = new Vector3(0, verticalRotate, 0);
        transform.Rotate(rotate, _speedRotate);
        transform.Translate(movement * _speedMovement * Time.deltaTime);
        _gunfire.Shoot();
    }
}
