
namespace DraftCanvas.Primitives
{
    public interface IPrimitive : IVisualizable, IDirty
    {
        int ID { get; }
        string Tag { get; }
    }
}
