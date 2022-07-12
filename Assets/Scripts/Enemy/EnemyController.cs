/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(EnemyModel))]
[RequireComponent(typeof(EnemyView))]
public sealed class EnemyController : MonoBehaviour
{
    private EnemyModel _model = null;
    private EnemyView _view = null;

    private void Awake()
    {
        _model = GetComponent<EnemyModel>();
        _view = GetComponent<EnemyView>();
    }
}