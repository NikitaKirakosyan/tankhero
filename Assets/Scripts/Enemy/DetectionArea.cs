/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public sealed class DetectionArea : MonoBehaviour
{
    [SerializeField, Min(1)] private float _radius = 6.0f;

    private void Awake()
    {
        SphereCollider areaCollider = GetComponent<SphereCollider>();
        areaCollider.radius = _radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null)
        {

        }
    }
}