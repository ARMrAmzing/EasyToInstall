﻿using System.Windows.Forms;

namespace EasyToInstall
{
    public static class TopMostMessageBox
    {
        public static DialogResult Show(string message)
        {
            return Show(message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult Show(string message, string title)
        {
            return Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons)
        {
            return Show(message, title, buttons, MessageBoxIcon.Exclamation);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            // Create a host form that is a TopMost window which will be the 

            // parent of the MessageBox.

            Form topmostForm = new Form();
            // We do not want anyone to see this window so position it off the 

            // visible screen and make it as small as possible

            topmostForm.ShowInTaskbar = false;

            topmostForm.Size = new System.Drawing.Size(1, 1);
            topmostForm.StartPosition = FormStartPosition.Manual;
            var rect = SystemInformation.VirtualScreen;
            topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10, rect.Right + 10);
            topmostForm.Show();
            // Make this form the active form and make it TopMost

            topmostForm.Focus();
            topmostForm.BringToFront();
            topmostForm.TopMost = true;
            // Finally show the MessageBox with the form just created as its owner

            DialogResult result = MessageBox.Show(topmostForm, message, title, buttons, icon);
            topmostForm.Dispose(); // clean it up all the way

            return result;
        }
    }
}
