using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Hunabku.VSPasteResurrected.OptionEditors
{
	public static class WindowsControlsBindingExtensions
	{
		public static void Bind(this Form control, ViewModelBase model)
		{
			if (model == null)
			{
				return;
			}
			model.CloseRequest += (sender, args) => control.Close();
			control.Closing += (sender, args) =>
			{
				args.Cancel = !model.CanClose();
			};
			control.FormClosed += (sender, args) => model.Dispose();
		}

		public static void Bind(this Button control, ICommand command)
		{
			command.PropertyChanged += (sender, args) =>
			{
				if ("CanExecute".Equals(args.PropertyName))
				{
					control.ThreadSafeInvoke(() => control.Enabled = command.CanExecute);
				}
			};
			control.Enabled = command.CanExecute;
			control.Click += (o, e) => command.Execute();
		}

		public static void BindValue<TModel, TProperty>(this TextBox control, TModel model, Expression<Func<TModel, TProperty>> value, DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
		{
			var propertyName = GetPlainPropertyName(control, value);
			control.DataBindings.Add("Text", model, propertyName, false, mode);
		}

		public static void BindValue<TModel>(this CheckBox control, TModel model, Expression<Func<TModel, bool>> value)
		{
			var propertyName = GetPlainPropertyName(control, value);
			control.DataBindings.Add("Checked", model, propertyName, false, DataSourceUpdateMode.OnPropertyChanged);
		}

		public static void BindValue<TModel, TProperty>(this NumericUpDown control, TModel model, Expression<Func<TModel, TProperty>> value, DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
		{
			var propertyName = GetPlainPropertyName(control, value);
			control.DataBindings.Add("Value", model, propertyName, false, mode);
		}

		private static string GetPlainPropertyName<TModel, TProperty>(Control control, Expression<Func<TModel, TProperty>> expression)
		{
			MemberExpression memberExpression = null;

			if (expression.Body.NodeType == ExpressionType.Convert)
			{
				memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
			}
			else if (expression.Body.NodeType == ExpressionType.MemberAccess)
			{
				memberExpression = expression.Body as MemberExpression;
			}

			if (memberExpression == null)
			{
				throw new NotSupportedException($"Bind expression for {control.GetType().Name} control ({control.Name}) not supported.");
			}

			return memberExpression.Member.Name;
		}

		private static PropertyInfo GetPlainProperty<TModel, TProperty>(Control control, Expression<Func<TModel, TProperty>> expression)
		{
			MemberExpression memberExpression = null;

			if (expression.Body.NodeType == ExpressionType.Convert)
			{
				memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
			}
			else if (expression.Body.NodeType == ExpressionType.MemberAccess)
			{
				memberExpression = expression.Body as MemberExpression;
			}

			if (memberExpression == null || memberExpression.Member.MemberType != MemberTypes.Property)
			{
				throw new NotSupportedException($"Bind expression for {control.GetType().Name} control ({control.Name}) not supported.");
			}

			return (PropertyInfo)memberExpression.Member;
		}

		public static void ThreadSafeInvoke(this Control source, Action method)
		{
			if (source.InvokeRequired)
			{
				source.BeginInvoke(method);
			}
			else
			{
				method();
			}
		}
	}
}