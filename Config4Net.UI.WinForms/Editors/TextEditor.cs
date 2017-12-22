﻿using Config4Net.UI.Editors;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Config4Net.UI.WinForms.Editors
{
    public partial class TextEditor : DefaultEditor, ITextEditor
    {
        private readonly EditorHelper<string> _editorHelper;
        
        private bool _readOnly;
        private string _value;

        public event ValueChangedEventHandler ValueChanged;

        public event ValueChangingEventHandler ValueChanging;

        public string Value
        {
            get => _value;
            set
            {
                _editorHelper.ChangeValue(
                    value,
                    () =>
                    {
                        txtContent.Text = value;
                        _value = value;
                    },
                    ValueChanging,
                    ValueChanged);
            }
        }

        public bool ReadOnly
        {
            get => _readOnly;
            set
            {
                txtContent.ReadOnly = value;
                _readOnly = value;
            }
        }

        public void SetReferenceInfo(object source, PropertyInfo propertyInfo)
        {
            _editorHelper.SetReferenceInfo(source, propertyInfo);
        }

        public void Bind()
        {
            _editorHelper.Bind();
        }

        public void Reset()
        {
            _editorHelper.Reset();
        }

        public override int PreferHeight
        {
            get => txtContent.Height;
            set => base.PreferHeight = value;
        }

        public TextEditor()
        {
            InitializeComponent();
            _editorHelper = new EditorHelper<string>(this);
        }

        private void txtContent_Leave(object sender, System.EventArgs e)
        {
            ChangeValueIfNecessary();
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ChangeValueIfNecessary();
        }

        private void ChangeValueIfNecessary()
        {
            if (_value != txtContent.Text)
                Value = txtContent.Text;
        }
    }
}