using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjectMangerXamarin.Helpers
{
    public class EntryValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            entry.BackgroundColor = string.IsNullOrWhiteSpace(e.NewTextValue) ? Color.LightPink : Color.Default;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
