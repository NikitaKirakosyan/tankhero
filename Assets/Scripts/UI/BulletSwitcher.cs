/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Button))]
public sealed class BulletSwitcher : MonoBehaviour
{
    [SerializeField] private TankCanon _playerTankCanon = null;
    [SerializeField] private TextMeshProUGUI _bulletNameText = null;//Decoration

    public Button Button => GetComponent<Button>();

    private void Awake()
    {
        SetupCurrentBulletName();
    }

    private void OnEnable()
    {
        Button.onClick.AddListener(_playerTankCanon.SwitchBullet);
        Button.onClick.AddListener(SetupCurrentBulletName);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(_playerTankCanon.SwitchBullet);
        Button.onClick.RemoveListener(SetupCurrentBulletName);
    }

    /// <summary>
    /// Decoration Method
    /// </summary>
    private void SetupCurrentBulletName()
    {
        _bulletNameText.text = _playerTankCanon.bulletPrefabs[_playerTankCanon.CurrentBulletIndex].name;
    }
}
