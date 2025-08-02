namespace GameCore
{
    public class EyeshadowMenu : ColorableCosmeticMenu
    {
        private Brush _brush;

        private void Awake()
        {
            _brush = _item as Brush;
        }
    }
}