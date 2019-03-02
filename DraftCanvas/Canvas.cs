using DraftCanvas.Primitives;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace DraftCanvas
{
    public class Canvas : FrameworkElement
    {
        private List<Visual> _visualsCollection;

        #region DependencyProperties Registration

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(Canvas), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        #endregion

        public Canvas(double width, double height)
        {
            this.Width = width;
            this.Height = height;

            _visualsCollection = new List<Visual>();
            ClipToBounds = true;

            CanvasParam.CanvasHeight = this.Height;
        }

        #region Properties

         ///<summary>
         /// Gets or sets a Brush that is used to fill the Canvas area
         ///</summary>
        public Brush Background
        {
            get { return (Brush)this.GetValue(Canvas.BackgroundProperty); }
            set { SetValue(BackgroundProperty, (object)value); }
        }

        #endregion

        #region Public Methods

        // Adds a new visual child
        public void AddToVisualCollection(Visual visual)
        {
            _visualsCollection.Add(visual);
            AddVisualChild(visual);
        }

        // Adds a new visual child
        public void AddToVisualCollection(IVisualizable visualElement)
        {
            Visual visual = visualElement.GetVisual();
            _visualsCollection.Add(visual);
            AddVisualChild(visual);
        }

        public void Update()
        {
            for (int i = 0; i < _visualsCollection.Count; i++)
            {
                if (((DrawingVisualEx)_visualsCollection[i]).IsDirty)
                {
                    DrawingVisualEx dv = (DrawingVisualEx)_visualsCollection[i];
                    RemoveVisualChild(dv);
                    _visualsCollection[i] = dv.VisualObject.GetVisual();
                    dv = null;

                    ((DrawingVisualEx)_visualsCollection[i]).IsDirty = false;
                    AddVisualChild(_visualsCollection[i]);
                    
                    //OnDraftUnitUpdated?.Invoke(this, new UnitEventArgs(draftUnit, Draft));
                }
            }
        }

        #endregion

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
