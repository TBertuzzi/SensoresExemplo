using System;
using System.Windows.Input;

namespace SensoresExemplo.ViewModels
{
    public interface ISensorModel
    {

        string Title { get; }
        ICommand Toggle { get; }
        string ValueName { get; }
        string Value { get; }
        string ToggleText { get; }
    }
}
