﻿using Config4Net.UI.Editors;

namespace Config4Net.UI.WinForms.Editors
{
    internal class NumberEditorFactory : IEditorFactory<INumberEditor>
    {
        public INumberEditor Create()
        {
            return new NumberEditor();
        }
    }
}