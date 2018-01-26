﻿using System.Windows.Controls;
using VixenModules.Preview.VixenPreview.CustomPropEditor.ViewModel;

namespace VixenModules.Preview.VixenPreview.CustomPropEditor.View
{
	/// <summary>
	/// Interaction logic for PropEditorControl.xaml
	/// </summary>
	public partial class PropEditorView : UserControl
	{
		private readonly PropEditorViewModel _viewModel;
		public PropEditorView()
		{
			InitializeComponent();
			_viewModel = new PropEditorViewModel();
			DataContext = _viewModel;
		}
	}
}
