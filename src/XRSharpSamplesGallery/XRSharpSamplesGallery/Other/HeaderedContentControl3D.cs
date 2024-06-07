using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XRSharp.Controls;

namespace XRSharpSamplesGallery.Other
{
    /// <summary>
    /// Provides the base implementation for controls that contain a single
    /// content element and a header.
    /// </summary>
    /// <remarks>
    /// HeaderedContentControl3D adds Header and HeaderTemplatefeatures to a
    /// ContentControl3D.
    /// </remarks>
    public class HeaderedContentControl3D : ContentControl3D
    {
        #region public Orientation3D Orientation
        /// <summary>
        /// Gets or sets the orientation by which the header and the content are stacked.
        /// </summary>
        /// <value>
        /// The orientation by which the header and the content are stacked. The default value is
        /// Orientation3D.YAxis.
        /// </value>
        public Orientation3D Orientation
        {
            get => (Orientation3D)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        /// <summary>
        /// Identifies the
        /// <see cref="HeaderedContentControl3D.Orientation" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="HeaderedContentControl3D.Orientation" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(
                nameof(Orientation),
                typeof(Orientation3D),
                typeof(HeaderedContentControl3D),
                new PropertyMetadata(Orientation3D.XAxis));

        #endregion public Orientation3D Orientation

        #region public object Header
        /// <summary>
        /// Gets or sets the content for the header of the control.
        /// </summary>
        /// <value>
        /// The content for the header of the control. The default value is
        /// null.
        /// </value>
        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        /// <summary>
        /// Identifies the
        /// <see cref="HeaderedContentControl3D.Header" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="HeaderedContentControl3D.Header" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty HeaderProperty =
                DependencyProperty.Register(
                        "Header",
                        typeof(object),
                        typeof(HeaderedContentControl3D),
                        new PropertyMetadata(OnHeaderPropertyChanged));

        /// <summary>
        /// HeaderProperty property changed handler.
        /// </summary>
        /// <param name="d">HeaderedContentControl whose Header property is changed.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs, which contains the old and new value.</param>
        private static void OnHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderedContentControl3D ctrl = (HeaderedContentControl3D)d;
            ctrl.OnHeaderChanged(e.OldValue, e.NewValue);
        }
        #endregion public object Header

        #region public DataTemplate HeaderTemplate
        /// <summary>
        /// Gets or sets the template that is used to display the content of the
        /// control's header.
        /// </summary>
        /// <value>
        /// The template that is used to display the content of the control's
        /// header. The default is null.
        /// </value>
        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the
        /// <see cref="HeaderedContentControl3D.HeaderTemplate" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="HeaderedContentControl3D.HeaderTemplate" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty HeaderTemplateProperty =
                DependencyProperty.Register(
                        "HeaderTemplate",
                        typeof(DataTemplate),
                        typeof(HeaderedContentControl3D),
                        new PropertyMetadata(OnHeaderTemplatePropertyChanged));

        /// <summary>
        /// HeaderTemplateProperty property changed handler.
        /// </summary>
        /// <param name="d">HeaderedContentControl3D whose HeaderTemplate property is changed.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs, which contains the old and new value.</param>
        private static void OnHeaderTemplatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HeaderedContentControl3D ctrl = (HeaderedContentControl3D)d;
            ctrl.OnHeaderTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue);
        }
        #endregion public DataTemplate HeaderTemplate

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderedContentControl" /> class.
        /// </summary>
        public HeaderedContentControl3D()
        {
            DefaultStyleKey = typeof(HeaderedContentControl3D);
        }

        /// <summary>
        /// Called when the value of the <see cref="HeaderedContentControl3D.Header" />
        /// property changes.
        /// </summary>
        /// <param name="oldHeader">
        /// The old value of the <see cref="HeaderedContentControl3D.Header" /> property.
        /// </param>
        /// <param name="newHeader">
        /// The new value of the <see cref="HeaderedContentControl3D.Header" /> property.
        /// </param>
        protected virtual void OnHeaderChanged(object oldHeader, object newHeader)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="HeaderedContentControl"D.HeaderTemplate" />
        /// property changes.
        /// </summary>
        /// <param name="oldHeaderTemplate">
        /// The old value of the <see cref="HeaderedContentControl3DD.HeaderTemplate" />
        /// property.
        /// </param>
        /// <param name="newHeaderTemplate">
        /// The new value of the <see cref="HeaderedContentControl3D.HeaderTemplate" />
        /// property.
        /// </param>
        protected virtual void OnHeaderTemplateChanged(DataTemplate oldHeaderTemplate, DataTemplate newHeaderTemplate)
        {
        }
    }
}
