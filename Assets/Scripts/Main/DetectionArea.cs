/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DetectionArea : MonoBehaviour
{
    [SerializeField, Min(1)] private float _radius = 6.0f;

    private SphereCollider _sphereCollider = null;

    private void OnValidate()
    {
        if (_sphereCollider == null)
        {
            _sphereCollider = GetComponent<SphereCollider>();
        }

        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = _radius;
    }
}