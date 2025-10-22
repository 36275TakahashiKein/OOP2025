using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CustomerApp.Data {
    public class Customer {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }

        // 画像バイト配列を BitmapImage に変換するプロパティ
        [Ignore]
        public BitmapImage PictureImage {
            get {
                if (Picture != null) {
                    var bitmap = new BitmapImage();
                    using (var stream = new MemoryStream(Picture)) {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                    }
                    return bitmap;
                }
                return null;
            }
        }
    }

}
