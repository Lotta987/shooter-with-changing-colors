using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfire : MonoBehaviour
{
    [SerializeField] private GameObject[] _bullets;
    private GameObject _bulletInGun;
    [SerializeField] private float _shootUpForce;
    [SerializeField] private float _shootForceMax;
    [SerializeField] private float _shootForce;
    [SerializeField] private float _powerStep;
    [SerializeField] private float _speedIncreaseForce;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private MainCanvas _mainCanvas;
    private bool _isPressed;
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
    public void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomIndex = Random.Range(0, _bullets.Length);

            _bulletInGun = Instantiate(_bullets[randomIndex], transform.position, Quaternion.LookRotation(transform.forward, Vector3.up));
            _bulletInGun.GetComponent<Bullet>().onTargetHitted += TargetHitted;
            _isPressed = true;
            StartCoroutine(Pressing());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_bulletInGun != null)
            {
                _shootUpForce = _shootForce / 3f;
                Rigidbody bulletRB = _bulletInGun.GetComponent<Rigidbody>();
                bulletRB.isKinematic = false;
                bulletRB.AddForce(transform.forward * _shootForce, ForceMode.VelocityChange);
                bulletRB.AddForce(Vector3.up * _shootUpForce, ForceMode.VelocityChange);
                bulletRB.transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
                _isPressed = false;
                _shootForce = 0;
            }
        }
    }
    private IEnumerator Pressing()
    {
        while (_isPressed == true && _shootForce < _shootForceMax)
        {
            yield return new WaitForSeconds(_speedIncreaseForce);
            _shootForce += _powerStep;
            _mainCanvas.UpdatePowerText(_shootForce);
        }
    }
    private void TargetHitted()
    {
        _scoreCounter.ReceivePoints();

    }
}
