
namespace DraftCanvas.Primitives
{
    public interface IVisualObject : IVisualizable
    {
        int ID { get; }
        string Tag { get; }
    }
}
