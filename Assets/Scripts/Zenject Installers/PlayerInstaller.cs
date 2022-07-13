/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using Zenject;

namespace Tankhero.Zenject.Installers
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerModel _playerModel = null;
        [SerializeField] private PlayerView _playerView = null;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().FromInstance(_playerModel).AsSingle().NonLazy();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle().NonLazy();
        }
    }
}