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

using StreetSmart.Common.Interfaces.GeoJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class MeasureDetails : DataConvert, IMeasureDetails, IEquatable<MeasureDetails>
  {
    public MeasureDetails(IDictionary<string, object> measureDetails, MeasurementTools measurementTool)
    {
      try
      {
        MeasureMethod = (MeasureMethod)ToEnum(typeof(MeasureMethod), measureDetails, "measureMethod");
      }
      catch (ArgumentException)
      {
        MeasureMethod = MeasureMethod.NotDefined;
      }

      var details = GetDictValue(measureDetails, "details");
      switch (MeasureMethod)
      {
        case MeasureMethod.DepthMap:
          Details = new DetailsDepth(details);
          break;
        case MeasureMethod.SmartClick:
          Details = new DetailsSmartClick(details);
          break;
        case MeasureMethod.ForwardIntersection:
          Details = new DetailsForwardIntersection(details, measurementTool);
          break;
        case MeasureMethod.AutoFocus:
        case MeasureMethod.NotDefined:
          Details = null;
          break;
      }

      PointProblems = new List<PointProblems>();
      var pointProblems = GetListValue(measureDetails, "pointProblems");
      foreach (var pointProblem in pointProblems)
      {
        switch (pointProblem?.ToString() ?? string.Empty)
        {
          case "ONE_OBSERVATION":
            PointProblems.Add(Interfaces.GeoJson.PointProblems.OneObservation);
            break;
          case "TOO_FEW_RECORDINGS":
            PointProblems.Add(Interfaces.GeoJson.PointProblems.TooFewRecordings);
            break;
          case "INVALID_ANGLE":
            PointProblems.Add(Interfaces.GeoJson.PointProblems.InvalidAngle);
            break;
          case "POINT_TOO_FAR":
            PointProblems.Add(Interfaces.GeoJson.PointProblems.PointTooFar);
            break;
          case "STANDARD_DEVIATION":
            PointProblems.Add(Interfaces.GeoJson.PointProblems.StandardDeviation);
            break;
        }
      }

      string pointReliability = ToString(measureDetails, "pointReliability");
      switch (pointReliability)
      {
        case "RELIABLE":
          PointReliability = Reliability.Reliable;
          break;
        case "ACCEPTABLE":
          PointReliability = Reliability.Acceptable;
          break;
        case "UNRELIABLE":
          PointReliability = Reliability.Unreliable;
          break;
        default:
          PointReliability = Reliability.NotDefined;
          break;
      }
    }

    public MeasureDetails(IMeasureDetails measureDetails, MeasurementTools measurementTool)
    {
      if (measureDetails == null)
      {
        return;
      }

      MeasureMethod = measureDetails.MeasureMethod;

      switch (measureDetails.MeasureMethod)
      {
        case MeasureMethod.DepthMap:
          Details = new DetailsDepth((IDetailsDepth)measureDetails.Details);
          break;
        case MeasureMethod.SmartClick:
          Details = new DetailsSmartClick((IDetailsSmartClick)measureDetails.Details);
          break;
        case MeasureMethod.ForwardIntersection:
          Details = new DetailsForwardIntersection((IDetailsForwardIntersection)measureDetails.Details, measurementTool);
          break;
        case MeasureMethod.AutoFocus:
        case MeasureMethod.NotDefined:
          Details = null;
          break;
      }

      if (measureDetails.PointProblems != null)
      {
        PointProblems = [.. measureDetails.PointProblems];
      }

      PointReliability = measureDetails.PointReliability;
    }

    public MeasureDetails()
    {
      MeasureMethod = MeasureMethod.unknown;
      PointProblems = [];
    }

    public MeasureMethod MeasureMethod { get; }

    public IDetails Details { get; }

    public IList<PointProblems> PointProblems { get; }

    public Reliability PointReliability { get; }

    public override string ToString()
    {
      var sb = new StringBuilder();

      sb.Append('[');
      sb.Append(string.Join(",", PointProblems.Select(problem => $"\"{problem.Description()}\"")));
      sb.Append(']');

      return $"{{\"measureMethod\":\"{MeasureMethod.Description()}\",\"details\":{Details?.ToString() ?? "{}"},\"pointProblems\":{sb},\"pointReliability\":\"{PointReliability.Description()}\"}}";
    }

    public bool Equals(MeasureDetails other)
    {
      if (other == null)
      {
        return false;
      }

      if (PointProblems == null != (other.PointProblems == null))
      {
        return false;
      }

      if (PointProblems != null && other.PointProblems != null)
      {
        if (PointProblems.Count == other.PointProblems.Count)
        {
          for (int i = 0; i < PointProblems.Count; i++)
          {
            if (!PointProblems[i].Equals(other.PointProblems[i]))
            {
              return false;
            }
          }
        }
        else
        {
          return false;
        }
      }

      return MeasureMethod.Equals(other.MeasureMethod) &&
             Details == other.Details &&
             PointReliability.Equals(other.PointReliability);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as MeasureDetails);
    }

    public override int GetHashCode() => (PointProblems, MeasureMethod, Details, PointReliability).GetHashCode();
  }
}
