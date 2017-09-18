using System;

using Xamarin.Forms;

namespace FMS
{
    public class CustomUnderLineLabel : Label
    {
        public CustomUnderLineLabel()
        {

        }

        public static readonly BindableProperty StartIndexProperty = BindableProperty.Create(propertyName: "StartIndex", returnType: typeof(int), declaringType: typeof(CustomUnderLineLabel), defaultValue: default(int));
        public int StartIndex { get; set; }

        public static readonly BindableProperty NoOfCharProperty = BindableProperty.Create(propertyName: "NoOfChar", returnType: typeof(int), declaringType: typeof(CustomUnderLineLabel), defaultValue: default(int));
        public int NoOfChar { get; set; }

        public static readonly BindableProperty EndIndexProperty = BindableProperty.Create(propertyName: "EndIndex", returnType: typeof(int), declaringType: typeof(CustomUnderLineLabel), defaultValue: default(int));
        public int EndIndex { get; set; }

        public static readonly BindableProperty ShallUnderLineProperty = BindableProperty.Create(propertyName: "ShallUnderLine", returnType: typeof(bool), declaringType: typeof(CustomUnderLineLabel), defaultValue: false);
        public bool ShallUnderLine { get; set; }
    }
}

