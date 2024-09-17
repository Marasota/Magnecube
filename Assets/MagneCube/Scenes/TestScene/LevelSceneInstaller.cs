using UnityEngine;
using Zenject;

public class LevelSceneInstaller : MonoInstaller
{
    [SerializeField] private Character _player;
    [SerializeField] private DesktopInputController _desktopInputController;
    [SerializeField] private MobileInputController _mobileInputController;

    public override void InstallBindings()
    {
        Container.Bind<IControllable>().To<Character>().FromInstance(_player).AsSingle();
        //Container.Bind<Character>().FromInstance(_player).AsSingle();
        Container.QueueForInject(_player);
        Debug.Log("PLAYER BINDED");

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Container.BindInterfacesAndSelfTo<DesktopInputController>().FromInstance(_desktopInputController).AsSingle();
            Debug.Log($"DESKTOP INPUT BINDED!");
            _desktopInputController.gameObject.SetActive(true);
            _mobileInputController.gameObject.SetActive(false);
        }
        else
        {
            Container.BindInterfacesAndSelfTo<MobileInputController>().FromInstance(_mobileInputController).AsSingle();
            _desktopInputController.gameObject.SetActive(false);
            _mobileInputController.gameObject.SetActive(true);
        }
    }
}
