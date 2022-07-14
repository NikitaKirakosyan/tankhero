/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public abstract class TankModel : MonoBehaviour
{
    [Header("Tank Characteristics")]
    public int health = 5;

    [Header("Parts of Tank")]
    public float tankHeadAngularSpeed = 10.0f;
    [SerializeField] private Transform _tankHead = null;
    public Transform TankHead => _tankHead;

    private Rigidbody _rigidbody = null;
    public Rigidbody Rigidbody => _rigidbody == null ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody;

    protected T InitializeDetectionArea<T>(string newDetectionAreaName = "Detection Area") where T : DetectionArea
    {
        GameObject detectionArea = new GameObject(newDetectionAreaName);
        detectionArea.transform.SetParent(transform);
        detectionArea.transform.localPosition = Vector3.zero;

        return detectionArea.AddComponent(typeof(T)) as T;
    }
}