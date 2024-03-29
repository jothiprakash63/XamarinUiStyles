﻿using Microsoft.AppCenter.Crashes;
using SkiaSharp.Extended.Svg;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace KantimeEvv.Helpers.UIControls
{
    public class SvgImage : SKCanvasView
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(SvgImage), default(string), propertyChanged: OnPropertyChanged);

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly BindableProperty AssemblyNameProperty = BindableProperty.Create(nameof(AssemblyName), typeof(string), typeof(SvgImage), default(string), propertyChanged: OnPropertyChanged);

        public string AssemblyName
        {
            get => (string)GetValue(AssemblyNameProperty);
            set => SetValue(AssemblyNameProperty, value);
        }

        static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var skCanvasView = bindable as SKCanvasView;
            skCanvasView?.InvalidateSurface();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            InvalidateSurface();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            InvalidateSurface();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            try
            {
                var surface = e.Surface;
                var canvas = surface.Canvas;

                canvas.Clear();

                if (string.IsNullOrEmpty(Source) || string.IsNullOrEmpty(AssemblyName))
                    return;

                var currentAssembly = Assembly.Load(AssemblyName);
                using (var stream = currentAssembly.GetManifestResourceStream(AssemblyName + "." + "Resources.Images."+ Source))
                {
                    var skSvg = new SKSvg();
                    skSvg.Load(stream);

                    var skImageInfo = e.Info;
                    canvas.Translate(skImageInfo.Width / 2f, skImageInfo.Height / 2f);

                    var skRect = skSvg.ViewBox;
                    float xRatio = skImageInfo.Width / skRect.Width;
                    float yRatio = skImageInfo.Height / skRect.Height;

                    float ratio = Math.Min(xRatio, yRatio);

                    canvas.Scale(ratio);
                    canvas.Translate(-skRect.MidX, -skRect.MidY);

                    canvas.DrawPicture(skSvg.Picture);
                }
            }
            catch (Exception exc)
            {
               Crashes.TrackError(exc);
            }
        }
    }
}
