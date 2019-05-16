using Lean.Touch;

public class IntroSelectable : LeanSelectableBehaviour
{
    public delegate void delAfterClick(string name);
    public delAfterClick delAfter = null;

    // Use this for initialization
    protected override void OnSelect(LeanFinger finger)
    {
        delAfter.Invoke(gameObject.name);
    }
}
