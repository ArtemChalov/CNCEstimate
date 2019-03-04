
namespace DraftCanvas
{
    public interface IPrimitive : IVisualObject
    {
        bool SetPoint(double newX, double newY, int pointIndex);
    }
}
