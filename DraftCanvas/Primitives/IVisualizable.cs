
namespace DraftCanvas.Primitives
{
    public interface IVisualizable : IDirty
    {
        DrawingVisualEx GetVisual();
    }
}
