using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XRSharpSamplesGallery
{
    public static class SampleAttachedProperties
    {
        public static double GetBorderRadius(DependencyObject obj)
        {
            return (double)obj.GetValue(BorderRadiusProperty);
        }

        public static void SetBorderRadius(DependencyObject obj, double value)
        {
            obj.SetValue(BorderRadiusProperty, value);
        }

        public static readonly DependencyProperty BorderRadiusProperty =
            DependencyProperty.RegisterAttached(
                name: "BorderRadius",
                propertyType: typeof(double),
                ownerType: typeof(SampleAttachedProperties),
                defaultMetadata: new PropertyMetadata(defaultValue: 0d)
                {
                    MethodToUpdateDom = BorderRadius_MethodToUpdateDom
                });


        /// <summary>
        /// This method is called when the DOM tree is rendered.
        /// </summary>
        /// <param name="d">The dependency object to which the property is attached</param>
        /// <param name="newValue">The new value of the attached property</param>
        public static void BorderRadius_MethodToUpdateDom(DependencyObject d, object newValue)
        {
            if (d is FrameworkElement)
            {
                // Get a reference to the <div> DOM element used to render the UI element:
                object div = OpenSilver.Interop.GetDiv((FrameworkElement)d);

                // Set the "BorderRadius" attribute on the <div> via a JavaScript interop call:
                OpenSilver.Interop.ExecuteJavaScript("$0.style.borderRadius = $1", div, newValue.ToString() + "px");

                //Note: for documentation related to the commands above, please refer to:
                // https://doc.opensilver.net/documentation/general/javascript-interop-and-libraries.html
                // and
                // https://doc.opensilver.net/documentation/in-depth-topics/call-javascript-from-csharp.html
            }
        }

        public static double GetImageBorderRadius(DependencyObject obj)
        {
            return (double)obj.GetValue(ImageBorderRadiusProperty);
        }

        public static void SetImageBorderRadius(DependencyObject obj, double value)
        {
            obj.SetValue(ImageBorderRadiusProperty, value);
        }

        public static readonly DependencyProperty ImageBorderRadiusProperty =
            DependencyProperty.RegisterAttached(
                name: "ImageBorderRadius",
                propertyType: typeof(double),
                ownerType: typeof(SampleAttachedProperties),
                defaultMetadata: new PropertyMetadata(defaultValue: 0d)
                {
                    MethodToUpdateDom = ImageBorderRadius_MethodToUpdateDom
                });

        /// <summary>
        /// This method is called when the DOM tree is rendered.
        /// </summary>
        /// <param name="d">The dependency object to which the property is attached</param>
        /// <param name="newValue">The new value of the attached property</param>
        public static void ImageBorderRadius_MethodToUpdateDom(DependencyObject d, object newValue)
        {
            if (d is FrameworkElement)
            {
                // Get a reference to the <div> DOM element used to render the UI element:
                object div = OpenSilver.Interop.GetDiv((FrameworkElement)d);

                // Set the "BorderRadius" attribute on the <div> via a JavaScript interop call:
                OpenSilver.Interop.ExecuteJavaScript("$0.firstChild.style.borderRadius = $1", div, newValue.ToString() + "px");

                //Note: for documentation related to the commands above, please refer to:
                // https://doc.opensilver.net/documentation/general/javascript-interop-and-libraries.html
                // and
                // https://doc.opensilver.net/documentation/in-depth-topics/call-javascript-from-csharp.html
            }
        }

        public static string GetBoxShadow(DependencyObject obj)
        {
            return (string)obj.GetValue(BoxShadowProperty);
        }

        public static void SetBoxShadow(DependencyObject obj, string value)
        {
            obj.SetValue(BoxShadowProperty, value);
        }

        public static readonly DependencyProperty BoxShadowProperty =
            DependencyProperty.RegisterAttached(
                name: "BoxShadow",
                propertyType: typeof(string),
                ownerType: typeof(SampleAttachedProperties),
                defaultMetadata: new PropertyMetadata(defaultValue: null)
                {
                    MethodToUpdateDom = BoxShadow_MethodToUpdateDom
                });

        /// <summary>
        /// This method is called when the DOM tree is rendered.
        /// </summary>
        /// <param name="d">The dependency object to which the property is attached</param>
        /// <param name="newValue">The new value of the attached property</param>
        public static void BoxShadow_MethodToUpdateDom(DependencyObject d, object newValue)
        {
            if (d is FrameworkElement)
            {
                // Convert the value to string:
                string value = (newValue != null ? newValue.ToString() : "");

                // Get a reference to the <div> DOM element used to render the UI element:
                object div = OpenSilver.Interop.GetDiv((FrameworkElement)d);

                // Set the "BorderRadius" attribute on the <div> via a JavaScript interop call:
                OpenSilver.Interop.ExecuteJavaScript("$0.style.boxShadow = $1", div, value);

                //Note: for documentation related to the commands above, please refer to:
                // https://doc.opensilver.net/documentation/general/javascript-interop-and-libraries.html
                // and
                // https://doc.opensilver.net/documentation/in-depth-topics/call-javascript-from-csharp.html
            }
        }
    }
}
