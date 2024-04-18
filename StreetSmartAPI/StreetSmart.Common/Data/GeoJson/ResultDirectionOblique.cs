/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2021, CycloMedia, All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */

using System;
using System.Collections.Generic;
using System.Globalization;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class ResultDirectionOblique : ResultDirection, IResultDirectionOblique
  {
    public double CamX { get; }

    public double CamY { get; }

    public double CamZ { get; }

    public double FocalLength { get; }

    public int ImageWidth { get; }

    public int ImageHeight { get; }

    public double PpX { get; }

    public double PpY { get; }

    public double P1 { get; }

    public double P2 { get; }

    public bool Rotated { get; }

    public double AvgFootprintHeight { get; }

    public IMatrix RotationMatrix { get; }

    public double Roll { get; }

    public double Pitch { get; }

    public double Heading { get; }

    public int Width { get; }

    public int Height { get; }

    public double Du { get; }

    public double Dv { get; }

    public double K1 { get; }

    public double K2 { get; }

    public double F { get; }

    public double Z { get; }

    // ReSharper disable once InconsistentNaming
    public double[] PixelXY { get; }

    public int Year { get; }

    public IRotation Angle { get; }

    public ResultDirectionOblique(Dictionary<string, object> resultDirection)
      : base(resultDirection)
    {
      CamX = ToDouble(resultDirection, "camX");
      CamY = ToDouble(resultDirection, "camY");
      CamZ = ToDouble(resultDirection, "camZ");
      FocalLength = ToDouble(resultDirection, "focalLength");
      ImageWidth = ToInt(resultDirection, "imageWidth");
      ImageHeight = ToInt(resultDirection, "imageHeight");
      PpX = ToDouble(resultDirection, "ppX");
      PpY = ToDouble(resultDirection, "ppY");
      P1 = ToDouble(resultDirection, "p1");
      P2 = ToDouble(resultDirection, "p2");
      Rotated = ToBool(resultDirection, "rotated");
      AvgFootprintHeight = ToDouble(resultDirection, "avgFootprintHeight");

      var rotationMatrix = GetDictValue(resultDirection, "rotationMatrix");
      RotationMatrix = new Matrix(rotationMatrix, 3, 3);

      Roll = ToDouble(resultDirection, "roll");
      Pitch = ToDouble(resultDirection, "pitch");
      Heading = ToDouble(resultDirection, "heading");
      Width = ToInt(resultDirection, "width");
      Height = ToInt(resultDirection, "height");
      Du = ToDouble(resultDirection, "du");
      Dv = ToDouble(resultDirection, "dv");
      K1 = ToDouble(resultDirection, "k1");
      K2 = ToDouble(resultDirection, "k2");
      F = ToDouble(resultDirection, "f");
      Z = ToDouble(resultDirection, "z");

      object[] array = GetArrayValue(resultDirection, "pixelXY");
      PixelXY = new double[2];
      PixelXY[0] = array.Length >= 1 ? (double) array[0] : 0.0;
      PixelXY[1] = array.Length >= 2 ? (double) array[1] : 0.0;

      Year = ToInt(resultDirection, "year");

      var angle = GetDictValue(resultDirection, "angle");

      if (angle != null && angle.Count >= 1)
      {
        Angle = new Rotation(angle);
      }
    }

    public ResultDirectionOblique(IResultDirectionOblique resultDirection)
      : base(resultDirection)
    {
      CamX = resultDirection.CamX;
      CamY = resultDirection.CamY;
      CamZ = resultDirection.CamZ;
      FocalLength = resultDirection.FocalLength;
      ImageWidth = resultDirection.ImageWidth;
      ImageHeight = resultDirection.ImageHeight;
      PpX = resultDirection.PpX;
      PpY = resultDirection.PpY;
      P1 = resultDirection.P1;
      P2 = resultDirection.P2;
      Rotated = resultDirection.Rotated;
      AvgFootprintHeight = resultDirection.AvgFootprintHeight;
      RotationMatrix = new Matrix(resultDirection.RotationMatrix);
      Roll = resultDirection.Roll;
      Pitch = resultDirection.Pitch;
      Heading = resultDirection.Heading;
      Width = resultDirection.Width;
      Height = resultDirection.Height;
      Du = resultDirection.Du;
      Dv = resultDirection.Dv;
      K1 = resultDirection.K1;
      K2 = resultDirection.K2;
      F = resultDirection.F;
      Z = resultDirection.Z;

      PixelXY = new double[2];
      PixelXY[0] = resultDirection.PixelXY.Length >= 1 ? resultDirection.PixelXY[0] : 0.0;
      PixelXY[1] = resultDirection.PixelXY.Length >= 2 ? resultDirection.PixelXY[1] : 0.0;

      Year = resultDirection.Year;

      if (resultDirection.Angle != null)
      {
        Angle = new Rotation(resultDirection.Angle);
      }
    }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string baseStr = base.ToString();
      int length = baseStr.Length;
      int start = Math.Min(1, length);
      baseStr = baseStr.Substring(start, length - start);
      string angleStr = Angle != null ? $",\"Angle\":{Angle}" : string.Empty;

      return
        $"{{\"camX\":{CamX.ToString(ci)},\"camY\":{CamY.ToString(ci)},\"camZ\":{CamZ.ToString(ci)},\"focalLength\":{FocalLength.ToString(ci)},\"imageWidth\":{ImageWidth}," +
        $"\"imageHeight\":{ImageHeight},\"ppX\":{PpX.ToString(ci)},\"ppY\":{PpY.ToString(ci)},\"p1\":{P1.ToString(ci)},\"p2\":{P2.ToString(ci)}," +
        $"\"rotated\":{Rotated.ToJsBool()},\"avgFootprintHeight\":{AvgFootprintHeight.ToString(ci)},\"rotationMatrix\": {RotationMatrix},\"roll\":{Roll.ToString(ci)}," +
        $"\"pitch\":{Pitch.ToString(ci)},\"heading\":{Heading.ToString(ci)},\"width\":{Width},\"height\":{Height},\"du\":{Du.ToString(ci)},\"dv\":{Dv.ToString(ci)}," +
        $"\"k1\":{K1.ToString(ci)},\"k2\":{K2.ToString(ci)},\"f\":{F.ToString(ci)},\"z\":{Z.ToString(ci)},\"pixelXY\":[{PixelXY[0].ToString(ci)},{PixelXY[1].ToString(ci)}]," +
        $"\"year\":{Year.ToString(ci)}{angleStr},{baseStr}";
    }
  }
}
