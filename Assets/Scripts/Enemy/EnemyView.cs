/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(EnemyModel))]
public sealed class EnemyView : MonoBehaviour, ITakeDamage
{
    private EnemyModel _model = null;

    private void Awake()
    {
        _model = GetComponent<EnemyModel>();
    }

    public void TakeDamage(int damage)
    {
        // _model.
    }
}