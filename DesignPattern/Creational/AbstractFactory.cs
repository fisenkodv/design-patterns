using System;

namespace DesignPattern.Creational
{
	public enum ControlType
	{
		Text,
		Button
	}

	public interface IControl
	{
		float X { get; set; }
		float Y { get; set; }
		void Paint();
	}

	public abstract class TextControl : IControl
	{
		public bool IsRunTimeEditable { get; protected set; }
		public ConsoleColor FontColor { get; protected set; }

		public float X { get; set; }
		public float Y { get; set; }

		public abstract void Paint();
	}

	public abstract class ButtonControl : IControl
	{
		public bool IsChioceSelection { get; protected set; }
		public ConsoleColor BackColor { get; protected set; }

		public float X { get; set; }
		public float Y { get; set; }

		public abstract void Paint();
	}

	public class TextBox : TextControl
	{
		public TextBox()
		{
			this.IsRunTimeEditable = true;
			this.FontColor = ConsoleColor.Black;
			this.X = this.Y = 0.0f;
		}

		public override void Paint()
		{
			Console.WriteLine("TEXTBOX painted with Font Color as {0} and at Location: [{1}, {2}]", this.FontColor, this.X, this.Y);
		}
	}

	public class Label : TextControl
	{
		public Label()
		{
			this.IsRunTimeEditable = false;
			this.FontColor = ConsoleColor.DarkGray;
			this.X = this.Y = 0.0f;
		}

		public override void Paint()
		{
			Console.WriteLine("LABEL painted with Font Color as {0} and at Location: [{1}, {2}]", this.FontColor, this.X, this.Y);
		}
	}

	public class RadioButton : ButtonControl
	{
		public RadioButton()
		{
			this.IsChioceSelection = true;
			this.BackColor = ConsoleColor.DarkGray;
			this.X = this.Y = 0.0f;
		}

		public override void Paint()
		{
			Console.WriteLine("RADIO-BUTTON painted with Font Color as {0} and at Location: [{1}, {2}]", this.BackColor, this.X, this.Y);
		}
	}

	public class Button : ButtonControl
	{
		public Button()
		{
			this.IsChioceSelection = false;
			this.BackColor = ConsoleColor.DarkGray;
			this.X = this.Y = 0.0f;
		}

		public override void Paint()
		{
			Console.WriteLine("BUTTON painted with Font Color as {0} and at Location: [{1}, {2}]", this.BackColor, this.X, this.Y);
		}
	}

	public class ControlFactory
	{
		private IControl _ControlObject = null;

		public IControl GetControl(ControlType type, bool isEditableOrSelectable)
		{
			switch (type)
			{
				case ControlType.Text:
					{
						_ControlObject = (IControl)TextFactory.GetTextControl(isEditableOrSelectable);
					}
					break;
				case ControlType.Button:
					{
						_ControlObject = (IControl)ButtonFactory.GetButtonControl(isEditableOrSelectable);
					}
					break;
			}
			return _ControlObject;
		}
	}

	public class TextFactory
	{
		private static TextControl _TextControlObject = null;

		public static TextControl GetTextControl(bool isRuntimeEditable)
		{
			if (isRuntimeEditable)
				_TextControlObject = new TextBox();
			else
				_TextControlObject = new Label();

			return _TextControlObject;
		}
	}

	public class ButtonFactory
	{
		private static ButtonControl _ButtonControlObject = null;

		public static ButtonControl GetButtonControl(bool isChoiceSelection)
		{
			if (isChoiceSelection)
				_ButtonControlObject = new RadioButton();
			else
				_ButtonControlObject = new Button();

			return _ButtonControlObject;
		}
	}

	public class AbstractFactoryProgram
	{
		public static void RunAbstractFactory()
		{
			IControl controlObject = null;
			ControlFactory factory = new ControlFactory();

			controlObject = factory.GetControl(ControlType.Text, true);
			controlObject.X = 100;
			controlObject.Y = 100;
			controlObject.Paint();

			controlObject = factory.GetControl(ControlType.Button, false);
			controlObject.X = 200;
			controlObject.Y = 300;
			controlObject.Paint();
		}
	}
}
