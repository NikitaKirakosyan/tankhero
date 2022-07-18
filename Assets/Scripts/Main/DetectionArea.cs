/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DetectionArea : MonoBehaviour
{
    [SerializeField, Min(1)] private float _radius = 6.0f;

    private SphereCollider _sphereCollider = null;

    public abstract Action OnTargetFinded { get; set; }
    public abstract Action OnTargetLost { get; set; }

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