/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public abstract class TankModel : MonoBehaviour
{
    [Header("Tank Characteristics")]
    [Min(0)] public int health = 5;
    [Min(1)] public int maxHealth = 5;
    [Min(0)] public int collisionDamage = 1;

    [Header("Parts of Tank")]
    public float tankHeadAngularSpeed = 10.0f;
    [SerializeField] private Transform _tankHead = null;
    public Transform TankHead => _tankHead;
    [SerializeField] private TankCanon _tankCanon = null;
    public TankCanon TankCanon => _tankCanon;

    private Rigidbody _rigidbody = null;
    public Rigidbody Rigidbody => _rigidbody == null ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody;

    private void OnValidate()
    {
        if (health > maxHealth)
        {
            maxHealth = health;
        }
    }

    protected T InitializeDetectionArea<T>(string newDetectionAreaName = "Detection Area") where T : DetectionArea
    {
        GameObject detectionArea = new GameObject(newDetectionAreaName);
        detectionArea.transform.SetParent(transform);
        detectionArea.transform.localPosition = Vector3.zero;

        return detectionArea.AddComponent(typeof(T)) as T;
    }

    public T GetDetectionArea<T>() where T : DetectionArea
    {
        return transform.GetComponentInChildren(typeof(T)) as T;
    }
}