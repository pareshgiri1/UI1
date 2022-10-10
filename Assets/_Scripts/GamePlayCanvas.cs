
public class GamePlayCanvas : UIBase
{
    
    public void GameOver()
    {
        ScreenManager.instance.OpenScreen(ScreenType.GameOver);
    }
    public void Pause()
    {
        PopUpManager.instance.OpenPopUp(PopUpType.Pause);
    }
    public override void Back()
    {
        base.Back();
        Pause();
    }
}

