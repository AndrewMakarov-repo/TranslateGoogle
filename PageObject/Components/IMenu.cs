using Core.UI.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Components
{
    public interface IMenu
    {
        string SelectedLanguage { get; }
        void SelectLanguage(string language);
    }
}
