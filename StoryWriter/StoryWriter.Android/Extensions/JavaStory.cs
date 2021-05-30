using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using StoryWriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryWriter.Droid.Extensions
{
    public class JavaStory : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, Java.Interop.IJavaPeerable, IComparable, IConvertible
    {
        public string Id;
        public bool IsPublic;
        public string Title;
        public string AdminId;
        //public List<JavaCharacter> Characters;
        //public List<JavaDialogueLine> DialogueLines;

        public JavaStory()
        {
        }

        public JavaStory(string id, bool isPublic, string title, string adminId)
        {
            Id = id;
            IsPublic = isPublic;
            Title = title;
            AdminId = adminId;
        }

        public JavaStory(Story story)
        {
            Id = story.Id;
            Title = story.Title;
            IsPublic = story.IsPublic;
            AdminId = story.AdminId;

            //List<JavaCharacter> jchars = new List<JavaCharacter>();
            //if (story.Characters != null)
            //{
            //    foreach (var schar in story.Characters)
            //    {
            //        jchars.Add(new JavaCharacter(schar));
            //    }
            //}
            //Characters = jchars;

            //List<JavaDialogueLine> jdl = new List<JavaDialogueLine>();
            //if (story.DialogueLines != null)
            //{
            //    foreach (var dl in story.DialogueLines)
            //    {
            //        jdl.Add(new JavaDialogueLine(dl));
            //    }
            //}

            //DialogueLines = jdl;
        }

        public JavaStory(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}