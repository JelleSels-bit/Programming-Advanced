using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOefeningen.viewmodel
{
    public partial class LabelViewModel : ObservableObject
    {
        // Observable properties declareren met kleine letter
        [ObservableProperty]
        string text, textColor;

        [ObservableProperty]
        int fontSize, padding;

        [ObservableProperty]
        FontAttributes fontAttributes;

        public LabelViewModel() 
        {
            //Observable properties met hoofdletters 
            Text = "Dit is een voorbeeld van binding";
            TextColor = "#AABBCC";
            FontAttributes = FontAttributes.Bold;
            FontSize = 40;
            Padding = 20;
        }
    }
}
