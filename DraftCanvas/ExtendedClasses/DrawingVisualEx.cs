using System.Windows.Media;

namespace DraftCanvas
{
    /// <summary>
    /// This one class extends DrawingVisual class with the ID and Tag properties.
    /// The extention helps us find out the visual object with tag or id in the visual collection.
    /// </summary>
    public sealed class DrawingVisualEx : DrawingVisual
    {
        private string _tag;
        private int _id;

        public DrawingVisualEx(string tag) : base()
        {
            _id = ++CanvasParam.Index;
            _tag = tag;
        }

        public int Id { get { return _id; } }
        public string Tag { get { return _tag; } }
    }
}
