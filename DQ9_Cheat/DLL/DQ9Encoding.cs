// Decompiled with JetBrains decompiler
// Type: FriedGinger.DQCheat.DQ9Encoding
// Assembly: DQCheat, Version=0.7.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8257ADC3-8608-472B-A2D6-0B748207D880
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.dll

using System.Collections.Generic;
using System.Text;

#nullable disable
namespace FriedGinger.DQCheat
{
  public class DQ9Encoding : Encoding
  {
    private static Dictionary<char, byte> decodeDictionary;
    private static Dictionary<byte, char> encodeDictionary;
    private static readonly byte[] bytes = new byte[95]
    {
      (byte) 4,
      (byte) 70,
      (byte) 71,
      (byte) 72,
      (byte) 74,
      (byte) 75,
      (byte) 76,
      (byte) 77,
      (byte) 83,
      (byte) 84,
      (byte) 85,
      (byte) 88,
      (byte) 92,
      (byte) 93,
      (byte) 94,
      (byte) 95,
      (byte) 96,
      (byte) 97,
      (byte) 98,
      (byte) 99,
      (byte) 100,
      (byte) 101,
      (byte) 102,
      (byte) 103,
      (byte) 105,
      (byte) 106,
      (byte) 107,
      (byte) 109,
      (byte) 111,
      (byte) 113,
      (byte) 114,
      (byte) 116,
      (byte) 118,
      (byte) 120,
      (byte) 121,
      (byte) 122,
      (byte) 123,
      (byte) 124,
      (byte) 125,
      (byte) 126,
      (byte) 127,
      (byte) 128,
      (byte) 129,
      (byte) 130,
      (byte) 131,
      (byte) 132,
      (byte) 133,
      (byte) 134,
      (byte) 135,
      (byte) 136,
      (byte) 137,
      (byte) 138,
      (byte) 139,
      (byte) 141,
      (byte) 142,
      (byte) 143,
      (byte) 144,
      (byte) 145,
      (byte) 146,
      (byte) 147,
      (byte) 148,
      (byte) 149,
      (byte) 150,
      (byte) 151,
      (byte) 152,
      (byte) 153,
      (byte) 154,
      (byte) 155,
      (byte) 156,
      (byte) 157,
      (byte) 158,
      (byte) 159,
      (byte) 160,
      (byte) 161,
      (byte) 162,
      (byte) 163,
      (byte) 164,
      (byte) 165,
      (byte) 166,
      (byte) 167,
      (byte) 168,
      (byte) 169,
      (byte) 228,
      (byte) 229,
      (byte) 230,
      (byte) 231,
      (byte) 232,
      (byte) 233,
      (byte) 234,
      (byte) 235,
      (byte) 236,
      (byte) 237,
      (byte) 238,
      (byte) 240,
      byte.MaxValue
    };
    private static readonly string chars = "'{|}€,„Œœ¡£«»¿!\"#$%&’()+-./;=?[]_ÀÁÂÄÆÇÈÉÊËÌÍÎÏÑÒÓÔÕÖÙÚÛÜßàáâäæçèéêëìíîïñòóôõöùúûü~☻*@¢ªº←↑→↓– ";

    public override string EncodingName => "DQ9";

    public override string WebName => "dq9";

    public override string HeaderName => "DQ9";

    public override bool IsSingleByte => true;

    public DQ9Encoding()
    {
      if (DQ9Encoding.decodeDictionary != null && DQ9Encoding.encodeDictionary != null)
        return;
      DQ9Encoding.CreateDictionaries();
    }

    public override int GetByteCount(char[] chars, int index, int count) => count;

    public override int GetCharCount(byte[] bytes, int index, int count) => count;

    public override int GetMaxByteCount(int chars) => chars;

    public override int GetMaxCharCount(int bytes) => bytes;

    public override int GetChars(
      byte[] bytes,
      int byteIndex,
      int byteCount,
      char[] chars,
      int charIndex)
    {
      int index;
      for (index = byteIndex; index < byteCount; ++index)
        chars[charIndex++] = DQ9Encoding.encodeDictionary.ContainsKey(bytes[index]) ? DQ9Encoding.encodeDictionary[bytes[index]] : '?';
      return index - byteIndex;
    }

    public override int GetBytes(
      char[] chars,
      int charIndex,
      int charCount,
      byte[] bytes,
      int byteIndex)
    {
      int index;
      for (index = charIndex; index < charCount; ++index)
        bytes[byteIndex++] = DQ9Encoding.decodeDictionary.ContainsKey(chars[index]) ? DQ9Encoding.decodeDictionary[chars[index]] : (byte) 1;
      return index - charIndex;
    }

    public override string GetString(byte[] bytes, int index, int count)
    {
      char[] chArray = new char[count];
      for (int index1 = 0; index1 < count; ++index1)
        chArray[index1] = DQ9Encoding.encodeDictionary.ContainsKey(bytes[index1]) ? DQ9Encoding.encodeDictionary[bytes[index1]] : '?';
      return new string(chArray);
    }

    private static void CreateDictionaries()
    {
      DQ9Encoding.decodeDictionary = new Dictionary<char, byte>();
      DQ9Encoding.encodeDictionary = new Dictionary<byte, char>();
      for (int index = 0; index < 26; ++index)
      {
        DQ9Encoding.decodeDictionary.Add((char) (65 + index), (byte) (index + 18));
        DQ9Encoding.decodeDictionary.Add((char) (97 + index), (byte) (index + 44));
        DQ9Encoding.encodeDictionary.Add((byte) (index + 18), (char) (65 + index));
        DQ9Encoding.encodeDictionary.Add((byte) (index + 44), (char) (97 + index));
      }
      for (int index = 0; index < 10; ++index)
      {
        DQ9Encoding.decodeDictionary.Add((char) (48 + index), (byte) (index + 8));
        DQ9Encoding.encodeDictionary.Add((byte) (index + 8), (char) (48 + index));
      }
      for (int index = 0; index < DQ9Encoding.bytes.Length; ++index)
      {
        try
        {
          DQ9Encoding.decodeDictionary.Add(DQ9Encoding.chars[index], DQ9Encoding.bytes[index]);
          DQ9Encoding.encodeDictionary.Add(DQ9Encoding.bytes[index], DQ9Encoding.chars[index]);
        }
        catch
        {
        }
      }
    }
  }
}
