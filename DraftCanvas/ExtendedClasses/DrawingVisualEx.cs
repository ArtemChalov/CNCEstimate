using DraftCanvas.Primitives;
using System.Windows.Media;

namespace DraftCanvas
{
    /// <summary>
    /// This one class extends DrawingVisual class with the ID and Tag properties.
    /// The extention helps us find out the visual object with tag or id in the visual collection.
    /// </summary>
    public sealed class DrawingVisualEx : DrawingVisual
    {
        IPrimitive _primitive;

        public DrawingVisualEx(IPrimitive primitive) : base()
        {
            _primitive = primitive;
        }

        public IPrimitive Primitive => _primitive;
        public int ID => _primitive.ID;
        public string Tag => _primitive.Tag;
    }
}
