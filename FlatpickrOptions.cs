using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FlatpickrBlazor
{
    public class FlatpickrOptions : IFlatpickrOptions {
        /// <summary>
        /// A string of characters which are used to define how the date will be displayed in the input box.
        /// </summary>
        /// <see href="https://flatpickr.js.org/formatting/"/>
        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; } = "d-m-Y";

        /// <summary>
        /// Displays the calendar inline.
        /// </summary>
        [JsonPropertyName("inline")]
        public bool Inline { get; set; } = false;

        /// <summary>
        /// Hides the day selection in calendar. Use it along with <see cref="EnableTime" /> to create a time picker.
        /// </summary>
        [JsonPropertyName("noCalendar")]
        public bool NoCalendar { get; set; } = false;

        /// <summary>
        /// Enables time picker.
        /// </summary>
        [JsonPropertyName("enableTime")]
        public bool EnableTime { get; set; } = false;

        /// <summary>
        /// Displays time picker in 24 hour mode without AM/PM selection when enabled.
        /// </summary>
        [JsonPropertyName("time_24hr")]
        public bool Time24Hours { get; set; } = false;

        /// <summary>
        /// Enables display of week numbers in calendar.
        /// </summary>
        [JsonPropertyName("weekNumbers")]
        public bool WeekNumbers { get; set; } = false;

        [JsonPropertyName("locale")]
        public string Locale { get; set; } = "default";

        /// <summary>
        /// The minimum date that a user can start picking from (inclusive).
        /// </summary>
        [JsonPropertyName("minDate")]
        public DateTimeOffset? MinDate { get; set; } = null;

        [JsonPropertyName("parseMinDate")]
        public bool ParseMinDate { get; set; } = false;

        /// <summary>
        /// The maximum date that a user can pick to (inclusive).
        /// </summary>
        [JsonPropertyName("maxDate")]
        public DateTimeOffset? MaxDate { get; set; } = null;

        [JsonPropertyName("parseMaxDate")]
        public bool ParseMaxDate { get; set; } = false;

        /// <summary>
        /// Adjusts the step for the hour input (incl. scrolling).
        /// </summary>
        [JsonPropertyName("hourIncrement")]
        public int HourIncrement { get; set; } = 1;

        /// <summary>
        /// Adjusts the step for the minute input (incl. scrolling).
        /// </summary>
        [JsonPropertyName("minuteIncrement")]
        public int MinuteIncrement { get; set; } = 5;

        /// <summary>
        /// Sets the initial selected date(s).
        /// If you're using mode: "multiple" or a range calendar supply an Array of Date objects or an Array of date strings which follow your dateFormat.
        /// Otherwise, you can supply a single Date object or a date string.
        /// </summary>
        [JsonPropertyName("defaultDate")]
        public List<string> DefaultDate { get; set; } = null;

        /// <see cref="FlatpickrOptionsMode"/>
        [JsonPropertyName("mode")]
        public FlatpickrOptionsMode Mode { get; set; } = FlatpickrOptionsMode.Single;

        /// <summary>
        /// Custom elements and input groups.
        /// </summary>
        /// <see href="https://flatpickr.js.org/examples/#flatpickr-external-elements"/>
        [JsonPropertyName("wrap")]
        public bool Wrap { get; set; } = false;
    }
}
