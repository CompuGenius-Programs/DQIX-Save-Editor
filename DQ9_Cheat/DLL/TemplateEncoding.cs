// Decompiled with JetBrains decompiler
// Type: FriedGinger.DQCheat.TemplateEncoding
// Assembly: DQCheat, Version=0.7.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8257ADC3-8608-472B-A2D6-0B748207D880
// Assembly location: dq9_save_editor_0.7\DQCheat.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace FriedGinger.DQCheat;

public class TemplateEncoding : Encoding
{
    private static readonly string[] temptags = new string[57]
    {
        ",",
        "1",
        "6",
        "9",
        "66",
        "99",
        "`A",
        "'A",
        "^A",
        ":A",
        "AE",
        ",C",
        "`E",
        "'E",
        "^E",
        ":E",
        "`I",
        "'I",
        "^I",
        ":I",
        "~N",
        "`O",
        "'O",
        "^O",
        "~O",
        ":O",
        "OE",
        "`U",
        "'U",
        "^U",
        ":U",
        "ss",
        "'a",
        "`a",
        "^a",
        ":a",
        "ae",
        ",c",
        "'e",
        "`e",
        "^e",
        ":e",
        "'i",
        "`i",
        "^i",
        ":i",
        "~n",
        "`o",
        "'o",
        "^o",
        "~o",
        ":o",
        "oe",
        "`u",
        "'u",
        "^u",
        ":u"
    };

    private static readonly string tempchars = ",'‘’“”ÀÁÂÄÆÇÈÉÊËÌÍÎÏÑÒÓÔÕÖŒÙÚÛÜßàáâäæçèéêëìíîïñòóôõöœùúûü";
    private static Dictionary<string, char> templateDictionary;

    public TemplateEncoding()
    {
        if (templateDictionary != null)
            return;
        templateDictionary = new Dictionary<string, char>();
        for (var index = 0; index < temptags.Length; ++index)
            templateDictionary.Add(temptags[index], tempchars[index]);
    }

    public override string EncodingName => "DQ9 Template";

    public override string WebName => "dq9-template";

    public override int GetByteCount(char[] chars, int index, int count)
    {
        var byteCount = 0;
        var flag = false;
        for (var index1 = 0; index1 < count; ++index1)
        {
            var ch = chars[index + index1];
            if (ch == '<')
            {
                if (!flag)
                    flag = true;
                else
                    continue;
            }

            if (ch == '>')
            {
                if (flag)
                    flag = false;
                else
                    continue;
            }

            if (!flag)
            {
                var index2 = tempchars.IndexOf(ch);
                if (index2 >= 0)
                {
                    byteCount += 2 + temptags[index2].Length;
                    continue;
                }
            }

            if (ch >= ' ' && ch <= '~')
                ++byteCount;
        }

        return byteCount;
    }

    public override int GetCharCount(byte[] bytes, int index, int count)
    {
        var charCount = 0;
        var flag = false;
        var stringBuilder = new StringBuilder();
        for (var index1 = 0; index1 < count; ++index1)
        {
            var num = bytes[index + index1];
            if (num >= 32 && num <= 126)
                switch (num)
                {
                    case 60:
                        flag = true;
                        continue;
                    case 62:
                        if (flag)
                        {
                            var key = stringBuilder.ToString();
                            if (templateDictionary.ContainsKey(key))
                                ++charCount;
                            else
                                charCount += 2 + key.Length;
                            stringBuilder.Length = 0;
                            flag = false;
                        }

                        continue;
                    default:
                        if (flag)
                        {
                            stringBuilder.Append((char)num);
                            continue;
                        }

                        ++charCount;
                        continue;
                }
        }

        return charCount;
    }

    public override int GetMaxByteCount(int chars)
    {
        return chars << 2;
    }

    public override int GetMaxCharCount(int bytes)
    {
        return bytes;
    }

    public override string GetString(byte[] bytes, int index, int count)
    {
        var stringBuilder1 = new StringBuilder();
        var flag = false;
        var stringBuilder2 = new StringBuilder();
        for (var index1 = 0; index1 < count; ++index1)
        {
            var num = bytes[index + index1];
            if (num >= 32 && num <= 126)
                switch (num)
                {
                    case 60:
                        flag = true;
                        continue;
                    case 62:
                        if (flag)
                        {
                            var key = stringBuilder2.ToString();
                            if (templateDictionary.ContainsKey(key))
                                stringBuilder1.Append(templateDictionary[key]);
                            else
                                stringBuilder1.Append('<').Append(key).Append('>');
                            stringBuilder2.Length = 0;
                            flag = false;
                        }

                        continue;
                    default:
                        if (flag)
                        {
                            stringBuilder2.Append((char)num);
                            continue;
                        }

                        stringBuilder1.Append((char)num);
                        continue;
                }
        }

        return stringBuilder1.ToString();
    }

    public override int GetChars(
        byte[] bytes,
        int byteIndex,
        int byteCount,
        char[] chars,
        int charIndex)
    {
        var num1 = charIndex;
        var flag = false;
        var stringBuilder = new StringBuilder();
        for (var index1 = 0; index1 < byteCount; ++index1)
        {
            var num2 = bytes[byteIndex + index1];
            if (num2 >= 32 && num2 <= 126)
                switch (num2)
                {
                    case 60:
                        flag = true;
                        continue;
                    case 62:
                        if (flag)
                        {
                            var key = stringBuilder.ToString();
                            if (templateDictionary.ContainsKey(key))
                            {
                                chars[num1++] = templateDictionary[key];
                            }
                            else
                            {
                                var chArray1 = chars;
                                var index2 = num1;
                                var destinationIndex = index2 + 1;
                                chArray1[index2] = '<';
                                Array.Copy(key.ToCharArray(), 0, chars, destinationIndex, key.Length);
                                var num3 = destinationIndex + key.Length;
                                var chArray2 = chars;
                                var index3 = num3;
                                num1 = index3 + 1;
                                chArray2[index3] = '>';
                            }

                            stringBuilder.Length = 0;
                            flag = false;
                        }

                        continue;
                    default:
                        if (flag)
                        {
                            stringBuilder.Append((char)num2);
                            continue;
                        }

                        chars[num1++] = (char)num2;
                        continue;
                }
        }

        return num1 - charIndex;
    }

    public override int GetBytes(
        char[] chars,
        int charIndex,
        int charCount,
        byte[] bytes,
        int byteIndex)
    {
        var num1 = byteIndex;
        var flag = false;
        for (var index1 = 0; index1 < charCount; ++index1)
        {
            var ch = chars[charIndex + index1];
            if (ch == '<')
            {
                if (!flag)
                    flag = true;
                else
                    continue;
            }

            if (ch == '>')
            {
                if (flag)
                    flag = false;
                else
                    continue;
            }

            if (!flag)
            {
                var index2 = tempchars.IndexOf(ch);
                if (index2 >= 0)
                {
                    var numArray1 = bytes;
                    var index3 = num1;
                    var num2 = index3 + 1;
                    numArray1[index3] = 60;
                    foreach (byte num3 in temptags[index2])
                        bytes[num2++] = num3;
                    var numArray2 = bytes;
                    var index4 = num2;
                    num1 = index4 + 1;
                    numArray2[index4] = 62;
                    continue;
                }
            }

            if (ch >= ' ' && ch <= '~')
                bytes[num1++] = (byte)ch;
        }

        return num1 - byteIndex;
    }
}