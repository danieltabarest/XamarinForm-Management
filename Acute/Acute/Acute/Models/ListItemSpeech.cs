using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Acute.Models
{
    public class ListItemSpeech
    {
        public bool IsBot { get; set; }
        public string From { get; set; }
        public string Text { get; set; }
        public Command Command { get; set; }
    }
}
