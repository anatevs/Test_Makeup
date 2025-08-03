namespace GameCore
{
    public class BrushMenu : MakeupItemMenu
    {
        private Brush _brush;

        private void Awake()
        {
            _brush = _tool as Brush;
        }
    }
}