/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using Zenject;

namespace Tankhero.Zenject.Installers
{
    public sealed class JoysticInstaller : MonoInstaller
    {
        [SerializeField] private MovementJoystic _movementJoystic = null;

        public override void InstallBindings()
        {
            Container.Bind<MovementJoystic>().FromInstance(_movementJoystic).AsSingle().NonLazy();
        }
    }
}