﻿using DraftCanvas.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using PM = DraftCanvas.Servicies.PointManager;

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

            //var points = CanvasCollections.Points;
            //points.Add(new DcPoint(10, 10));
            //points.Add(new DcPoint(210, 10));
            //points.Add(new DcPoint(210, 30));
            //points.Add(new DcPoint(30, 210));
            //points.Add(new DcPoint(10, 210));

            //for (int i = 0; i < CanvasCollections.Points.Count; i++)
            //{
            //    if (i + 1 < CanvasCollections.Points.Count)
            //    {
            //        AddToVisualCollection(new DcLineSegment(points[i], points[i + 1]).GetVisual());
            //    }
            //    if (i == (points.Count - 1))
            //    {
            //        AddToVisualCollection(new DcLineSegment(points[i], points[0]).GetVisual());
            //    }
            //}
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
        public void AddToVisualCollection(DrawingVisual visual)
        {
            _visualsCollection.Add(visual);
            AddVisualChild(visual);
        }

        // Adds a new visual child
        public void AddToVisualCollection(IVisualizable visualElement)
        {
            _visualsCollection.Add(visualElement.GetVisual());
            AddVisualChild(visualElement.GetVisual());
        }

        public void Update()
        {
            for (int i = 0; i < _visualsCollection.Count; i++)
            {
                if (((DrawingVisualEx)_visualsCollection[i]).IsDirty)
                {
                    DrawingVisualEx dv = (DrawingVisualEx)_visualsCollection[i];

                    RemoveVisualChild(dv);
                    _visualsCollection.RemoveAt(i);

                    DrawingVisualEx newDv = dv.VisualObject.GetVisual();
                    dv = null;
                    newDv.IsDirty = false;

                    _visualsCollection.Insert(i, newDv);
                    AddVisualChild(newDv);
                    
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
