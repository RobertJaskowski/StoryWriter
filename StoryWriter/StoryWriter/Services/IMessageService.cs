using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.Services
{
    public interface IMessageService
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
