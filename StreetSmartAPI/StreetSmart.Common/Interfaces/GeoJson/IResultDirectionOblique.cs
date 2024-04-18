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

using StreetSmart.Common.Data.GeoJson;

namespace StreetSmart.Common.Interfaces.GeoJson
{
  /// <summary>
  /// Result direction of the observation of a oblique image
  /// </summary>
  public interface IResultDirectionOblique : IResultDirection
  {
    /// <summary>
    /// CamX
    /// </summary>
    double CamX { get; }

    /// <summary>
    /// CamY
    /// </summary>
    double CamY { get; }

    /// <summary>
    /// CamZ
    /// </summary>
    double CamZ { get; }

    /// <summary>
    /// FocalLength
    /// </summary>
    double FocalLength { get; }

    /// <summary>
    /// ImageWidth
    /// </summary>
    int ImageWidth { get; }

    /// <summary>
    /// ImageHeight
    /// </summary>
    int ImageHeight { get; }

    /// <summary>
    /// ppX
    /// </summary>
    double PpX { get; }

    /// <summary>
    /// ppY
    /// </summary>
    double PpY { get; }

    /// <summary>
    /// P1
    /// </summary>
    double P1 { get; }

    /// <summary>
    /// P2
    /// </summary>
    double P2 { get; }

    /// <summary>
    /// Rotated
    /// </summary>
    bool Rotated { get; }

    /// <summary>
    /// AvgFootprintHeight
    /// </summary>
    double AvgFootprintHeight { get; }

    /// <summary>
    /// RotationMatrix
    /// </summary>
    IMatrix RotationMatrix { get; }

    /// <summary>
    /// Roll
    /// </summary>
    double Roll { get; }

    /// <summary>
    /// Pitch
    /// </summary>
    double Pitch { get; }

    /// <summary>
    /// Heading
    /// </summary>
    double Heading { get; }

    /// <summary>
    /// Width
    /// </summary>
    int Width { get; }

    /// <summary>
    /// Height
    /// </summary>
    int Height { get; }

    /// <summary>
    /// Du
    /// </summary>
    double Du { get; }

    /// <summary>
    /// Dv
    /// </summary>
    double Dv { get; }

    /// <summary>
    /// K1
    /// </summary>
    double K1 { get; }

    /// <summary>
    /// K2
    /// </summary>
    double K2 { get; }

    /// <summary>
    /// F
    /// </summary>
    double F { get; }

    /// <summary>
    /// Z
    /// </summary>
    double Z { get; }

    /// <summary>
    /// PixelXY
    /// </summary>
    // ReSharper disable once InconsistentNaming
    double[] PixelXY { get; }

    /// <summary>
    /// Year
    /// </summary>
    int Year { get; }

    /// <summary>
    /// Rotation matrix
    /// </summary>
    IRotation Angle { get; }
  }
}
