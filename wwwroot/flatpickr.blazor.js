window.flatpickrblazor = {
    create: function (element, options, pluginOptions, dotNetHelper) {
        element = this.__getElement(element);
        var opts = JSON.parse(options);
        var plugOpts = JSON.parse(pluginOptions);
        opts.plugins = [];

        if (plugOpts.UseMonthSelectPlugin !== null) {
            opts.plugins.push(new monthSelectPlugin(plugOpts.UseMonthSelectPlugin));
        }
        
        opts.onChange = function (selectedDates, dateStr, instance) {
            return dotNetHelper.invokeMethodAsync("OnChange", selectedDates);
        };

        opts.disable = [
            function (date) {

                var disabled = false;

                var promise = dotNetHelper.invokeMethodAsync("DateAvailable", date);
                Promise.resolve(promise).then(function (value) {
                    var val = !value;
                    console.log(date + " :" + val);
                    return val;
                }) 
                
                return disabled;
            }
        ]

        opts.onDayCreate = function (dObj, dStr, fp, dayElem) {
            // Utilize dayElem.dateObj, which is the corresponding Date

            if (dayElem !== null && dayElem.dateObj !== undefined) {                

                var eventMarkup = dotNetHelper.invokeMethodAsync("OnCreateDate", dayElem.dateObj);
                Promise.resolve(eventMarkup).then(function (value) {
                    dayElem.innerHTML += value;
                })                
            }        

            // dummy logic
            //if (Math.random() < 0.15)
            //    dayElem.innerHTML += "<span class='event'></span>";

            //else if (Math.random() > 0.85)
            //    dayElem.innerHTML += "<span class='event busy'></span>";
            
        };


        if (opts.maxDate !== null && opts.maxDate !== undefined && opts.parseMaxDate === true) {
            opts.maxDate = new Date(opts.maxDate);
        }
        if (opts.minDate !== null && opts.minDate !== undefined && opts.parseMinDate === true) {
            opts.minDate = new Date(opts.minDate);
        }
        flatpickr(element, opts);

        return dotNetHelper.invokeMethodAsync("OnCreate");
    },
    selectedDates: function (element) {
        element = this.__getElement(element);
        return element._flatpickr.selectedDates;
    },
    setDate: function (element, date, triggerChange, dateStrFormat) {
        element = this.__getElement(element);
        var parsedDate = new Date(date);
        element._flatpickr.setDate(parsedDate, triggerChange, dateStrFormat);
    },
    setDates: function (element, dates, triggerChange, dateStrFormat) {
        element = this.__getElement(element);
        var parsedDates = dates.map(date => new Date(date));
        element._flatpickr.setDate(parsedDates, triggerChange, dateStrFormat);
    },
    __getElement: function(element) {
        // .NET can return either an element itself, or its string id
        return this.__isString(element) ? document.getElementById(element) : element;
    },
    __isString: function(x) {
        return Object.prototype.toString.call(x) === "[object String]";
    }
};
