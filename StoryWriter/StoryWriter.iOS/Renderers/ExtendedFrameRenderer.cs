using System;
using System.ComponentModel;
using StoryWriter.iOS.Renderers;
using StoryWriter.Views.Layouts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedFrame), typeof(ExtendedFrameRenderer))]
namespace StoryWriter.iOS.Renderers
{
    public class ExtendedFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                // update frame's shadow
                UpdateShadow();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // check if property is the frame's shadow
            if (e.PropertyName == ExtendedFrame.ShadowOffsetProperty.PropertyName ||
                e.PropertyName == ExtendedFrame.ShadowOpacityProperty.PropertyName ||
                e.PropertyName == ExtendedFrame.ShadowRadiusProperty.PropertyName)
            {
                UpdateShadow();
            }
            else
            {
                base.OnElementPropertyChanged(sender, e);
            }
        }

        private void UpdateShadow()
        {
            if (Element.HasShadow)
            {
                // update it
                var extendedFrame = Element as ExtendedFrame;
                Layer.ShadowOpacity = extendedFrame.ShadowOpacity;
                Layer.ShadowOffset = new CoreGraphics.CGSize(extendedFrame.ShadowOffset.X, extendedFrame.ShadowOffset.Y);
                Layer.ShadowRadius = extendedFrame.ShadowRadius;
            }
            else
            {
                Layer.ShadowOpacity = 0;
            }
        }
    }
}
