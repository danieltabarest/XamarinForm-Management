// Credits: https://gist.github.com/rudyryk/8cbe067a1363b45351f6

using System;
using Xamarin.Forms;


namespace Acute.Controls
{
    public class ExpandableEditor : Editor { public ExpandableEditor() { this.TextChanged += (sender, e) => { this.InvalidateMeasure(); }; } }
}
