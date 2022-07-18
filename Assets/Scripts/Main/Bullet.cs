/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [Min(1)] public int countPerShot = 1;
    [SerializeField, Min(0)] private int _damage = 1;
    [SerializeField, Min(1)] private float _force = 1000;
    [SerializeField, Range(0, 10)] private float _delayToDestroy = 5;

    [Header("Tilt Settings")]
    [SerializeField] private bool _needToTilt = false;
    [SerializeField] private float _minXTilt = -5.0f;
    [SerializeField] private float _maxXTilt = 5.0f;
    [SerializeField] private float _minYTilt = -5.0f;
    [SerializeField] private float _maxYTilt = 5.0f;

    public Rigidbody Rigidbody { get; private set; } = null;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(gameObject, _delayToDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        var targetOfDamage = other.transform.GetComponent(typeof(ITakeDamage)) as ITakeDamage;
        if (targetOfDamage != null)
        {
            targetOfDamage.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    public void Push()
    {
        if (_needToTilt)
        {
            Tilt();
        }

        Rigidbody.AddForce(transform.forward * _force);
    }

    private void Tilt()
    {
        float xAngle = Random.Range(_minXTilt, _maxXTilt);
        float yAngle = Random.Range(_minYTilt, _maxYTilt);
        transform.eulerAngles = new Vector3(xAngle, transform.eulerAngles.y + yAngle, transform.eulerAngles.z);
    }
}