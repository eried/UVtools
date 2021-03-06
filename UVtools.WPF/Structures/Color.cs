﻿/*
 *                     GNU AFFERO GENERAL PUBLIC LICENSE
 *                       Version 3, 19 November 2007
 *  Copyright (C) 2007 Free Software Foundation, Inc. <https://fsf.org/>
 *  Everyone is permitted to copy and distribute verbatim copies
 *  of this license document, but changing it is not allowed.
 */
using System;
using Avalonia.Media;


namespace UVtools.WPF.Structures
{
    [Serializable]
    public class Color
    {
        public byte A;
        public byte R;
        public byte G;
        public byte B;

        public Color()
        { }

        public Color(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public Color(Color color)
            : this(color.A, color.R, color.G, color.B)
        {
        }

        public Color(Avalonia.Media.Color color)
            : this(color.A, color.R, color.G, color.B)
        {
        }

        public Color(SolidColorBrush brush)
            : this(brush.Color)
        {
        }

        public System.Drawing.Color ToDotNet()
        {
            return System.Drawing.Color.FromArgb(A, R, G, B);
        }

        public Avalonia.Media.Color ToAvalonia()
        {
            return new Avalonia.Media.Color(A, R, G, B);
        }

        public bool IsEmpty => ReferenceEquals(this, Empty);

        public static Color FromArgb(byte a, byte r, byte g, byte b)
        {
            return new Color(a, r, g, b);
        }

        public static Color Empty => new Color(0,0,0,0);

        public Color FactorColor(byte pixelColor, byte min = 0, byte max = byte.MaxValue) =>
            FactorColor(pixelColor / 255f, min, max);

        public Color FactorColor(float factor, byte min = 0, byte max = byte.MaxValue)
        {
            byte r = (byte)(R == 0 ? 0 :
                Math.Min(Math.Max(min, R * factor), max));

            byte g = (byte)(G == 0 ? 0 :
                Math.Min(Math.Max(min, G * factor), max));

            byte b = (byte)(B == 0 ? 0 :
                Math.Min(Math.Max(min, B * factor), max));
            return Color.FromArgb(A, r, g, b);
        }
    }
}
