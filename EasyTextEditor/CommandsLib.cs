using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasyTextEditor
{
    class CommandsLib
    {
        public static RoutedUICommand TextBold { get; set; }
        public static RoutedCommand ToggleRed { get; set; }
        public static RoutedCommand ToggleBlack { get; set; }
        public static RoutedCommand ChangeFontFamaly { get; set; }
        public static RoutedCommand ChangeFontSize { get; set; }

        static CommandsLib()
        {
            InputGestureCollection hotkeys = new InputGestureCollection();
            hotkeys.Add(new KeyGesture(Key.B, ModifierKeys.Control, "Ctrl+B"));
            TextBold = new RoutedUICommand("Жирный текст", "TextBold", typeof(CommandsLib), hotkeys);
            ToggleRed = new RoutedCommand("ToggleRed", typeof(CommandsLib));
            ToggleBlack = new RoutedCommand("ToggleBlack", typeof(CommandsLib));
            //ChangeFontFamaly = new RoutedCommand("ChangeFontFamaly", typeof(CommandsLib));
            //ChangeFontSize = new RoutedCommand("ChangeFontSize", typeof(CommandsLib));
        }
    }
}
