
namespace DraftCanvas.Primitives
{
    public interface IPrimitive : IVisualizable
    {
        int ID { get; }
        string Tag { get; }
    }
}
