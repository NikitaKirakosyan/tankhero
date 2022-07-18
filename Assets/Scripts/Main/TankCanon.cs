/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public class TankCanon : MonoBehaviour
{
    public bool CanShoot { get; set; } = false;

    [Header("Canon Settings")]
    [SerializeField, Min(0.1f)] private float _reloadTimeInSeconds = 1.0f;
    private float _reloadTimer = 0.0f;

    [Header("Bullet Settings")]
    public Bullet[] bulletPrefabs = new Bullet[0];
    [SerializeField] private Transform _bulletSpawnPoint = null;
    public int CurrentBulletIndex { get; private set; } = 0;

    private void Update()
    {
        if (_reloadTimer > 0.0f)
        {
            _reloadTimer -= Time.deltaTime;
        }
        else if (CanShoot)
        {
            Shot();
            _reloadTimer = _reloadTimeInSeconds;
        }
    }

    public void SwitchBullet()
    {
        CurrentBulletIndex++;
        if (CurrentBulletIndex >= bulletPrefabs.Length)
        {
            CurrentBulletIndex = 0;
        }
    }

    private void Shot()
    {
        Bullet bulletPrefab = bulletPrefabs[CurrentBulletIndex];
        for (int i = 0; i < bulletPrefab.countPerShot; i++)
        {
            Bullet bulletInstance = Instantiate(bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            bulletInstance.Push();
        }
    }
}