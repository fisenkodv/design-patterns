using System;

namespace DesignPattern.Behaviourial
{
  public abstract class EncryptionAlgorithm
  {
    public EncryptionAlgorithm(string textToEncrypt, string key)
    {
      Text = textToEncrypt;
      Key = key;
    }

    public string Key { get; protected set; }
    public string Text { get; protected set; }

    public abstract void EncryptText();
  }

  public class TripleDESEncryption : EncryptionAlgorithm
  {
    public TripleDESEncryption(string textToEncrypt, string key)
      : base(textToEncrypt, key)
    {
    }

    public override void EncryptText()
    {
      Console.WriteLine("Encrypted using *** Triple-DES *** Algorithm.");
    }
  }

  public class RSAEncryption : EncryptionAlgorithm
  {
    public RSAEncryption(string textToEncrypt, string key)
      : base(textToEncrypt, key)
    {
    }

    public override void EncryptText()
    {
      Console.WriteLine("Encrypted using *** RSA *** Algorithm.");
    }
  }

  public class TemplateProgram
  {
    public static void RunTemplate()
    {
      EncryptionAlgorithm tripleDes = new TripleDESEncryption("A million dollar secret", "!@#$%^&*()");
      tripleDes.EncryptText();

      EncryptionAlgorithm rsa = new RSAEncryption("A million dollar secret", "#secret#");
      rsa.EncryptText();
    }
  }
}