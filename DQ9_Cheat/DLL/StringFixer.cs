﻿// Decompiled with JetBrains decompiler
// Type: FriedGinger.DQCheat.StringFixer
// Assembly: DQCheat, Version=0.7.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8257ADC3-8608-472B-A2D6-0B748207D880
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.dll

using System;

#nullable disable
namespace FriedGinger.DQCheat
{
  public class StringFixer
  {
    public static readonly DQ9Encoding encoding = new DQ9Encoding();
    public static readonly TemplateEncoding templateencoding = new TemplateEncoding();

    [Obsolete]
    public static byte[] Decode(string stringToDecode)
    {
      return StringFixer.encoding.GetBytes(stringToDecode);
    }

    [Obsolete]
    public static string Encode(byte[] bytes, int count)
    {
      return StringFixer.encoding.GetString(bytes, 0, count);
    }

    public static byte[] GetBytes(string input) => StringFixer.encoding.GetBytes(input);

    public static string GetString(byte[] bytes, int count)
    {
      return StringFixer.encoding.GetString(bytes, 0, count);
    }

    public static byte[] GetTemplateBytes(string input)
    {
      return StringFixer.templateencoding.GetBytes(input);
    }

    public static string GetTemplateString(byte[] bytes, int count)
    {
      return StringFixer.templateencoding.GetString(bytes, 0, count);
    }
  }
}