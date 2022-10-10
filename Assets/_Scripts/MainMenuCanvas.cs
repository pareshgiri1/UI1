
public class MainMenuCanvas : UIBase
{
    public void Play()
    {
        ScreenManager.instance.OpenScreen(ScreenType.GamePlay);
    }

    public void Setting()
    {
        PopUpManager.instance.OpenPopUp(PopUpType.Setting);
    }

    public override void Back()
    {
        base.Back();
        Setting();
    }
}
