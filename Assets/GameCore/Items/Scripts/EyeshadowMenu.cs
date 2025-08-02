namespace GameCore
{
    public class EyeshadowMenu : MakeupItemMenu
    {
        private Brush _brush;

        private void Awake()
        {
            _brush = _item as Brush;
        }
    }
}