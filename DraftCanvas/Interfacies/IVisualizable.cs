
namespace DraftCanvas
{
    public interface IVisualizable : IDirty
    {
        DrawingVisualEx GetVisual();
    }
}
