using System;
using System.Windows.Forms;

namespace Vinesauce_ROM_Corruptor.Components
{
    /// <summary>
    /// Custom TextBox for the byte corruption settings
    /// </summary>
    public sealed class ByteCorruptionTextBox : TextBox
    {
        private readonly bool hexOnly;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hexOnly">
        /// Whether or not to only allow hex numbers.
        /// If false, it will allow only positive integers
        /// </param>
        public ByteCorruptionTextBox(bool hexOnly)
        {
            this.hexOnly = hexOnly;
        }

        // Reset the textbox to a valid number if it's left blank
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (Text.Length == 0)
            {
                Text = "0";
            }
        }

        // Only allow either valid hex chars or only numbers
        // (depending on what's passed in the constructor)
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (hexOnly)
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = !Uri.IsHexDigit(e.KeyChar);
                }
            }
            else
            {
                if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
