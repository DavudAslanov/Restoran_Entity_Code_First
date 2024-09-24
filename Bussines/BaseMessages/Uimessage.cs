using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.BaseEntities
{
    public static class Uimessage
    {
        public const string ADD_MESSAGE = "Əlavə Edildi";
        public const string UPDATE_MESSAGE = "Məlumat Yeniləndi";
        public const string DELETED_MESSAGE = "Məlumat Silindi";
        public const string DELETED_MESSAGES = "Məlumat Birdəfəlik Silindi";
        public const string PHOTO_SELECTED = "Şəkil Seçilməlidir!";

        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} boş ola bilməz!";
        }

        public static string GetMinLengthMessage(int length, string propName)
        {
            return $"{propName} {length} simvoldan aşağı ola bilməz!";
        }

        public static string GetMaxLengthMessage(int length, string propName)
        {
            return $"{propName} {length} simvoldan yuxarı ola bilməz!";
        }
    }
}
