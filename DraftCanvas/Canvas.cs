using DraftCanvas.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DraftCanvas
{
    public class Cavvv : FrameworkElement
    {
        private List<Visual> _visualsCollection;

        #region DependencyProperties Registration

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(Cavvv), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        #endregion

        public Cavvv()
        {
            _visualsCollection = new List<Visual>();
            ClipToBounds = true;
            AddToVisualCollection(new DcLineSegment(10, 10, 50, 800).GetVisual());
        }

        #region Properties

         ///<summary>
         /// Gets or sets a Brush that is used to fill the Canvas area
         ///</summary>
        public Brush Background
        {
            get { return (Brush)this.GetValue(Cavvv.BackgroundProperty); }
            set { SetValue(BackgroundProperty, (object)value); }
        }

        #endregion

        // Adds a new visual child
        private void AddToVisualCollection(DrawingVisual visual)
        {
            _visualsCollection.Add(visual);
            AddVisualChild(visual);
        }

        #region Overrided Methods

        protected override void OnRender(DrawingContext dc)
        {
            Brush background = this.Background;
            if (background == null)
                return;
            if (background.CanFreeze)
                background.Freeze();
            Size renderSize = this.RenderSize;
            dc.DrawRectangle(background, null, new Rect(0.0, 0.0, renderSize.Width, renderSize.Height));
        }

        protected override int VisualChildrenCount
        {
            get { return _visualsCollection.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return _visualsCollection[index];
        }

        #endregion
    }
}
