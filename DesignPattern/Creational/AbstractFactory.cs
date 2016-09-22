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
      IsRunTimeEditable = true;
      FontColor = ConsoleColor.Black;
      X = Y = 0.0f;
    }

    public override void Paint()
    {
      Console.WriteLine("TEXTBOX painted with Font Color as {0} and at Location: [{1}, {2}]", FontColor, X, Y);
    }
  }

  public class Label : TextControl
  {
    public Label()
    {
      IsRunTimeEditable = false;
      FontColor = ConsoleColor.DarkGray;
      X = Y = 0.0f;
    }

    public override void Paint()
    {
      Console.WriteLine("LABEL painted with Font Color as {0} and at Location: [{1}, {2}]", FontColor, X, Y);
    }
  }

  public class RadioButton : ButtonControl
  {
    public RadioButton()
    {
      IsChioceSelection = true;
      BackColor = ConsoleColor.DarkGray;
      X = Y = 0.0f;
    }

    public override void Paint()
    {
      Console.WriteLine("RADIO-BUTTON painted with Font Color as {0} and at Location: [{1}, {2}]", BackColor, X, Y);
    }
  }

  public class Button : ButtonControl
  {
    public Button()
    {
      IsChioceSelection = false;
      BackColor = ConsoleColor.DarkGray;
      X = Y = 0.0f;
    }

    public override void Paint()
    {
      Console.WriteLine("BUTTON painted with Font Color as {0} and at Location: [{1}, {2}]", BackColor, X, Y);
    }
  }

  public class ControlFactory
  {
    private IControl _controlObject;

    public IControl GetControl(ControlType type, bool isEditableOrSelectable)
    {
      switch (type)
      {
        case ControlType.Text:
        {
          _controlObject = TextFactory.GetTextControl(isEditableOrSelectable);
        }
          break;
        case ControlType.Button:
        {
          _controlObject = ButtonFactory.GetButtonControl(isEditableOrSelectable);
        }
          break;
      }
      return _controlObject;
    }
  }

  public class TextFactory
  {
    private static TextControl _textControlObject;

    public static TextControl GetTextControl(bool isRuntimeEditable)
    {
      if (isRuntimeEditable)
        _textControlObject = new TextBox();
      else
        _textControlObject = new Label();

      return _textControlObject;
    }
  }

  public class ButtonFactory
  {
    private static ButtonControl _buttonControlObject;

    public static ButtonControl GetButtonControl(bool isChoiceSelection)
    {
      if (isChoiceSelection)
        _buttonControlObject = new RadioButton();
      else
        _buttonControlObject = new Button();

      return _buttonControlObject;
    }
  }

  public class AbstractFactoryProgram
  {
    public static void RunAbstractFactory()
    {
      var factory = new ControlFactory();

      var controlObject = factory.GetControl(ControlType.Text, true);
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