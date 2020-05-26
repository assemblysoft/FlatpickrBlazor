﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlatpickrBlazor
{
    public class FlatpickrJsHelper
    {
        private readonly Action<List<DateTimeOffset>> _onChange;
        private readonly Action _onCreate;
        private readonly Func<DateTime,string> _onCreateDate;
        private readonly Func<DateTime, bool> _available;

        public FlatpickrJsHelper(Action<List<DateTimeOffset>> onChange, Action onCreate,Func<DateTime, string> onCreateDate, Func<DateTime,bool>available)
        {
            _onChange = onChange;
            _onCreate = onCreate;
            _onCreateDate = onCreateDate;
            _available = available;
        }
        public List<DateTimeOffset> DateTimes { get; set; }
                  

        [JSInvokable]
        public void OnChange(DateTimeOffset[] dateTimes)
        {
            DateTimes = new List<DateTimeOffset>(dateTimes);
            _onChange?.Invoke(DateTimes);
        }

        [JSInvokable]
        public void OnCreate()
        {
            _onCreate?.Invoke();
        }

        [JSInvokable]
        public string OnCreateDate(DateTime dt)
        {
            return _onCreateDate?.Invoke(dt);
        }

        [JSInvokable]
        public bool? DateAvailable(DateTime dt)
        {
            return _available?.Invoke(dt);
        }        
    }
}
