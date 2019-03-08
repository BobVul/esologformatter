using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace EsoLogFormatter.Helpers
{
    class MouseWheelScrollViewer : ScrollViewer
    {
        public MouseWheelScrollViewer() : base() { }

        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            OnMouseWheel(e);
            base.OnPreviewMouseWheel(e);
        }
    }
}
