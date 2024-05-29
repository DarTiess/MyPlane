namespace Input
{
    public class MobileInputService : InputService
    {
        public override float GetHorizontal => SimpleInput.GetAxis(HORIZONTAL);
        public override float GetVertical=> SimpleInput.GetAxis(VERTICAL);
    }
}