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
using System.Windows.Input;

namespace StreetSmart.WPF.Example
{
  public class DelegateCommand : ICommand
  {
    private readonly Action _action;

    public DelegateCommand(Action action)
    {
      _action = action;
    }

    public void Execute(object parameter)
    {
      _action();
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public event EventHandler CanExecuteChanged;
  }
}
