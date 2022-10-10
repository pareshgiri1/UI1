
public class GameOverCanvas : UIBase
{
    
    public void MainMenu()
    {
        ScreenManager.instance.OpenScreen(ScreenType.MainMenu);
    }
    public override void Back()
    {
        base.Back();
        MainMenu();
    }
}

