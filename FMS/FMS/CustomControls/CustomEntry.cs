﻿using System;
using Xamarin.Forms;

namespace FMS
{
    public class CustomEntry : Entry
    {
        public CustomEntry()
        {
            TextColor = Color.FromHex("#282828");
            PlaceholderColor = Color.FromHex("#282828");
        }


        public static readonly BindableProperty CustomFontFamilyProperty = BindableProperty.Create(propertyName: "CustomFontFamily", returnType: typeof(string), declaringType: typeof(CustomEntry), defaultValue: default(string));
        public string CustomFontFamily { get; set; }

        public static readonly BindableProperty CustomFontSizeProperty = BindableProperty.Create(propertyName: "CustomFontSize", returnType: typeof(float), declaringType: typeof(CustomEntry), defaultValue: default(float));
        public float CustomFontSize { get; set; }

        public static readonly BindableProperty IsCustomPasswordProperty = BindableProperty.Create(propertyName: "IsCustomPassword", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
        public bool IsCustomPassword { get; set; }

        public static readonly BindableProperty IsPhoneProperty = BindableProperty.Create(propertyName: "IsPhoneNumber", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
        public bool IsPhoneNumber { get; set; }

        public static readonly BindableProperty IsNumericProperty = BindableProperty.Create(propertyName: "IsNumeric", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
        public bool IsNumeric { get; set; }

        public static readonly BindableProperty IsEmailProperty = BindableProperty.Create(propertyName: "IsEmail", returnType: typeof(bool), declaringType: typeof(CustomEntry), defaultValue: false);
        public bool IsEmail { get; set; }

        public static readonly BindableProperty BorderColorsProperty = BindableProperty.Create(propertyName: "BorderColors", returnType: typeof(string), declaringType: typeof(CustomEntry), defaultValue: "#000000");
        public string BorderColors { get; set; }
    }
}

