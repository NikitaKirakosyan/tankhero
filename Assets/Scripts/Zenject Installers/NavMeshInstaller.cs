/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using Zenject;

namespace Tankhero.Zenject.Installers
{
    public sealed class NavMeshInstaller : MonoInstaller
    {
        [SerializeField] private NavMeshBuilder _navMeshBuilder = null;

        public override void InstallBindings()
        {
            Container.Bind<NavMeshBuilder>().FromInstance(_navMeshBuilder).AsSingle().NonLazy();
        }
    }
}